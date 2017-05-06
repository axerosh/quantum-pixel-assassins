using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpot : MonoBehaviour {

    public ArrayList playersInVision;

    public double findTime;

    private bool hasDetected = false;
    private double spottedTime;

    void Start()
    {
        playersInVision = new ArrayList();
    }

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
                    Debug.Log("Leave");
                    playersInVision.Remove(g);
                    break;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        bool oneVisible = false; //At least one player is visible

        foreach (GameObject g in playersInVision)
        {
            if (!g.GetComponent<PlayerController>().hidden)
            {
                oneVisible = true;

                //Player not hidden
                if (!hasDetected)
                {
                    hasDetected = true;
                    spottedTime = Time.time + findTime;
                }
            }
        }

        if (!oneVisible)
        {
            //If none is visible anymore, don't spot
            hasDetected = false;
        }

        if (hasDetected && Time.time > spottedTime)
        {
            hasDetected = false;
            Debug.Log("Spotted");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
