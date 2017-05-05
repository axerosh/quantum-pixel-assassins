using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpot : MonoBehaviour {

    public ArrayList playersInVision;

    public double findTime;

    private bool hasDetected = false;
    private double spottedTime;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        if (other.gameObject.tag == "Player"){
            playersInVision.Add(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject g in playersInVision)
            {
                if (g == other.gameObject)
                {
                    playersInVision.Remove(g);
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        playersInVision = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject g in playersInVision)
        {
            if (!g.GetComponent<PlayerController>().hidden)
            {
                //Player not hidden
                if (!hasDetected)
                {
                    hasDetected = true;
                    spottedTime = Time.time + findTime;
                }
            }
        }

        if (hasDetected && Time.time > spottedTime)
        {
            hasDetected = false;
            Debug.Log("Spotted");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
