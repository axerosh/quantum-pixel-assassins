using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    public bool Large = false;

    public Material Standard;
    public Material BlackOnly;
    public Material WhiteOnly;

    public Material LargeStandard;
    public Material LargeBlackOnly;
    public Material LargeWhiteOnly;

    MeshRenderer ren;
    
    void Start ()
    {
        ren = GetComponent<MeshRenderer>();
        ren.enabled = true;

        if (Large)
        {
            ren.sharedMaterial = LargeStandard;
        }
        else
        {
            ren.sharedMaterial = Standard;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Collision Enter");
    
        GameObject other = coll.gameObject;
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerController>().playerNumber == '0') // Black Player
            {
                Debug.Log("Player 1 Touched");

                if (Large)
                {
                    ren.sharedMaterial = LargeWhiteOnly;
                }
                else
                {
                    ren.sharedMaterial = WhiteOnly;
                }
            }
            else if (other.GetComponent<PlayerController>().playerNumber == '1') // White Player
            {
                Debug.Log("Player 2 Touched");
                if (Large)
                {
                    ren.sharedMaterial = LargeBlackOnly;
                }
                else
                {
                    ren.sharedMaterial = BlackOnly;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Trigger Enter");
    }


    void OnTriggerExit2D(Collider2D coll)
    {
        Debug.Log("Trigger Exit");
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        Debug.Log("Collision Exit");

        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player Left");

            if (Large)
            {
                ren.sharedMaterial = LargeStandard;
            }
            else
            {
                ren.sharedMaterial = Standard;
            }
        }
    }
}
