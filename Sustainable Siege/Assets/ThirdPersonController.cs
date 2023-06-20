using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Transform player;
    public Transform cam;

    public float speed = 6.0f;
    public float rotationSmoothTime = 0.12f;
    public float cameraRotationSpeed = 2.0f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private float rotationSmoothVelocity;
    private float targetRotation;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
        HandleCameraRotation();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
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

    private void HandleCameraRotation()
    {
        float cameraRotationInput = Input.GetAxis("Mouse X") * cameraRotationSpeed;
        cam.RotateAround(player.position, Vector3.up, cameraRotationInput);
    }
}
