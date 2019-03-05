using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //This script controls the basic movement of the player, i.e. moving left and right and jumping
    CharacterController charController;

    //This line controls the jumpspeed of the player
    [SerializeField] float jumpSpeed = 20.0f;
    //This line controls the amount of time before the player is pulled back to the ground after jumping
    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;

    //This line controls the basic movement speed of the player's character
    [SerializeField] float moveSpeed = 5.0f;
    public float h;
    public float v;
    Animator anim;

    [SerializeField] AudioSource audioSrc;
    internal static Vector3 position;

    void Start ()
    {
        charController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void JumpSound ()
    {
        audioSrc.Play();
    }

    private void IdleSound ()
    {
        audioSrc.Play();
    }

    //Update is called once per frame
    void Update()
    {
        // These two lines control the player and enable them to move both horizontal (left and right),
        // and vertical (jumping up)
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        // These two lines control the speed (v = vertical), as well as the direction (h = horizontal),
        // within animations.
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);

        // These lines control the direction of movement as well as the speed of movement.
        Vector3 direction = new Vector3(h, 0, v);
        Vector3 velocity = direction * moveSpeed;
        // If the player is on the ground and presses the space bar, the player will jump (with animations).
        if (charController.isGrounded) {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetTrigger("Jump");
                yVelocity = jumpSpeed;
            }

        } else {
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;

        velocity = transform.TransformDirection(velocity);

        charController.Move(velocity * Time.deltaTime);

    }
}
