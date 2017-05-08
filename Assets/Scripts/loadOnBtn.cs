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
        if ((useA && Input.GetButtonDown(InputNames.GetName("accept"))) || (useB && Input.GetButtonDown(InputNames.GetName("cancel"))))
        {
            SceneManager.LoadScene(scene);
        }
	}
}
