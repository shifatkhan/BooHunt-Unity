using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int totalHealth = 1;
    private int currentHealth = 1;

    private HitStop hitStop;

    public GameObject deathFX;

    // Start is called before the first frame update
    void Start()
    {
        hitStop = GetComponent<HitStop>();

        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Instantiate(deathFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void ReceiveDamage(int damage)
    {
        if(hitStop != null)
            hitStop.StartHitStop();

        currentHealth -= damage;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
