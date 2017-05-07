﻿using System.Collections;
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


    private bool joyReset1, joyReset2 = true;

    // Use this for initialization
    void Start()
    {
        oldText = menuOptions[0].GetComponent<GUIText>().text;
        menuOptions[0].GetComponent<GUIText>().text = "-- " + oldText + " --";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("VerticalKeyboard1") < 0 || Input.GetAxis("VerticalKeyboard2") < 0)
        {
            moveSelection(1);
        }
        else if (Input.GetAxis("VerticalKeyboard1") > 0 || Input.GetAxis("VerticalKeyboard2") > 0)
        {
            moveSelection(-1);
        }
        else if (Input.GetAxis("VerticalKeyboard1") < 0 || Input.GetAxis("VerticalKeyboard2") < 0)
        {
            moveSelection(4);
        }
        else if (Input.GetAxis("VerticalKeyboard1") > 0 || Input.GetAxis("VerticalKeyboard2") > 0)
        {
            moveSelection(-4);
        }

        if (Input.GetAxis("VerticalController1") == 0 && Input.GetAxis("HorizontalController1") == 0)
        {
            joyReset1 = true;
        }
        if (Input.GetAxis("VerticalController2") == 0 && Input.GetAxis("HorizontalController2") == 0)
        {
            joyReset2 = true;
        }

        if (joyReset1)
        {
            if (Input.GetAxis("VerticalController1") < -0.5 || Input.GetAxis("VerticalController1") < -0.5)
            {
                joyReset1 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis("VerticalController1") > 0.5)
            {
                joyReset1 = false;
                moveSelection(-1);
            }
            else if (Input.GetAxis("HorizontalController1") < -0.5)
            {
                joyReset1 = false;
                moveSelection(4);
            }
            else if (Input.GetAxis("HorizontalController1") > 0.5)
            {
                joyReset1 = false;
                moveSelection(-4);
            }
        }
        if (joyReset2)
        {
            if (Input.GetAxis("VerticalController2") < -0.5)
            {
                joyReset2 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis("VerticalController2") > 0.5)
            {
                joyReset2 = false;
                moveSelection(-1);
            }
            else if (Input.GetAxis("HorizontalController2") < -0.5)
            {
                joyReset2 = false;
                moveSelection(4);
            }
            else if (Input.GetAxis("HorizontalController2") > 0.5)
            {
                joyReset2 = false;
                moveSelection(-4);
            }
        }


        if (Input.GetButtonDown("AController") || Input.GetButtonDown("AKeyboard"))
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

    void moveSelection(int deltaY)
    {
        menuOptions[curSelection].GetComponent<GUIText>().text = oldText;

        curSelection = (curSelection + deltaY + menuOptions.Length) % menuOptions.Length;

        oldText = menuOptions[curSelection].GetComponent<GUIText>().text;
        menuOptions[curSelection].GetComponent<GUIText>().text = "-- " + oldText + " --";
    }
}
