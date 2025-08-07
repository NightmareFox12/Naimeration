using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //public vars
    public Camera mainCamera;
    public float speed = 5f;
    public float acceleration = 8f;

    //private vars
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;

    private InputAction moveAction;
    private InputAction jumpAction;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();

        playerSprite.sprite =
        playerSprite.sprite = Resources.Load<Sprite>(GameManager.Instance.playerSelected.pathSprite);

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Start()
    {
        // mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }

    public Vector2 cameraOffset = new(1.5f, 0f);
    private float currentVelocityX = 0f;
    private Vector3 cameraVelocity = Vector3.zero;

    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if (moveValue.x == -1) playerSprite.flipX = true;
        else if (moveValue.x == 1) playerSprite.flipX = false;


        float targetSpeed = moveValue.x * speed;
        float smoothSpeed = Mathf.SmoothDamp(rb.linearVelocity.x, targetSpeed, ref currentVelocityX, 0.1f);
        rb.linearVelocity = new Vector2(smoothSpeed, rb.linearVelocity.y);
        // Vector3 targetPosition = new(
        //     transform.position.x + cameraOffset.x * Mathf.Sign(moveValue.x),
        //     transform.position.y + cameraOffset.y,
        //     -10f
        // );
        // mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetPosition, ref cameraVelocity, 0.15f);

        //         mainCamera.transform.position = Vector3.SmoothDamp(
        //        mainCamera.transform.position,
        //     targetPosition,
        //     ref cameraVelocity,
        //     0.08f // más rápido
        // );

    }
}
