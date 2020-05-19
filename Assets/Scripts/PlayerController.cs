using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public bool hidden;
    public int playerNumber;

    private RaycastHit groundHit;

    public Material Red;
    public Material Green;

    public Material Player1Outline;
    public Material Player2Outline;

    public float speed = 3.0F;

    public bool canMove = true;
    private Rigidbody2D controller;

    private Animator animator;
    private MeshRenderer insideRen;

    void Update()
    {
        if (canMove)
        {

            // Horizontal input
            float moveHorizontal;
            float moveHorizontalAnalog = Input.GetAxis(InputNames.GetName("p" + playerNumber.ToString() + " horizontal axis"));
            moveHorizontal = moveHorizontalAnalog;
            float moveHorizontalAnalogAlt = Input.GetAxis(InputNames.GetName("p" + playerNumber.ToString() + " horizontal axis alt"));
            if (Mathf.Abs(moveHorizontalAnalogAlt) >= Mathf.Abs(moveHorizontal))
            {
                moveHorizontal = moveHorizontalAnalogAlt;
            }
            float moveHorizontalButton = Input.GetAxis(InputNames.GetName("p" + playerNumber.ToString() + " horizontal key"));
            if (Mathf.Abs(moveHorizontalButton) >= Mathf.Abs(moveHorizontal))
            {
                moveHorizontal = moveHorizontalButton;
            }

            // Vertical input
            float moveVertical;
            float moveVerticalAnalog = Input.GetAxis(InputNames.GetName("p" + playerNumber.ToString() + " vertical axis"));
            moveVertical = moveVerticalAnalog;
            float moveVerticalAnalogAlt = Input.GetAxis(InputNames.GetName("p" + playerNumber.ToString() + " vertical axis alt"));
            if (Mathf.Abs(moveVerticalAnalogAlt) >= Mathf.Abs(moveVertical))
            {
                moveVertical = moveVerticalAnalogAlt;
            }
            float moveVerticalButton = Input.GetAxis(InputNames.GetName("p" + playerNumber.ToString() + " vertical key"));
            if (Mathf.Abs(moveVerticalButton) >= Mathf.Abs(moveVertical))
            {
                moveVertical = moveVerticalButton;
            }


            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            controller.velocity = movement * speed;

            if (Input.GetButtonDown(InputNames.GetName("green")))
            {
                insideRen.sharedMaterial = Green;
            }
            else if (Input.GetButtonDown(InputNames.GetName("red")))
            {
                insideRen.sharedMaterial = Red;
            }
        }

        //Check color under player
        Debug.DrawRay(transform.position + new Vector3(0, 0, 0.4f), new Vector3(0, 0, 1));
        if (Physics.Raycast(transform.position + new Vector3(0, 0, 0.4f), new Vector3(0, 0, 1), out groundHit, 100))
        {
            if (groundHit.transform.gameObject.GetComponent<Renderer>().sharedMaterial == insideRen.sharedMaterial)
            {
                hidden = true;
                animator.SetBool("hidden", true);
            }
            else
            {
                hidden = false;
                animator.SetBool("hidden", false);
            }
        }

        if (Input.GetButtonDown(InputNames.GetName("menu")))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }

    void Start()
    {
        controller = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        insideRen = gameObject.transform.Find("Inside").GetComponent<MeshRenderer>();
        insideRen.enabled = true;

        GameObject outline = gameObject.transform.Find("Outline").gameObject;

        if (outline)
        {
            if (playerNumber == 1)
            {
                outline.GetComponent<Renderer>().sharedMaterial = Player1Outline;
            }
            else if (playerNumber == 2)
            {
                outline.GetComponent<Renderer>().sharedMaterial = Player2Outline;
            }
        }
    }


    public void preventMove()
    {
        controller.velocity = new Vector3(0, 0, 0);
        canMove = false;
    }
}

