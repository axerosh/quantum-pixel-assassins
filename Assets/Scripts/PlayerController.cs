﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool hidden;

    public Material Red;
    public Material Green;

    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

    MeshRenderer ren;

    void Start()
    {
        ren = GetComponent<MeshRenderer>();
        ren.enabled = true;
    }

    void Update()
    {
        Rigidbody2D controller = GetComponent<Rigidbody2D>();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movment = new Vector3(moveHorizontal, moveVertical, 0);
        controller.velocity = movment * speed;


        if (Input.GetButtonDown("A"))
        {
            ren.sharedMaterial = Green;
        }else if (Input.GetButtonDown("B"))
        {
            ren.sharedMaterial = Red;
        }
    }

}