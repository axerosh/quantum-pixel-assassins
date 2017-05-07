using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    public bool Large = false;
    
    public Sprite Black;
    public Sprite White;
    
    public Sprite LargeBlack;
    public Sprite LargeWhite;
    
    SpriteRenderer blackRen;
    SpriteRenderer whiteRen;
    GameObject eraserIcon;

    enum Visibility { Clear, Transparent, Opaque}
    private bool blackOpaque;
    private bool whiteOpaque;

    private void setAlpha(SpriteRenderer ren, float alpha)
    {
        Color tmp = ren.color;
        tmp.a = alpha;
        ren.color = tmp;
    }

    void Start ()
    {
        blackRen = GameObject.Find("Black").GetComponent<SpriteRenderer>();
        whiteRen = GameObject.Find("White").GetComponent<SpriteRenderer>();
        eraserIcon = GameObject.Find("EraserIcon");

        if (Large)
        {
            blackRen.sprite = LargeBlack;
            whiteRen.sprite = LargeWhite;
        }
        else
        {
            blackRen.sprite = Black;
            whiteRen.sprite = White;
        }

        blackOpaque = true;
        whiteOpaque = true;

        setAlpha(blackRen, 1.0f);
        setAlpha(whiteRen, 1.0f);
        
        blackRen.enabled = true;
        whiteRen.enabled = true;
        eraserIcon.SetActive(false);

    }

    public void OnPlayer1Enter()
    {
        setAlpha(blackRen, 0.5f);
        blackOpaque = false;

        if (!whiteOpaque)
        {
            eraserIcon.SetActive(true);
        }
    }

    public void OnPlayer1Exit()
    {
        setAlpha(blackRen, 1.0f);
        blackOpaque = true;
        eraserIcon.SetActive(false);
    }

    public void OnPlayer2Enter()
    {
        setAlpha(whiteRen, 0.5f);
        whiteOpaque = false;

        if (!blackOpaque)
        {
            eraserIcon.SetActive(true);
        }
    }

    public void OnPlayer2Exit()
    {
        setAlpha(whiteRen, 1.0f);
        whiteOpaque = true;
        eraserIcon.SetActive(false);
    }

    public void onPlayer1KillHold()
    {
        setAlpha(blackRen, 0.0f);
    }

    public void onPlayer1KillRelease()
    {
        if (blackOpaque)
        {
            setAlpha(blackRen, 1.0f);
        }
        else
        {
            setAlpha(blackRen, 0.5f);
        }
    }

    public void onPlayer2KillHold()
    {
        setAlpha(whiteRen, 0.0f);
    }

    public void onPlayer2KillRelease()
    {
        if (whiteOpaque)
        {
            setAlpha(whiteRen, 1.0f);
        }
        else
        {
            setAlpha(whiteRen, 0.5f);
        }
    }
}
