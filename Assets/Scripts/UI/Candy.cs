using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public GameObject candyBox;
    private Vector3 newCandyPos;

    public float transitionSpeed = 1f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (candyBox == null)
            candyBox = GameObject.FindGameObjectWithTag("Candy Box");

        animator = GetComponent<Animator>();

        newCandyPos = Camera.main.ScreenToWorldPoint(candyBox.transform.position);
        newCandyPos = new Vector3(newCandyPos.x, newCandyPos.y, 0);
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
