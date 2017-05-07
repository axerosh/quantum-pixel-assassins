using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

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
            float moveHorizontalJoystick = Input.GetAxis("HorizontalJoystick" + playerNumber.ToString());
            float moveHorizontalKeyboard = Input.GetAxis("HorizontalKeyboard" + playerNumber.ToString());
            if (Mathf.Abs(moveHorizontalJoystick) > Mathf.Abs(moveHorizontalKeyboard))
            {
                moveHorizontal = moveHorizontalJoystick;
            }
            else
            {
                moveHorizontal = moveHorizontalKeyboard;
            }

            // Vertical input
            float moveVertical;
            float moveVerticalJoystick = Input.GetAxis("VerticalJoystick" + playerNumber.ToString());
            float moveVerticalKeyboard = Input.GetAxis("VerticalKeyboard" + playerNumber.ToString());
            if (Mathf.Abs(moveVerticalJoystick) > Mathf.Abs(moveVerticalKeyboard))
            {
                moveVertical = moveVerticalJoystick;
            }
            else
            {
                moveVertical = moveVerticalKeyboard;
            }


            Vector3 movment = new Vector3(moveHorizontal, moveVertical, 0);
            controller.velocity = movment * speed;

            if (Input.GetButtonDown("AJoystick") || Input.GetButtonDown("AKeyboard"))
            {
                insideRen.sharedMaterial = Green;
            }
            else if (Input.GetButtonDown("BJoystick") || Input.GetButtonDown("BKeyboard"))
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

        if (Input.GetButtonDown("Start"))
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
        controller.velocity = new Vector3(0,0,0);
        canMove = false;
    }
}

