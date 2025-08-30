//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/CharacterController.Move.html
//Modified to work only on the x and y axis.

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -9.81f;
    AudioSource jumpAudio;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;



    private void Start()
    {
        controller = GetComponent<CharacterController>();
        jumpAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        //stops from going down when you touch the ground
        if (groundedPlayer && playerVelocity.y < 0f)
        {
            playerVelocity.y = 0f;
        }

        //gets player input for the horizontal axis, left and right and ignores the vertical
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        //make slime face the direction youre moving
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        //jump force if character can jump and play audio with jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            jumpAudio.Play();
        }

        //applies gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        //combine movement and gravity
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);


    }


}