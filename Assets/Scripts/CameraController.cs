using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool rotate = true;
    public bool active = false;
    public bool isDisableble = false;

    public ToggleInteractible toggleInteractible;

    // Use this for initialization
    void Start()
    {
        GetComponent<Animator>().SetBool("Rotate", rotate);
        this.gameObject.transform.Find("vision").gameObject.SetActive(active);
        GetComponent<Animator>().enabled = active;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update () {
        if((this.gameObject.transform.Find("vision").gameObject.activeSelf && isDisableble) || !this.gameObject.transform.Find("vision").gameObject.activeSelf)
        if (toggleInteractible != null && toggleInteractible.GetToggled())
        {

            this.gameObject.transform.Find("vision").gameObject.SetActive(!active);
            GetComponent<Animator>().enabled = !active;

            active = !active;
        }
    }
}
