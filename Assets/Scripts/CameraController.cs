using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool rotate = true;

    // Use this for initialization
    void Start()
    {
        GetComponent<Animator>().SetBool("Rotate", rotate);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
