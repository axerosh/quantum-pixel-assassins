using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTextScript : MonoBehaviour {

    public Object nextLevel;
    private int textnumber = 1;
    private GUIText guitext;

    // Use this for initialization
    void Start()
    {
        guitext = GetComponentInParent<GUIText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("AJoystick") || Input.GetButtonDown("AKeyboard"))
        {
            switch (textnumber)
            {
                case 1:
                    guitext.text = "THE ONLY HOPE LEFT FOR PIXEL-KIND WAS THE BRAVE SOLDIERS OF THE UNITED\nPIXELS. THEY PUT ALL THEIR RESOURCES TOWARDS THE GREAT QUANTUM\nERASER PROJECT.THE UNITED PIXELS GATHERED ALL THE GREATEST\nQUANTUM PHYSICIST TO CREATE THE ULTIMATE WEAPON.";
                    break;
                case 2:
                    guitext.text = "THE IDEA WAS TO CREATE THE MOST DANGEROUS STEALTH WARRIORS\nTHE WORLD HAD EVER SEEN. BUT SOMETHING WENT WRONG...";
                    break;
                case 3:
                    guitext.text = "IN THE PROCESS OF CREATING THE ULTIMATE CAMOUFLAGE THE TEST SUBJECTS\nWERE ALSO QUANTUM ENTANGLED AND ALL RESEARCH WAS DESTROYED.\nONLY THE TWO BRAVE SOLDIERS WHO HAD VOLUNTEERED FOR THE EXPERIMENT\nSURVIVED THE SUB-PIXEL QUANTIFIED FORCES SET FREE.";
                    break;
                case 4:
                    guitext.text = "DESPITE THE MISHAP THE UNITED PIXELS DECIDED TO SEND OUT THESE\nSOLDIERS TO ELIMINATE THE ENEMIES OF PEACE\nAND ERASE ALL EVIL FROM THE WORLD.";
                    break;
                case 5:
                    SceneManager.LoadScene("Briefing1");
                    //SceneManager.LoadScene(nextLevel.name);
                    break;
            }

            textnumber++;

        }
    }
}
