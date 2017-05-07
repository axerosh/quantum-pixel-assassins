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
    public Object Level4;
    public Object Level5;
    public Object Level6;
    public Object Level7;
    public Object Level8;
    public Object Level9;
    public Object Level10;

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
        if (Input.GetAxis("Vertical1") == 0 && Input.GetAxis("Horizontal1") == 0)
        {
            joyReset1 = true;
        }
        if (Input.GetAxis("Vertical2") == 0 && Input.GetAxis("Horizontal2") == 0)
        {
            joyReset2 = true;
        }

        if (joyReset1)
        {
            if (Input.GetAxis("Vertical1") < -0.5)
            {
                joyReset1 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis("Vertical1") > 0.5)
            {
                joyReset1 = false;
                moveSelection(-1);
            }
            else if (Input.GetAxis("Horizontal1") < -0.5)
            {
                joyReset1 = false;
                moveSelection(5);
            }
            else if (Input.GetAxis("Horizontal1") > 0.5)
            {
                joyReset1 = false;
                moveSelection(-5);
            }
        }
        if (joyReset2)
        {
            if (Input.GetAxis("Vertical2") < -0.5)
            {
                joyReset2 = false;
                moveSelection(1);
            }
            else if (Input.GetAxis("Vertical2") > 0.5)
            {
                joyReset2 = false;
                moveSelection(-1);
            }
            else if (Input.GetAxis("Horizontal2") < -0.5)
            {
                joyReset2 = false;
                moveSelection(5);
            }
            else if (Input.GetAxis("Horizontal2") > 0.5)
            {
                joyReset2 = false;
                moveSelection(-5);
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
                    SceneManager.LoadScene(Level4.name);
                    break;
                case 4:
                    SceneManager.LoadScene(Level5.name);
                    break;
                case 5:
                    SceneManager.LoadScene(Level6.name);
                    break;
                case 6:
                    SceneManager.LoadScene(Level7.name);
                    break;
                case 7:
                    SceneManager.LoadScene(Level8.name);
                    break;
                case 8:
                    SceneManager.LoadScene(Level9.name);
                    break;
                case 9:
                    SceneManager.LoadScene(Level10.name);
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
