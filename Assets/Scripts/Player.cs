using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Camera mainCamera;

    //private vars
    private Rigidbody2D rb;
    private InputAction moveAction;
    private InputAction jumpAction;

    void Awake()
    {
        mainCamera.transform.Translate(transform.position);
        rb = GetComponent<Rigidbody2D>();

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        rb.AddForceX(moveValue.x);


        Vector3 targetPosition = new(transform.position.x, transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * 5f);

    }
}
