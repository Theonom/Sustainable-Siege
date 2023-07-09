using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed, attackInterval;
    public int attackDamage;
    public float hpEnemy;

    private GameObject gameController, player;
    private Animator animator;
    private int attack;
    private float timerAttack;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        attack = Animator.StringToHash("Attack");
        hpEnemy = 100;
    }

    void Update()
    {
        timerAttack += Time.deltaTime;

        Movement();

        if(animator.GetBool("Attack") == true)
        {
            if(timerAttack > attackInterval)
            {
                gameController.GetComponent<GameController>().hpWall -= attackDamage;
                timerAttack -= attackInterval;
            }
        }

        if (hpEnemy <= 0)
        {
            gameController.GetComponent<GameController>().zombieDead += 1;
            Destroy(gameObject);
        }
    }

    public void Movement()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);

        if (gameController.GetComponent<GameController>().hpWall == 0)
        {
            animator.SetBool("Attack", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            timerAttack = 0;
            animator.SetBool(attack, true);
            speed = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hpEnemy -= player.GetComponent<PlayerController>().bulletDamage;
        }
    }
}
