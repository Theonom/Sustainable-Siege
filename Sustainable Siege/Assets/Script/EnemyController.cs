using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;

    private Animator animator;
    private int attack;

    void Start()
    {
        animator = GetComponent<Animator>();
        attack = Animator.StringToHash("Attack");
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            animator.SetBool(attack, true);
            speed = 1;
        }
    }
}
