using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laugh : MonoBehaviour
{
    public static AudioClip laugh1, laugh2;
    static AudioSource audioSrc;

    private Animator animator;
    public bool laughing { get; private set; }

    private void Start()
    {
        animator = GetComponent<Animator>();

        laugh1 = Resources.Load<AudioClip>("laugh1");
        laugh2 = Resources.Load<AudioClip>("laugh2");

        audioSrc = GetComponent<AudioSource>();
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

    public void PlayLaughSound()
    {
        PlayLaugh(true, 1);
    }
    public static void PlayLaugh(bool cut, float speed)
    {
        int index = Random.Range(0, 2);

        switch (index)
        {
            case 0:
                audioSrc.PlayOneShot(laugh1);
                break;
            case 1:
                audioSrc.pitch = 2;
                audioSrc.PlayOneShot(laugh2);
                break;
        }
        audioSrc.pitch = 1;
    }
}
