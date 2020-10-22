using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles custom mouse cursor animations and clicks.
/// We can define whether we accept holding the mouse button
/// or not.
/// 
/// @author ShifatKhan
/// </summary>
public class MouseCursor : MonoBehaviour
{
    // Enable hold the mouse button or not.
    public bool canHold = false;
    public float holdFireRate = 0.2f;
    private float nextFireTime = 0;
    protected Vector2 cursorPosition;

    protected Animator animator;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();

        nextFireTime = Time.time;

        // Hide OS cursor.
        Cursor.visible = false;
    }

    protected virtual void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        if(canHold)
        {
            if (Time.time > nextFireTime)
            {
                nextFireTime += holdFireRate;

                if (Input.GetButton("Left Click"))
                {
                    HandleLeftClick();
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Left Click"))
            {
                HandleLeftClickDown();
            }
        }
    }

    protected virtual void HandleLeftClick()
    {
        animator.SetBool("Left Click", true);
    }

    protected virtual void HandleLeftClickDown()
    {
        animator.SetBool("Left Click", true);
    }

    public void PlayLeftClickSound()
    {

    }

    public void FinishLeftClickAnimation()
    {
        animator.SetBool("Left Click", false);
    }
}
