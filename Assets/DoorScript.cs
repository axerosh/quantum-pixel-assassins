using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public ToggleInteractible toggleInteractible;
    public int a;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (toggleInteractible.GetToggled())
        {
            Toggle();
        }
	}

    public void Toggle()
    {
        transform.Rotate(0, 0, 90);
    }
}
