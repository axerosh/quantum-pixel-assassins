using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadOnBtn : MonoBehaviour {

    public string scene;

    public bool useB = true;
    public bool useA = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((useB && Input.GetButtonDown("Menu: Cancel")) || (useA && Input.GetButtonDown("Menu: Accept")))
        {
            SceneManager.LoadScene(scene);
        }
	}
}
