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
    protected Vector2 cursorPosition;

    protected Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Hide OS cursor.
        Cursor.visible = false;
    }

    void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        if(canHold)
        {
            if (Input.GetButton("Left Click"))
            {
                HandleLeftClick();
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
        // TODO: Add cursor click sound
    }

    public void FinishLeftClickAnimation()
    {
        animator.SetBool("Left Click", false);
    }
}
