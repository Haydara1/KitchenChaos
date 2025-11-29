using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float playerRadius = .7f;
    [SerializeField] private float playerHeight = 2f;

    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new(inputVector.x, 0f, inputVector.y);
        
        float moveDistance = moveSpeed * Time.deltaTime;

        // Detect Collision
        bool canMove = !Physics.CapsuleCast(transform.position, 
            transform.position + Vector3.up * playerHeight,
            playerRadius, moveDir, moveDistance);

        if (canMove)
        {
            transform.position += moveDistance * moveDir;
        }


        // Detect if the player is walking or not
        isWalking = moveDir != Vector3.zero;

        // Possible functions for rotation:
        // forward, quaternions, eulerAngles, and LookAt
        transform.forward = Vector3.Slerp(transform.forward, moveDir,
            rotateSpeed * Time.deltaTime);
    }

    public bool IsWalking() => isWalking;

}
