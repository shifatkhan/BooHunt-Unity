using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ghost") || collision.CompareTag("Witch"))
        {
            Destroy(collision.gameObject);

            if (gm.IsInSpecialMode())
            {
                gm.score -= 2;
            }
        }
    }
}
