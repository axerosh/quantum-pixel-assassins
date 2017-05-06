using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour
{

    public GameObject[] menuOptions;
    int curSelection = 0;
    string oldText; //standard text of selected menu item

    public Object Level1;
    public Object Level2;
    public Object Level3;
    public Object Back;

    private bool joyReset = true;

    // Use this for initialization
    void Start()
    {
        oldText = menuOptions[0].GetComponent<GUIText>().text;
        menuOptions[0].GetComponent<GUIText>().text = "-- " + oldText + " --";
    }

    // Update is called once per frame
    void Update()
    {
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
                    SceneManager.LoadScene(Level1.name);
                    break;
                case 1:
                    SceneManager.LoadScene(Level2.name);
                    break;
                case 2:
                    SceneManager.LoadScene(Level3.name);
                    break;
                case 3:
                    SceneManager.LoadScene(Back.name);
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
