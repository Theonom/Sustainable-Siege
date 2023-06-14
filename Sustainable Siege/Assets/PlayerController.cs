using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;

    private Rigidbody rig;

    public int speed;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        rig.velocity = new Vector3(horizontal * speed, rig.velocity.y, vertical * speed);

        if (horizontal != 0 || vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rig.velocity);
        }
    }

    public void PlayerAttack()
    {
        Debug.Log("Tembak");
    }

    public void PlayerSortTrash()
    {
        Debug.Log("Pilah");
    }
}
