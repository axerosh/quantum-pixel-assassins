using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject[] menuOptions;
    int curSelection = 0;
    string oldText; //standard text of selected menu item

    public Object instructions;
    public Object levelSelect;
    public Object firstLevel;

    private bool joyReset = true;

	// Use this for initialization
	void Start () {
        oldText = menuOptions[0].GetComponent<GUIText>().text;
        menuOptions[0].GetComponent<GUIText>().text = "-- " + oldText + " --";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical1") == 0)
        {
            joyReset = true;
        }

        if (joyReset)
        {
            if (Input.GetAxis("Vertical1") < -0.5 || Input.GetAxis("Vertical2") < -0.5)
            {
                joyReset = false;
                moveSelection(1);
            }
            else if (Input.GetAxis("Vertical1") > 0.5 || Input.GetAxis("Vertical2") > 0.5)
            {
                joyReset = false;
                moveSelection(-1);
            }
        }

        if (Input.GetButtonDown("A"))
        {
            switch (curSelection)
            {
                case 0:
                    SceneManager.LoadScene(firstLevel.name);
                break;
                case 1:
                    SceneManager.LoadScene(levelSelect.name);
                break;
                case 2:
                    SceneManager.LoadScene(instructions.name);
                    break;
                case 3:
                    Application.Quit();
                break;
            }
        }
	}

    void moveSelection(int deltaY)
    {
        menuOptions[curSelection].GetComponent<GUIText>().text = oldText;

        curSelection = (curSelection + deltaY + menuOptions.Length) % menuOptions.Length;

        oldText = menuOptions[curSelection].GetComponent<GUIText>().text;
        menuOptions[curSelection].GetComponent<GUIText>().text = "-- " + oldText + " --";
    }
}
