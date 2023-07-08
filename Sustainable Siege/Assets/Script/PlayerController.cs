using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cam;
    public Joystick joystick;
    public LayerMask groundedLayers;

    public float speed, rotationSmoothTime;
    public float groundedOffset = -0.14f;
    public float groundedRadius = 0.25f;
    public float gravity = -1f;
    public bool bringTrash, grounded;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Animator animator;

    private float rotationSmoothVelocity;
    private float targetRotation;
    private float timerAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        GroundedCheck();
        Gravity();

        timerAttack += Time.deltaTime;
        if (timerAttack >= 1.10)
        {
            animator.SetBool("Attack", false);
        }
    }

    private void Movement()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            targetRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSmoothVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0.0f, targetRotation, 0.0f);

            moveDirection = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
            moveDirection.y += Time.deltaTime;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal + vertical));
    }

    private void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
        grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundedLayers, QueryTriggerInteraction.Ignore);
    }

    private void Gravity()
    {
        if (!grounded)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + gravity * Time.deltaTime, transform.position.z);
        }
    }

    public void PlayerAttack()
    {
        //Menembak musuh
        animator.SetBool("Attack", true);
        timerAttack = 0;
    }
}
