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
    [SerializeField]
    private float crossairRadius = 1f;

    [SerializeField]
    private LayerMask targetLayer;

    private GameManager gm;

    private void Start()
    {
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
        // Check if we hit any enemies.
        Collider2D[] objectsHit = Physics2D.OverlapCircleAll(cursorPosition, crossairRadius, targetLayer);

        int numberOfGhosts = 0; // To Check for bonus points.
        
        // Check if the player missed.
        if(objectsHit.Length <= 0 && !gm.IsInSpecialMode())
        {
            gm.score--;
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
                        // TODO: Add special key.
                    }
                }
            }

            if (numberOfGhosts >= 2)
            {
                gm.score += 5;

                foreach (Collider2D col in objectsHit)
                {
                    if (col.CompareTag("Ghost"))
                    {
                        // TODO: Spawn +5 sprite
                        // col.GetComponent<Emote>().ShowPlus5();
                        break;
                    }
                }
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
