using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public PlayerControls controls;
    public Rigidbody rb;
    public Transform cameraTransform;
    private float speed = 40f;
    public float walkSpeed = 40f;
    public float runSpeed = 80f;
    public float sneakSpeed = 20f;
    private bool isGrounded;
    public float jumpForce = 10f;
    private bool isPaused = false;

    public AudioSource a;

    public AudioClip jump;
    public AudioClip death;

    public GameObject pauseMenuCanvas;

    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;

    private void Awake()
    {
        a = GetComponent<AudioSource>();
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
        controls.Enable();
        controls.Player.Jump.performed += _ => Jump();
        controls.Player.Pause.performed += _ => Pause();
    }

    private void Update()
    {
        Move(controls.Player.Move.ReadValue<Vector2>());

        float inputX = controls.Player.Look.ReadValue<Vector2>().x * mouseSensitivity;
        float inputY = controls.Player.Look.ReadValue<Vector2>().y * mouseSensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        cameraTransform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        transform.Rotate(Vector3.up * inputX);
    }

    private void Move(Vector2 direction)
    {
        if (controls.Player.Move.triggered)
        {
            speed = walkSpeed;
        }
        else if (controls.Player.Sneak.triggered)
        {
            speed = sneakSpeed;
        }
        else if (controls.Player.Run.triggered)
        {
            speed = runSpeed;
        }

        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(moveDirection)); // Changed to transform.TransformDirection
    }

    public void Jump()
    {
        if (isGrounded)
        {
            //a.PlayOneShot(jump, 1.0f);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenuCanvas.SetActive(true);
        }

        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenuCanvas.SetActive(true);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
