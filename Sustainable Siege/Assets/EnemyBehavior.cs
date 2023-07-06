using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    public Animator enemyAnimator;

    private bool isAttacking = false; // Flag to indicate if the enemy is attacking
    private bool canAttack = true; // Flag to determine if the enemy can attack
    private float attackTimer = 1f; // Timer to determine when the enemy can attack again

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            Vector3 movement = new Vector3(0f, 0f, speed * Time.deltaTime);
            enemyRb.MovePosition(transform.position + movement);
        }
    }

    private void Update()
    {
        if (isAttacking && !canAttack)
        {
            // Reduce the attack timer
            attackTimer -= Time.deltaTime;

            // Check if the attack cooldown has finished
            if (attackTimer <= 0f)
            {
                canAttack = true;
                attackTimer = 1f; // Reset the attack timer
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") && !isAttacking && canAttack)
        {
            isAttacking = true;
            canAttack = false;

            enemyRb.velocity = Vector3.zero;
            // Trigger the enemy's attack animation using the animator
            //enemyAnimator.SetTrigger("enemyAttack");

            StartCoroutine(AttackWall(collision.gameObject.GetComponent<WallProperty>()));
        }
    }

    private IEnumerator AttackWall(WallProperty wall)
    {
    if (wall == null)
    {
        // Wall object is missing or has been destroyed
        isAttacking = false;
        yield break;
    }

    while (!wall.IsDestroyed())
    {
        // Deal damage to the wall
        wall.TakeDamage(10);

        yield return new WaitForSeconds(1f); // Wait for 1 second before the next attack
    }

    // Resume movement when the wall is destroyed
    ResumeMovement();
    }


    private void ResumeMovement()
    {
        isAttacking = false;
        enemyRb.velocity = new Vector3(0f, 0f, speed);
    }
}