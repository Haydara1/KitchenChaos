using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;

    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = new(0, 0);

        // GetKey is getting the key for multiple frames i.e moving
        // GetKeyDown gets the key for one frame i.e jumping
        if(Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new(inputVector.x, 0f, inputVector.y);
        transform.position += moveSpeed * Time.deltaTime * moveDir;


        // Detect if the player is walking or not
        isWalking = moveDir != Vector3.zero;

        // Possible functions for rotation:
        // forward, quaternions, eulerAngles, and LookAt
        transform.forward = Vector3.Slerp(transform.forward, moveDir,
            rotateSpeed * Time.deltaTime);
    }

    public bool IsWalking() => isWalking;

}
