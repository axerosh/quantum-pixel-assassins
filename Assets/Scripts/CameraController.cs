using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool rotate = true;

    private bool active = true;

    public ToggleInteractible toggleInteractible;

    // Use this for initialization
    void Start()
    {
        GetComponent<Animator>().SetBool("Rotate", rotate);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update () {
        if (toggleInteractible != null && toggleInteractible.GetToggled())
        {

            this.gameObject.transform.Find("vision").gameObject.SetActive(!active);
            GetComponent<Animator>().enabled = !active;

            active = !active;
        }
    }
}
