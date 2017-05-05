using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool hidden;

    public Color color;
    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);



        if (Input.GetButtonDown("A"))
        {
            
        }else if (Input.GetButtonDown("A"))
        {

        }
    }

}
