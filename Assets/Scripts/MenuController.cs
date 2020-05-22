using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject[] menuOptions;
    int curSelection = 0;
    string oldText; //standard text of selected menu item

    public Object instructions;
    public Object levelSelect;
    public Object firstLevel;

    private bool buttonReset1, buttonReset2, analogReset1, analogReset2, analogAltReset1, analogAltReset2 = true;

    // Use this for initialization
    void Start()
    {
        //Screen.SetResolution(1920, 1080, false);
        oldText = menuOptions[0].GetComponent<GUIText>().text;
        menuOptions[0].GetComponent<GUIText>().text = "-- " + oldText + " --";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis(InputNames.GetName("p1 vertical key")) == 0)
        {
            buttonReset1 = true;
        }
        if (Input.GetAxis(InputNames.GetName("p2 vertical key")) == 0)
        {
            buttonReset2 = true;
        }

        if (Input.GetAxis(InputNames.GetName("p1 vertical axis")) == 0)
        {
            analogReset1 = true;
        }
        if (Input.GetAxis(InputNames.GetName("p2 vertical axis")) == 0)
        {
            analogReset2 = true;
        }

        if (Input.GetAxis(InputNames.GetName("p1 vertical axis alt")) == 0)
        {
            analogAltReset1 = true;
        }
        if (Input.GetAxis(InputNames.GetName("p2 vertical axis alt")) == 0)
        {
            analogAltReset2 = true;
        }

        if (buttonReset1)
        {
            if (Input.GetAxis(InputNames.GetName("p1 vertical key")) < -0.5)
            {
                buttonReset1 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis(InputNames.GetName("p1 vertical key")) > 0.5)
            {
                buttonReset1 = false;
                moveSelection(-1);
            }
        }
        if (buttonReset2)
        {
            if (Input.GetAxis(InputNames.GetName("p2 vertical key")) < -0.5)
            {
                buttonReset2 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis(InputNames.GetName("p2 vertical key")) > 0.5)
            {
                buttonReset2 = false;
                moveSelection(-1);
            }
        }

        if (analogReset1)
        {
            if (Input.GetAxis(InputNames.GetName("p1 vertical axis")) < -0.5)
            {
                analogReset1 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis(InputNames.GetName("p1 vertical axis")) > 0.5)
            {
                analogReset1 = false;
                moveSelection(-1);
            }
        }
        if (analogReset2)
        {
            if (Input.GetAxis(InputNames.GetName("p2 vertical axis")) < -0.5)
            {
                analogReset2 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis(InputNames.GetName("p2 vertical axis")) > 0.5)
            {
                analogReset2 = false;
                moveSelection(-1);
            }
        }

        if (analogAltReset1)
        {
            if (Input.GetAxis(InputNames.GetName("p1 vertical axis alt")) < -0.5)
            {
                analogAltReset1 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis(InputNames.GetName("p1 vertical axis alt")) > 0.5)
            {
                analogAltReset1 = false;
                moveSelection(-1);
            }
        }
        if (analogAltReset2)
        {
            if (Input.GetAxis(InputNames.GetName("p2 vertical axis alt")) < -0.5)
            {
                analogAltReset2 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis(InputNames.GetName("p2 vertical axis alt")) > 0.5)
            {
                analogAltReset2 = false;
                moveSelection(-1);
            }
        }


        if (Input.GetButtonDown(InputNames.GetName("accept")))
        {
            switch (curSelection)
            {
                case 0:
                    //SceneManager.LoadScene(firstLevel.name);
                    SceneManager.LoadScene("Intro1");
                    break;
                case 1:
                    //SceneManager.LoadScene(levelSelect.name);
                    SceneManager.LoadScene("Level Select");
                    break;
                case 2:
                    //SceneManager.LoadScene(instructions.name);
                    SceneManager.LoadScene("Instructions");
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
