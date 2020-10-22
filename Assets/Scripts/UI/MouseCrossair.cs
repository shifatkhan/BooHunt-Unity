using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inherits MouseCursor for all the base functionality, but we
/// add raycastHit to this script to see if we hit an enemy.
/// It also supports holding the button from the parent script.
/// 
/// @author ShifatKhan
/// </summary>
public class MouseCrossair : MouseCursor
{
    [Header("Crosshair vars")]
    [SerializeField]
    private float crossairRadius = 1f;

    [SerializeField]
    private LayerMask targetLayer;

    private GameManager gm;

    [Header("Prefabs")]
    public GameObject candyPrefab;
    public Laugh vampire;

    protected override void Start()
    {
        base.Start();
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    protected override void HandleLeftClick()
    {
        base.HandleLeftClick();
        ShootEnemy();
    }
    protected override void HandleLeftClickDown()
    {
        base.HandleLeftClick();
        ShootEnemy();
    }

    private void ShootEnemy()
    {
        if (gm.IsInSpecialMode())
        {
            canHold = true;
        }
        else
        {
            canHold = false;
        }

        // Check if we hit any enemies.
        Collider2D[] objectsHit = Physics2D.OverlapCircleAll(cursorPosition, crossairRadius, targetLayer);

        int numberOfGhosts = 0; // To Check for bonus points.
        
        // Check if the player missed.
        if(objectsHit.Length <= 0 && !gm.IsInSpecialMode())
        {
            gm.score--;

            if(!vampire.laughing)
                vampire.StartLaugh();
        }
        else
        {
            foreach (Collider2D col in objectsHit)
            {
                if (col.CompareTag("Ghost"))
                {
                    numberOfGhosts++;
                    col.GetComponent<EnemyHealth>().ReceiveDamage(1);

                    if (col == null || col.GetComponent<EnemyHealth>().GetCurrentHealth() <= 0)
                    {
                        if (gm.IsInSpecialMode())
                        {
                            gm.score += 1;
                        }
                        else
                        {
                            gm.score += 3;
                        }
                    }
                }
                else if (col.CompareTag("Witch"))
                {
                    col.GetComponent<EnemyHealth>().ReceiveDamage(1);

                    if (col == null || col.GetComponent<EnemyHealth>().GetCurrentHealth() <= 0)
                    {
                        gm.score += 3;

                        if(!gm.candyAcquired)
                        {
                            // Drop candy for special mode.
                            Vector3 worldPos = new Vector3(cursorPosition.x, cursorPosition.y, 0);
                            gm.candy = Instantiate(candyPrefab, cursorPosition, Quaternion.identity);
                            gm.candyAcquired = true;
                        }
                    }
                }
            }

            if (numberOfGhosts >= 2)
            {
                gm.score += 5;

                // TODO: Spawn +5 sprite
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Draw hitbox of the crossair.
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, crossairRadius);
    }
}
