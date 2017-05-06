using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAreaScript : MonoBehaviour {

    public GameObject Eraser;

    private int numberOfPlayersInZone;

    private bool startedKilling = false;
    
    private TargetController targetController;

    // Use this for initialization
    void Start () {
        numberOfPlayersInZone = 0;
        targetController = GameObject.Find("Target").GetComponent<TargetController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            numberOfPlayersInZone++;

            if (other.gameObject.GetComponent<PlayerController>().playerNumber == 1)
            {
                targetController.OnPlayer1Enter();
            }
            else if (other.gameObject.GetComponent<PlayerController>().playerNumber == 2)
            {
                targetController.OnPlayer2Enter();
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
                targetController.OnPlayer1Exit();
            }
            else if (other.gameObject.GetComponent<PlayerController>().playerNumber == 2)
            {
                targetController.OnPlayer2Exit();
            }
        }
    }

    // Update is called once per frame
    void Update () {

		if (numberOfPlayersInZone == 2 && Input.GetAxis("Kill1") < 0 && Input.GetAxis("Kill2") < 0 && !startedKilling)
        {
            Debug.Log("Killing");

            Eraser.SetActive(true);
            Eraser.GetComponent<EraserController>().EraseAndBegone();

            Destroy(gameObject);
            startedKilling = true;
        }
	}
}
