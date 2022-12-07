using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderTree : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color defaultColor;
    private Color fadeColor;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        defaultColor = sprite.color;
        fadeColor = defaultColor;
        fadeColor.a = 0.7f;
    }

    public void FadeIn()
    {
        sprite.color = defaultColor;
    }

    public void FadeOut()
    {
        sprite.color = fadeColor;
    }
}
