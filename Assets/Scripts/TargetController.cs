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
    SpriteRenderer knifeRen;
    
    void Start ()
    {
        baseRen = GameObject.Find("Base").GetComponent<SpriteRenderer>();
        blackRen = GameObject.Find("Black").GetComponent<SpriteRenderer>();
        whiteRen = GameObject.Find("White").GetComponent<SpriteRenderer>();
        knifeRen = GameObject.Find("Black").GetComponent<SpriteRenderer>();

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

        //knifeRen.sprite = ???

        baseRen.enabled = true;
        blackRen.enabled = false;
        whiteRen.enabled = false;
        knifeRen.enabled = false;
    }

    public void OnPlayer1Enter()
    {
        blackRen.enabled = true;
        if (whiteRen.enabled)
        {
            knifeRen.enabled = true;
        }
    }

    public void OnPlayer1Exit()
    {
        blackRen.enabled = false;
        knifeRen.enabled = false;
    }

    public void OnPlayer2Enter()
    {
        whiteRen.enabled = true;
        if (blackRen.enabled)
        {
            knifeRen.enabled = true;
        }
    }

    public void OnPlayer2Exit()
    {
        whiteRen.enabled = false;
        knifeRen.enabled = false;
    }
}
