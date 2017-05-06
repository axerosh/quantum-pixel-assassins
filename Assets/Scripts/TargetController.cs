using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    public bool Large = false;

    public Sprite Standard;
    public Sprite BlackOnly;
    public Sprite WhiteOnly;

    public Sprite LargeStandard;
    public Sprite LargeBlackOnly;
    public Sprite LargeWhiteOnly;

    SpriteRenderer ren;

    public bool player1InArea = false;
    public bool player2InArea = false;
    
    void Start ()
    {
        ren = GetComponent<SpriteRenderer>();
        ren.enabled = true;


        if (Large)
        {
            ren.sprite = LargeStandard;
        }
        else
        {
            ren.sprite = Standard;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.GetComponent<PlayerController>().playerNumber == 1) // Black Player
            {
                GameObject target = GameObject.Find("Target");
                if (target)
                {

                    if (target.Large)
                    {
                        ren.sprite = LargeWhiteOnly;
                    }
                    else
                    {
                        ren.sprite = WhiteOnly;
                    }
                }

                GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            }
            else if (coll.gameObject.GetComponent<PlayerController>().playerNumber == 2) // White Player
            {
                if (Large)
                {
                    ren.sprite = LargeBlackOnly;
                }
                else
                {
                    ren.sprite = BlackOnly;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (Large)
            {
                ren.sprite = LargeStandard;
            }
            else
            {
                ren.sprite = Standard;
            }
        }
    }
}
