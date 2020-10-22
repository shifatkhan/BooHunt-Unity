using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAudio : MonoBehaviour
{
    public static AudioClip shoot1, shoot2, shoot3, shoot4, shoot5;
    static AudioSource audioSrc;

    private void Start()
    {
        shoot1 = Resources.Load<AudioClip>("laser5");
        shoot2 = Resources.Load<AudioClip>("laser6");
        shoot3 = Resources.Load<AudioClip>("laser7");
        shoot4 = Resources.Load<AudioClip>("laser8");
        shoot5 = Resources.Load<AudioClip>("laser9");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlayShoot(bool cut, float speed)
    {
        audioSrc.pitch = speed;
        int index = Random.Range(0, 5);
        switch (index)
        {
            case 0:
                if(cut)
                    audioSrc.PlayOneShot(shoot1);
                else if(!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(shoot1);
                break;
            case 1:
                if (cut)
                    audioSrc.PlayOneShot(shoot2);
                else if (!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(shoot2);
                break;
            case 2:
                if (cut)
                    audioSrc.PlayOneShot(shoot3);
                else if (!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(shoot3);
                break;
            case 3:
                if (cut)
                    audioSrc.PlayOneShot(shoot4);
                else if (!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(shoot4);
                break;
            case 4:
                if (cut)
                    audioSrc.PlayOneShot(shoot5);
                else if (!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(shoot5);
                break;
        }
        audioSrc.pitch = 1;
    }
}
