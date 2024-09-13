using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController CharacterController => characterController;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;

    private Camera GameCamera;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpForce = 1.0f;
    private float gravityValue = -9.81f;

    public void Init()
    {
        GameCamera = Camera.main;
    }

    public void AddJumpForce(float value)
    {
        playerVelocity.y += Mathf.Sqrt(value * -3.0f * gravityValue);
        animator.SetTrigger("Jump");
    }

    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -0.5f;
        }

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        var forward = GameCamera.transform.forward;
        forward.y = 0;
        forward.Normalize();
        var right = Vector3.Cross(Vector3.up, forward);
        
        Vector3 move = forward * input.z + right * input.x;
        move.y = 0;
        
        characterController.Move(move * Time.deltaTime * playerSpeed);

        animator.SetFloat("MovementX", input.x);
        animator.SetFloat("MovementZ", input.z);

        if (input != Vector3.zero)
        {
            gameObject.transform.forward = forward;
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            AddJumpForce(jumpForce);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }    
}