using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laugh : MonoBehaviour
{
    private Animator animator;
    public bool laughing { get; private set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartLaugh()
    {
        laughing = true;
        animator.SetTrigger("Laugh");
    }

    public void StopLaughing()
    {
        laughing = false;
    }
}
