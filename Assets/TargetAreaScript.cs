using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAreaScript : MonoBehaviour {

    private int numberOfPlayersInZone;
    private bool startedKilling = false;

	// Use this for initialization
	void Start () {
        numberOfPlayersInZone = 0;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            numberOfPlayersInZone++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            numberOfPlayersInZone--;
        }
    }

    // Update is called once per frame
    void Update () {

		if (numberOfPlayersInZone > 0 && Input.GetAxis("Kill") < 0 && !startedKilling)
        {
            Debug.Log("Killing target");
            startedKilling = true;
        }
	}
}
