using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{

    [SerializeField]
    private float hitStopDuration = 0.1f;

    private Shader defaultShader;
    private Shader hitShader;
    private bool hitStopped;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Hit stop color
        defaultShader = spriteRenderer.material.shader;
        hitShader = Shader.Find("GUI/Text Shader"); // For all white sprite on Hit
    }

    /// <summary>
    /// Applies a hit stop effect when hit by making the sprite White (flash) 
    /// and stopping time.
    /// We then call a coroutine to reset.
    /// </summary>
    public void StartHitStop()
    {
        spriteRenderer.material.shader = hitShader;
        spriteRenderer.material.color = Color.white;

        if (hitStopped)
            return;
        Time.timeScale = 0.0f;
        StartCoroutine(HitWait(hitStopDuration));
    }

    /// <summary>
    /// Resets the hit stop so the sprite and timeScale goes back to normal.
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    public IEnumerator HitWait(float duration)
    {
        hitStopped = true;
        yield return new WaitForSecondsRealtime(duration);
        spriteRenderer.material.shader = defaultShader;
        spriteRenderer.material.color = Color.white;
        Time.timeScale = 1.0f;
        hitStopped = false;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1.0f;
    }
}
