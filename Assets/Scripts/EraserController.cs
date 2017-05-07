using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserController : MonoBehaviour {

    public float begoneDelay;

    public AudioClip soundEffect;
    public float soundVol = 0.8f;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void EraseAndBegone()
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            //Play sound
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCameraController>().stopMusic();
            GetComponent<AudioSource>().volume = soundVol;
            GetComponent<AudioSource>().PlayOneShot(soundEffect);

            Debug.Log("Erasing: Playing animation");
            animator.SetTrigger("erase");
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + begoneDelay);
        }
        else
        {
            Debug.Log("Erasing: No animation found");
            Destroy(gameObject);
        }
    }
}
