using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInteractible : MonoBehaviour {

    public bool Toggled;
    private int numberOfPlayersInZone;
    private bool pressing;

    // Use this for initialization
    void Start()
    {
        Toggled = false;
        pressing = false;

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
    void Update()
    {
        if (numberOfPlayersInZone > 0 && Input.GetAxis("Kill") < 0 && !pressing)
        {
            pressing = true;
            Debug.Log("Interacting");
            Interact();
        }
        else
        {
            Toggled = false;
        }


        if (Input.GetAxis("Kill") == 0)
        {
            pressing = false;
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
