using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite idileSprite;
    public Sprite[] animationSprites;
    public float AnimationSpeed = 0.25f;
    private int AnimationFrame;
    
    public bool loop = true;
    public bool idlle = true;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled= false;
    }

    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), AnimationSpeed, AnimationSpeed);
    }

    private void NextFrame()
    {
        AnimationFrame++;
        if (loop && AnimationFrame >= animationSprites.Length)
        {
            AnimationFrame = 0;
        }

        if (idlle)  
        {
            spriteRenderer.sprite = idileSprite;
        } 
        else if (AnimationFrame >= 0 && AnimationFrame < animationSprites.Length)
        {
            spriteRenderer.sprite = animationSprites[AnimationFrame];
        }
    }
}
