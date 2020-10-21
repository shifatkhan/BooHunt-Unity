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

/// <summary>
/// This script takes care of enemy AI (movement). The gist of it is that 
/// it will have a general direction (enum Direction) but once in awhile it will
/// move in other directions (referred to as a Random Movement)
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float speed = 1.5f;
    private float initialSpeed = 1.5f;

    [SerializeField]
    private Direction moveDir = Direction.RIGHT; // Initial Direction of the enemy.
    private Vector3 movement = new Vector3(); // Movement direction.

    // Vars for random movement AI
    private float nextActionTime = 0.0f;
    private float period = 1.0f;
    private bool movingRandomly = false;
    private float randomMovementDuration = 1f; // Duration of the random movement.

    private FadeScript fadeIn;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        fadeIn = GetComponent<FadeScript>();
        if (fadeIn != null)
            fadeIn.StartFadeIn();

        initialSpeed = speed;
        ResetDirection();
        randomMovementDuration = GetRandomMovementDuration(speed);
    }

    void Update()
    {
        // Check if it's time to perform a random movement.
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

    /// <summary>
    /// Move at a random direction for a certain period of time.
    /// </summary>
    /// <param name="duration">Duration of this random movement.</param>
    /// <returns></returns>
    IEnumerator MoveRandomly(float duration)
    {
        float timePassed = 0;
        movingRandomly = true;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;

            yield return null;
        }

        movingRandomly = false;
        period = Random.Range(0.5f, 3);
        ResetDirection();
    }

    public void SetDirection(Direction newDir)
    {
        this.moveDir = newDir;
    }

    /// <summary>
    /// Sets the movement Vector3 to the enum Direction.
    /// </summary>
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

    /// <summary>
    /// Assigns a random movement direction.
    /// If the movement is 'backwards', we assign it a shorter duration
    /// because we don't want the enemy to stay too long on the screen.
    /// </summary>
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

    /// <summary>
    /// Generates a random movement Duration based on a given seed.
    /// The bigger the seed, the lower the movement duration (because
    /// we use Speed as our seed).
    /// </summary>
    /// <param name="seed"></param>
    /// <returns></returns>
    public float GetRandomMovementDuration(float seed)
    {
        return Random.Range(0.3f, 1.5f / seed < 0.2f ? 1 : 1.5f / seed);
    }

    public float GetSpeed()
    {
        return speed;
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
