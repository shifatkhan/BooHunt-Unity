using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows us to fade in a game object's sprite.
/// 
/// TODO: Add fade out?
/// </summary>
public class FadeScript : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        // Initialize sprite to be invisible.
        Color spriteColor = spriteRenderer.material.color;
        spriteColor.a = 0f;
        spriteRenderer.material.color = spriteColor;
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        for (float i = 0.05f; i <= 1; i += 0.05f)
        {
            Color spriteColor = spriteRenderer.material.color;
            spriteColor.a = i;
            spriteRenderer.material.color = spriteColor;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
