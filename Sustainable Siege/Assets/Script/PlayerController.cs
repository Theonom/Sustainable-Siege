using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cam;
    public Joystick joystick;
    public GameObject camEnemy, camPlayer;

    public float speed;
    public float rotationSmoothTime;
    public bool bringTrash;

    private CharacterController controller;
    private Vector3 moveDirection;
    private float rotationSmoothVelocity;
    private float targetRotation;
    private bool cameraEnemy;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraEnemy = false;
    }

    private void Update()
    {
        Movement();
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

            if (vertical > 0.0f)
            {
                transform.rotation = Quaternion.Euler(0.0f, targetRotation, 0.0f);
            }

            moveDirection = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }

    public void PlayerAttack()
    {
        //Menembak musuh
    }

    public void SortTrash()
    {
        //pilah sampah
        if (bringTrash == false)
        {
            bringTrash = true;
        }
        else
        {
            bringTrash = false;
        }
    }

    public void Upgrade()
    {
        //upgrade senjata
    }

    public void ChangeCamera()
    {
        if (cameraEnemy == false)
        {
            camPlayer.SetActive(false);
            camEnemy.SetActive(true);
            cameraEnemy = true;
        }
        else
        {
            camPlayer.SetActive(true);
            camEnemy.SetActive(false);
            cameraEnemy = false;
        }
    }
}
