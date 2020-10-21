using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** States which direction the enmy will move towards.
 * For example, if the enemy is spawned from the bottom, it will
 * move UP until it is out of the screen.
 */
public enum Direction
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;
    private float initialSpeed = 1.5f;

    public Direction moveDir = Direction.RIGHT; // Initial Direction of the enemy.
    public Vector3 movement = new Vector3(); // Movement direction.

    // Vars for random movement AI
    private float nextActionTime = 0.0f;
    private float period = 1.0f;
    private bool movingRandomly = false;
    public float randomMovementDuration = 1f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        initialSpeed = speed;
        ResetDirection();
        randomMovementDuration = GetRandomMovementDuration(speed);
    }

    void Update()
    {
        if (Time.time > nextActionTime && !movingRandomly)
        {
            nextActionTime += period;

            GenerateRandomMovement();
            StartCoroutine(MoveRandomly(randomMovementDuration));
        }

        // Set animator vars
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        // Move
        transform.position = transform.position + movement * speed * Time.deltaTime;
    }

    IEnumerator MoveRandomly(float duration)
    {
        float timePassed = 0;
        movingRandomly = true;

        while (timePassed < duration)
        {
            // Code to go left here
            timePassed += Time.deltaTime;

            yield return null;
        }

        movingRandomly = false;
        period = Random.Range(0.5f, 3);
        ResetDirection();
    }

    public void ResetDirection()
    {
        switch (moveDir)
        {
            case Direction.UP:
                movement = new Vector3(0, 1);
                break;
            case Direction.DOWN:
                movement = new Vector3(0, -1);
                break;
            case Direction.LEFT:
                movement = new Vector3(-1, 0);
                break;
            case Direction.RIGHT:
                movement = new Vector3(1, 0);
                break;
            default:
                print("Error: Invalid enemy Directrion enum.");
                break;
        }
    }

    public void GenerateRandomMovement()
    {
        // Get a new random direction.
        int x = Random.Range(-1, 2);
        int y = Random.Range(-1, 2);

        // Make backwards movements shorter.
        if((moveDir == Direction.UP && y < 0) || (moveDir == Direction.DOWN && y > 0) ||
            (moveDir == Direction.RIGHT && x < 0) || (moveDir == Direction.LEFT && x > 0))
        {
            randomMovementDuration = GetRandomMovementDuration(speed * 2f);
        }

        movement = new Vector3(x, y);
    }

    public float GetRandomMovementDuration(float seed)
    {
        return Random.Range(0.3f, 1.5f / seed < 0.2f ? 1 : 1.5f / seed);
    }

    public void SetSpeed(float speed)
    {
        if(speed <= 0)
        {
            print("Error: Speed can't be negative!");
            return;
        }

        this.speed = speed;
    }
}
