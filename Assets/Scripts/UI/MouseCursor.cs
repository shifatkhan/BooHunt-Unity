using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    // Enable hold the mouse button or not.
    public bool canHold = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Hide OS cursor.
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        if(canHold)
        {
            if (Input.GetButton("Fire"))
            {
                animator.SetBool("Fire", true);
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire"))
            {
                animator.SetBool("Fire", true);
            }
        }
    }

    public void FinishClickAnimation()
    {
        animator.SetBool("Fire", false);
    }
}
