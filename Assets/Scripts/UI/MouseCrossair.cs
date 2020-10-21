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
        
        foreach (Collider2D col in objectsHit)
        {
            if (col.CompareTag("Ghost"))
            {
                numberOfGhosts++;
                col.GetComponent<EnemyHealth>().ReceiveDamage(1);

                if (col == null || col.GetComponent<EnemyHealth>().GetCurrentHealth() <= 0)
                {
                    // TODO: Get points
                    print("Ghost shot!");
                }
            }
            else if (col.CompareTag("Witch"))
            {
                col.GetComponent<EnemyHealth>().ReceiveDamage(1);

                if(col == null || col.GetComponent<EnemyHealth>().GetCurrentHealth() <= 0)
                {
                    // TODO: Get points - Witch gives key?
                    print("Witch Shot!");
                }
            }
        }

        if(numberOfGhosts >= 2)
        {
            // TODO: Bonus 5 points.
            print("BONUS");
        }
    }

    private void OnDrawGizmos()
    {
        // Draw hitbox of the crossair.
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, crossairRadius);
    }
}
