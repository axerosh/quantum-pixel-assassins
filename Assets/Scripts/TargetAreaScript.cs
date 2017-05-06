using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAreaScript : MonoBehaviour {

    private int numberOfPlayersInZone;

    private bool startedKilling = false;

    public GameObject Target;
    TargetController targetController;

    // Use this for initialization
    void Start () {
        numberOfPlayersInZone = 0;
        targetController = Target.GetComponent<TargetController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            numberOfPlayersInZone++;

            if (other.gameObject.GetComponent<PlayerController>().playerNumber == 1)
            {
                targetController.player1InArea = true;
            }
            else if (other.gameObject.GetComponent<PlayerController>().playerNumber == 2) // White Player
            {
                targetController.player2InArea = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            numberOfPlayersInZone--;

            if (other.gameObject.GetComponent<PlayerController>().playerNumber == 1)
            {
                targetController.player1InArea = false;
            }
            else if (other.gameObject.GetComponent<PlayerController>().playerNumber == 2) // White Player
            {
                targetController.player1InArea = false;
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
