using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAreaScript : MonoBehaviour {

    public GameObject Eraser;

    private int numberOfPlayersInZone;

    public bool startedKilling = false;
    
    private TargetController targetController;

    private GameObject[] players;

    // Use this for initialization
    void Start () {
        numberOfPlayersInZone = 0;
        targetController = GameObject.Find("Target").GetComponent<TargetController>();
        players = GameObject.FindGameObjectsWithTag("Player");
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
    void Update()
    {

        if (!startedKilling && numberOfPlayersInZone == 2)
        {
            if (Input.GetAxis("KillJoystick1") < 0 || Input.GetButton("KillKeyboard1"))
            {
                if (Input.GetAxis("KillJoystick2") < 0 || Input.GetButton("KillKeyboard2"))
                {
                    Kill();
                }
                else
                {
                    targetController.onPlayer1KillHold();
                }
            }
            else
            {
                targetController.onPlayer1KillRelease();



                if (Input.GetAxis("KillJoystick2") < 0 || Input.GetButton("KillKeyboard2"))
                {
                    if (Input.GetAxis("KillJoystick1") < 0 || Input.GetButton("KillKeyboard1"))
                    {
                        Kill();
                    }
                    else
                    {
                        targetController.onPlayer2KillHold();
                    }
                }
                else
                {
                    targetController.onPlayer2KillRelease();
                }
            }
        }

    }

    private void Kill()
    {
        Debug.Log("Killing");

        Eraser.SetActive(true);
        Eraser.GetComponent<EraserController>().EraseAndBegone();

        Destroy(gameObject);
        startedKilling = true;

        foreach (GameObject g in players)
        {
            g.GetComponent<PlayerController>().preventMove();
        }
    }
}
