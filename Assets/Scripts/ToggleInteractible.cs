using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInteractible : MonoBehaviour {

    public bool Toggled;
    private ArrayList players;
    private int numberOfPlayersInZone;
    private bool pressing;

    // Use this for initialization
    void Start()
    {
        players = new ArrayList();
        Toggled = false;
        pressing = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            players.Add(other.gameObject);
            Debug.Log("Enters");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject g in players)
            {
                if (g == other.gameObject)
                {
                    players.Remove(g);
                    Debug.Log("Leaves");
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject g in players)
        {
            if (g.GetComponent<PlayerController>().playerNumber == 1)
            {
                if (Input.GetButtonDown("P1: Interact/Erase (Key/Button)"))
                {
                    Debug.Log("Interacting");
                    Interact();
                }
                else if (Input.GetAxis("P1: Interact/Erase (Analog)") < 0 && !pressing)
                {
                    pressing = true;
                    Debug.Log("Interacting");
                    Interact();
                }
                else
                {
                    Toggled = false;
                }


                if (Input.GetAxis("P1: Interact/Erase (Analog)") == 0)
                {
                    pressing = false;
                }
            }

            if (g.GetComponent<PlayerController>().playerNumber == 2)
            {
                if (Input.GetButtonDown("P2: Interact/Erase (Key/Button)"))
                {
                    Debug.Log("Interacting");
                    Interact();
                }
                else if (Input.GetAxis("P2: Interact/Erase (Analog)") < 0 && !pressing)
                {
                    pressing = true;
                    Debug.Log("Interacting");
                    Interact();
                }
                else
                {
                    Toggled = false;
                }


                if (Input.GetAxis("P2: Interact/Erase (Analog)") == 0)
                {
                    pressing = false;
                }
            }
        }

        

    }

    public void Interact()
    {
        Toggled = true;
    }

    public bool GetToggled()
    {
        return Toggled;
    }

}
