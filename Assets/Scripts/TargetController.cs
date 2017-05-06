using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    public bool Large = false;

    public Sprite Base;
    public Sprite Black;
    public Sprite White;

    public Sprite LargeBase;
    public Sprite LargeBlack;
    public Sprite LargeWhite;

    public Sprite Knife;

    SpriteRenderer baseRen;
    SpriteRenderer blackRen;
    SpriteRenderer whiteRen;
    GameObject eraserIcon;
    
    void Start ()
    {
        baseRen = GameObject.Find("Base").GetComponent<SpriteRenderer>();
        blackRen = GameObject.Find("Black").GetComponent<SpriteRenderer>();
        whiteRen = GameObject.Find("White").GetComponent<SpriteRenderer>();
        eraserIcon = GameObject.Find("EraserIcon");

        if (Large)
        {
            baseRen.sprite = LargeBase;
            blackRen.sprite = LargeBlack;
            whiteRen.sprite = LargeWhite;
        }
        else
        {
            baseRen.sprite = Base;
            blackRen.sprite = Black;
            whiteRen.sprite = White;
        }
        
        baseRen.enabled = true;
        blackRen.enabled = true;
        whiteRen.enabled = true;
        eraserIcon.SetActive(false);

    }

    public void OnPlayer1Enter()
    {
        blackRen.enabled = false;
        if (!whiteRen.enabled)
        {
            eraserIcon.SetActive(true);
        }
    }

    public void OnPlayer1Exit()
    {
        blackRen.enabled = true;
        eraserIcon.SetActive(false);
    }

    public void OnPlayer2Enter()
    {
        whiteRen.enabled = false;
        if (!blackRen.enabled)
        {
            eraserIcon.SetActive(true);
        }
    }

    public void OnPlayer2Exit()
    {
        whiteRen.enabled = true;
        eraserIcon.SetActive(false);
    }
}
