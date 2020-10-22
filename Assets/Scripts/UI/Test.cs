using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject candyBox;
    private Vector3 newCandyPos;

    public float transitionSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (candyBox == null)
            candyBox = GameObject.FindGameObjectWithTag("Candy Box");

        newCandyPos = Camera.main.ScreenToWorldPoint(candyBox.transform.position);
        newCandyPos = new Vector3(newCandyPos.x, newCandyPos.y, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, newCandyPos, Time.deltaTime * transitionSpeed);
    }
}
