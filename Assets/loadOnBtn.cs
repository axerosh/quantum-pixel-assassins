﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadOnBtn : MonoBehaviour {

    public Object scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("B"))
        {
            SceneManager.LoadScene(scene.name);
        }
	}
}
