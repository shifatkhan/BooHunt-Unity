using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySound : MonoBehaviour
{
    public static AudioClip candyGet, candyUse;
    static AudioSource audioSrc;

    private void Awake()
    {
        candyGet = Resources.Load<AudioClip>("candy-get");
        candyUse = Resources.Load<AudioClip>("candy-use");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlayCandyGet()
    {
        audioSrc.PlayOneShot(candyGet);
    }

    public static void PlayCandyUse()
    {
        audioSrc.PlayOneShot(candyUse);
    }
}
