using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorController : MonoBehaviour {

    public ToggleInteractible btn;

    public GameObject Door1, Door2;
    public GameObject Target1, Target2;

    public Vector3 initPos1, initPos2;

    public float doorSpeed = 10;

    private bool open = false;
    private bool opening = false;
    private bool closing = false;

    // Use this for initialization
    void Start() {
        initPos1 = Door1.transform.position;
        initPos2 = Door2.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (btn.GetToggled())
        {
            toggleOpen();
        }

        if (opening)
        {
            Door1.transform.position = Vector3.MoveTowards(Door1.transform.position, Target1.transform.position, doorSpeed*Time.deltaTime);
            Door2.transform.position = Vector3.MoveTowards(Door2.transform.position, Target2.transform.position, doorSpeed * Time.deltaTime);
            if (Door2.transform.position == Target2.transform.position)
            {
                opening = false;
            }
        }
        if (closing)
        {
            Door1.transform.position = Vector3.MoveTowards(Door1.transform.position, initPos1, doorSpeed * Time.deltaTime);
            Door2.transform.position = Vector3.MoveTowards(Door2.transform.position, initPos2, doorSpeed * Time.deltaTime);
            if (Door2.transform.position == initPos2)
            {
                closing = false;
            }
        }
    }

    void toggleOpen(){
        if (open)
        {
            opening = false;
            closing = true;
            open = false;
        }
        else
        {
            opening = true;
            closing = false;
            open = true;
        }
    }

}
