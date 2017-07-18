using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = 1;
    float velocity;
    public float speed = 5;
    bool lookRight = true;
    bool jump = false;
    public float jumpFactor = 20;

    public Vector3 moveDirection = Vector3.zero;
    public CharacterController characterController;
    public PlayerAnimations playerAnimations;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        input();
        moving();
        setAnimation();
    }

    public void input()
    {
        velocity = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;
        else
            jump = false;
    }

    public void moving()
    {
        if (characterController.isGrounded)
        {
            if (jump)
            {
                moveDirection.y = jumpFactor * Time.deltaTime;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection.x = velocity * Time.deltaTime;
        if (velocity > 0)
            lookRight = true;
        else if (velocity < 0)
            lookRight = false;

        characterController.Move(moveDirection);
    }

    public void setAnimation()
    {
        
        if (velocity > 0)
        {
            playerAnimations.currAnimation = PlayerAnimations.AniType.runRight;
            if (!characterController.isGrounded)
                playerAnimations.currAnimation = PlayerAnimations.AniType.jumpRight;
        }
        if (velocity < 0)
        {
            playerAnimations.currAnimation = PlayerAnimations.AniType.runLeft;
            if (!characterController.isGrounded)
                playerAnimations.currAnimation = PlayerAnimations.AniType.jumpLeft;
        }
        if (velocity == 0)
        {
            if (lookRight)
            {
                playerAnimations.currAnimation = PlayerAnimations.AniType.idleRight;
                if (!characterController.isGrounded) playerAnimations.currAnimation = PlayerAnimations.AniType.jumpRight;
            }
            else
            {
                playerAnimations.currAnimation = PlayerAnimations.AniType.idleLeft;
                if (!characterController.isGrounded) playerAnimations.currAnimation = PlayerAnimations.AniType.jumpLeft;
            } 
        }
        
    }
}
