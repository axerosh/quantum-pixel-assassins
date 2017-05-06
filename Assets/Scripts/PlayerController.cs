using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool hidden;
    public int playerNumber;

    MeshRenderer ren;

    public Material Red;
    public Material Green;

    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

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

    }

    void Start()
    {
        ren = GetComponent<MeshRenderer>();
        ren.enabled = true;
    }

}
