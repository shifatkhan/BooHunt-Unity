using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryGameObject : MonoBehaviour
{
    public bool floatAnimation = false;
    public float transitionSpeed = 1.5f;

    private void Update()
    {
        if (floatAnimation)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * transitionSpeed);
        }
    }

    public void FinishedAnimation()
    {
        Destroy(gameObject);
    }
}
