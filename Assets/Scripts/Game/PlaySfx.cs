using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySfx : MonoBehaviour
{
    public bool playOnAwake = false;
    public int indexToPlayOnAwake = 0;

    public AudioSource[] audioSrc;

    private void Awake()
    {
        if (playOnAwake)
        {
            SetPitch(indexToPlayOnAwake, Random.Range(0.85f, 1.15f));
            Play(indexToPlayOnAwake);
        }
    }

    public void Play(int index)
    {
        if(index >= 0 && index < audioSrc.Length)
            audioSrc[index].Play();
    }

    public void SetPitch(int index,  float pitch)
    {
        if (index >= 0 && index < audioSrc.Length)
            audioSrc[index].pitch = pitch;
    }
}
