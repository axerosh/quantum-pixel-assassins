using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool hidden;
    public int playerNumber;

    private RaycastHit groundHit;

    MeshRenderer ren;

    public Material Red;
    public Material Green;

    public Material Player1Outline;
    public Material Player2Outline;

    public float speed = 6.0F;

    void Update()
    {
        Rigidbody2D controller = GetComponent<Rigidbody2D>();

        float moveHorizontal = Input.GetAxis("Horizontal" + playerNumber.ToString());
        float moveVertical = Input.GetAxis("Vertical" + playerNumber.ToString());
        

        Vector3 movment = new Vector3(moveHorizontal, moveVertical, 0);
        controller.velocity = movment * speed;

        if (Input.GetButtonDown("A"))
        {
            ren.sharedMaterial = Green;
        }
        else if (Input.GetButtonDown("B"))
        {
            ren.sharedMaterial = Red;
        }

        //Check color under player
        Debug.DrawRay(transform.position + new Vector3(0, 0, 0.4f), new Vector3(0, 0, 1));
        if (Physics.Raycast(transform.position + new Vector3(0, 0, 0.4f), new Vector3(0, 0, 1), out groundHit, 100))
        {
            if (groundHit.transform.gameObject.GetComponent<Renderer>().sharedMaterial == gameObject.GetComponent<Renderer>().sharedMaterial)
            {
                hidden = true;
            }
            else
            {
                hidden = false;
            }
        }

    }

    void Start()
    {
        ren = GetComponent<MeshRenderer>();
        ren.enabled = true;

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

}

