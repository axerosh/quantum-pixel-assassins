using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEntangled : MonoBehaviour {

    public GameObject b1, b2;

    public Material green, red;

    public int maxSwap = 8;

    private bool isGreen = false;

	// Use this for initialization
	void Start () {
        swapMaterial();

        Invoke("swapMaterial", maxSwap * Random.value);
	}
	
    void swapMaterial()
    {
        if (isGreen)
        {
            b1.GetComponent<Renderer>().sharedMaterial = red;
            b2.GetComponent<Renderer>().sharedMaterial = red;
            isGreen = false;
        }
        else
        {
            b1.GetComponent<Renderer>().sharedMaterial = green;
            b2.GetComponent<Renderer>().sharedMaterial = green;
            isGreen = true;
        }

        Invoke("swapMaterial", maxSwap * Random.value);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
