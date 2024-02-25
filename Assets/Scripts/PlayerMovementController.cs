using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public PlayerControls controls;
    public Rigidbody rb;
    private float speed = 40f;
    public float walkSpeed = 40f;
    public float runSpeed = 80f;
    public float sneakSpeed = 20f;
    private bool isGrounded;
    public float jumpForce = 10f;
    private bool isPaused = false;

    public GameObject pauseMenuCanvas;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
        controls.Enable();
        controls.Player.Jump.performed += _ => Jump();
        controls.Player.Pause.performed += _ => Pause();
    }

    private void Update()
    {
        Move(controls.Player.Move.ReadValue<Vector2>());
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
        rb.MovePosition(transform.position + moveDirection);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuCanvas.SetActive(true);
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
