using UnityEngine;
using UnityEngine.InputSystem;

public class FPSController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraTransform;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1.5f;

    [Header("Mouse Look")]
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float minLookX = -80f;
    [SerializeField] private float maxLookX = 80f;

    private CharacterController controller;
    private PlayerInputActions inputActions;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private float verticalVelocity;
    private float cameraPitch;
    private bool jumpPressed;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputActions = new PlayerInputActions();

        inputActions.Player.Move.performed += ctx =>
            moveInput = ctx.ReadValue<Vector2>();

        inputActions.Player.Move.canceled += _ =>
            moveInput = Vector2.zero;

        inputActions.Player.Look.performed += ctx =>
            lookInput = ctx.ReadValue<Vector2>();

        inputActions.Player.Look.canceled += _ =>
            lookInput = Vector2.zero;

        inputActions.Player.Jump.performed += _ =>
        {
           
            jumpPressed = true;
        };
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
       
        HandleLook();
        HandleMovement();
    }

    private void HandleLook()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, minLookX, maxLookX);

        cameraTransform.localRotation =
            Quaternion.Euler(cameraPitch, 0f, 0f);
    }

    private void HandleMovement()
    {
        Vector3 move =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        bool isGrounded = controller.isGrounded;

        if (isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        if (isGrounded && jumpPressed)
        {
         

            verticalVelocity =
                Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        jumpPressed = false;

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity =
            move * moveSpeed +
            Vector3.up * verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }
}