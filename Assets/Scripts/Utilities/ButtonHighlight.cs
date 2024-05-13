using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite highlightSprite;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        spriteRenderer.sprite = highlightSprite;
    }

    void OnMouseExit()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
