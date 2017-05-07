using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour
{

    public GameObject[] menuOptions;
    int curSelection = 0;
    string oldText; //standard text of selected menu item

    public string Level1;
    public string Level2;
    public string Level3;
    public string Level4;
    public string Level5;
    public string Level6;
    public string Level7;
    public string Level8;


    private bool buttonReset1, buttonReset2, analogReset1, analogReset2 = true;

    // Use this for initialization
    void Start()
    {
        oldText = menuOptions[0].GetComponent<GUIText>().text;
        menuOptions[0].GetComponent<GUIText>().text = "-- " + oldText + " --";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Player 1: Move Vertical (Button/Key)") == 0 && Input.GetAxis("Player 1: Move Horizontal (Button/Key)") == 0)
        {
            buttonReset1 = true;
        }
        if (Input.GetAxis("Player 2: Move Vertical (Button/Key)") == 0 && Input.GetAxis("Player 2: Move Horizontal (Button/Key)") == 0)
        {
            buttonReset2 = true;
        }
        if (Input.GetAxis("Player 1: Move Vertical (Analog)") == 0 && Input.GetAxis("Player 1: Move Horizontal (Analog)") == 0)
        {
            analogReset1 = true;
        }
        if (Input.GetAxis("Player 2: Move Vertical (Analog)") == 0 && Input.GetAxis("Player 2: Move Horizontal (Analog)") == 0)
        {
            analogReset2 = true;
        }

        if (buttonReset1)
        {
            if (Input.GetAxis("Player 1: Move Vertical (Button/Key)") < -0.5)
            {
                buttonReset1 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis("Player 1: Move Vertical (Button/Key)") > 0.5)
            {
                buttonReset1 = false;
                moveSelection(-1);
            }
            else if (Input.GetAxis("Player 1: Move Horizontal (Button/Key)") < -0.5)
            {
                buttonReset1 = false;
                moveSelection(4);
            }
            else if (Input.GetAxis("Player 1: Move Horizontal (Button/Key)") > 0.5)
            {
                buttonReset1 = false;
                moveSelection(-4);
            }
        }
        if (buttonReset2)
        {
            if (Input.GetAxis("Player 2: Move Vertical (Button/Key)") < -0.5)
            {
                buttonReset2 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis("Player 2: Move Vertical (Button/Key)") > 0.5)
            {
                buttonReset2 = false;
                moveSelection(-1);
            }
            else if (Input.GetAxis("Player 2: Move Horizontal (Button/Key)") < -0.5)
            {
                buttonReset2 = false;
                moveSelection(4);
            }
            else if (Input.GetAxis("Player 2: Move Horizontal (Button/Key)") > 0.5)
            {
                buttonReset2 = false;
                moveSelection(-4);
            }
            if (analogReset1)
            {
                if (Input.GetAxis("Player 1: Move Vertical (Analog)") < -0.5)
                {
                    analogReset1 = false;
                    moveSelection(1);
                }
                else if (Input.GetAxis("Player 1: Move Vertical (Analog)") > 0.5)
                {
                    analogReset1 = false;
                    moveSelection(-1);
                }
                else if (Input.GetAxis("Player 1: Move Horizontal (Analog)") < -0.5)
                {
                    analogReset1 = false;
                    moveSelection(4);
                }
                else if (Input.GetAxis("Player 1: Move Horizontal (Analog)") > 0.5)
                {
                    analogReset1 = false;
                    moveSelection(-4);
                }
            }
            if (analogReset2)
            {
                if (Input.GetAxis("Player 2: Move Vertical (Analog)") < -0.5)
                {
                    analogReset2 = false;
                    moveSelection(1);
                }
                else if (Input.GetAxis("Player 2: Move Vertical (Analog)") > 0.5)
                {
                    analogReset2 = false;
                    moveSelection(-1);
                }
                else if (Input.GetAxis("Player 2: Move Horizontal (Analog)") < -0.5)
                {
                    analogReset2 = false;
                    moveSelection(4);
                }
                else if (Input.GetAxis("Player 2: Move Horizontal (Analog)") > 0.5)
                {
                    analogReset2 = false;
                    moveSelection(-4);
                }
            }


            if (Input.GetButtonDown("Menu: Accept"))
            {
                switch (curSelection)
                {
                    case 0:
                        SceneManager.LoadScene(Level1);
                        break;
                    case 1:
                        SceneManager.LoadScene(Level2);
                        break;
                    case 2:
                        SceneManager.LoadScene(Level3);
                        break;
                    case 3:
                        SceneManager.LoadScene(Level4);
                        break;
                    case 4:
                        SceneManager.LoadScene(Level5);
                        break;
                    case 5:
                        SceneManager.LoadScene(Level6);
                        break;
                    case 6:
                        SceneManager.LoadScene(Level7);
                        break;
                    case 7:
                        SceneManager.LoadScene(Level8);
                        break;
                }
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
