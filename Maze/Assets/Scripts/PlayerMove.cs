using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 * Script that handles player characters movement. Character can sprint and jump. Speeds can be changed inside Unity.
 * 
 */
public class PlayerMove : MonoBehaviour {

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float sprintSpeed;

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private KeyCode sprintKey;
    private float horizInput;
    private float vertInput;

    private bool isJumping;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {
        PlayerMovement();
	}

    // playerMovement checks if movement inputs are given. Also calls jumpInput method which checks if player player jumps.
    private void PlayerMovement()
    {
        if (Input.GetKey(sprintKey))
        {
            horizInput = Input.GetAxis(horizontalInputName) * sprintSpeed;
            vertInput = Input.GetAxis(verticalInputName) * sprintSpeed;
        }
        else
        {
            horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
            vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        }
        
        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

        JumpInput();
    }

    // jumpInput method checks if player wants to jump, and if it is possible. Calls jumpEvent which handles the jumping itself.
    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(jumpEvent());
        }
    }

    // jumpEvent method handles jumping event if it is called. 
    private IEnumerator jumpEvent()
    {
        // Prevetns character stuttering next to a edge
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }
}