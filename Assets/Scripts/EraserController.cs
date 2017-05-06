using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserController : MonoBehaviour {

    public float begoneDelay;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void eraseAndBegone()
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.SetTrigger("erase");
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + begoneDelay);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
