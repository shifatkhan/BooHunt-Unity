using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Candy : MonoBehaviour
{
    [Header("UI")]
    public GameObject candyBox;
    private Vector3 newCandyPos;

    public float transitionSpeed = 1f;

    [Header("Prompt")]
    public float promptTime = 5f;
    private float startTime = 0f;
    private FadeScript fade;
    public static bool shown = false;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (candyBox == null)
            candyBox = GameObject.FindGameObjectWithTag("Candy Box");

        animator = GetComponent<Animator>();

        newCandyPos = Camera.main.ScreenToWorldPoint(candyBox.transform.position);
        newCandyPos = new Vector3(candyBox.transform.position.x, candyBox.transform.position.y, 0);

        startTime = Time.time;
        fade = GetComponentInChildren<FadeScript>();
    }

    void Update()
    {
        if(!shown && Time.time > startTime + promptTime)
        {
            fade.StartFadeIn();
            shown = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, newCandyPos, Time.deltaTime * transitionSpeed);
    }

    public void Die()
    {
        animator.SetTrigger("Die");
    }

    public void FinishedDieAnimation()
    {
        Destroy(gameObject);
    }
}
