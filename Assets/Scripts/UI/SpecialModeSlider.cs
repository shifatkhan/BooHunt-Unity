using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class SpecialModeSlider : MonoBehaviour
{
    private GameManager gm;
    public Slider slider;
    private ParticleSystem particleSys;

    private bool started = false;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        slider = GetComponentInChildren<Slider>();
        particleSys = GetComponentInChildren<ParticleSystem>();
        
        ParticleSystem.MainModule main = particleSys.main;
        main.startColor = Color.red;

        ResetSlider();
        slider.gameObject.SetActive(false);
    }

    void Update()
    {
        if (started)
        {
            slider.value -= Time.deltaTime;
            if(!particleSys.isPlaying)
                particleSys.Play();
            if (slider.value <= 0)
                started = false;
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
    }

    public void StartSlider()
    {
        slider.gameObject.SetActive(true);
        started = true;
        ResetSlider();
    }

    public void ResetSlider()
    {
        slider.maxValue = gm.GetSpecialModeDuration();
        slider.value = slider.maxValue;
    }
}
