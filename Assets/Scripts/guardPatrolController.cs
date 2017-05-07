using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardPatrolController : MonoBehaviour {

    public GameObject wayPoints;

    public ArrayList goals;
    private int curTarget = 0;
    public float standTime = 1; //Time to stay at each place

    public float walkSpeed = 1;
    public float rotationSpeed = 4;

    private bool walk = false;

    public float startTime = 0;

	// Use this for initialization
	void Start () {
        goals = new ArrayList();

        foreach(Transform child in wayPoints.transform)
        {
            goals.Add(child.position);
        }

        Invoke("startMove", startTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            walk = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCameraController>().SpotPlayer(collision.gameObject);
        }
    }

    private void startMove()
    {
        walk = true;
    }

	// Update is called once per frame
	void Update () {
        if (walk && goals.Count > 0)
        {
            Vector3 delta = ((Vector3)goals[curTarget]) - transform.position;

            if (delta.magnitude < 0.01)
            {
                walk = false;
                Invoke("startMove", standTime);

                curTarget = (curTarget + 1) % goals.Count;
            }
            else
            {
                Vector3 newDir = Vector3.RotateTowards(transform.up, -delta.normalized, Time.deltaTime*rotationSpeed, 0.0F);
                //float rotAngle = Vector3.Angle(transform.up, newDir);
                //if (Vector3.Cross(transform.up, newDir).z < 0) rotAngle = -rotAngle;
                transform.SetPositionAndRotation(transform.position + delta.normalized * walkSpeed * Time.deltaTime, Quaternion.LookRotation(-transform.forward, newDir));
                //transform.SetPositionAndRotation(transform.position + delta.normalized * walkSpeed * Time.deltaTime, transform.rotation);
                /*
                if (rotAngle > 0.000000001f) {
                    transform.Rotate(0, 0, rotAngle);
                }*/
            }
        }
	}
}
