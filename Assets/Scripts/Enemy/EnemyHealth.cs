using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int totalHealth = 1;
    private int currentHealth = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            // TODO: Die
            Destroy(gameObject);
        }
    }

    public void ReceiveDamage(int damage)
    {
        currentHealth -= damage;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
