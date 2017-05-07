using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelScript : MonoBehaviour {

    public Object nextLevel;

    

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        GameObject eraser = GameObject.Find("Eraser");

        GameObject targetArea = GameObject.Find("TargerArea");

        if (!targetArea && !eraser)
        {
            if (nextLevel != null)
            {
                SceneManager.LoadScene(nextLevel.name);
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }

        }


    }
}
