using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public enum playerAnimationState
    {
        IDLE,
        RUNNING,
        JUMPING,
        FALLING
    }

    private playerAnimationState animationState;
    private Animator animator;
    private Rigidbody2D body;

    private void Awake() 
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void changePlayerAnimationState(playerAnimationState PlayerAnimationState, bool state)
    {
        animator.SetBool("RUNNING", false);
        animator.SetBool("IDLE", false);
        animator.SetBool("JUMPING", false);
        animator.SetBool("FALLING", false);
        animator.SetBool(PlayerAnimationState.ToString(), state);
    }

    private void Update() 
    {
        if(body.velocity.y > 0)
            animationState = playerAnimationState.JUMPING;
        else if(body.velocity.y < 0)
            animationState = playerAnimationState.FALLING;
        else if(body.velocity.x > 0 || body.velocity.x < 0)
            animationState = playerAnimationState.RUNNING;
        else
            animationState = playerAnimationState.IDLE;

        changePlayerAnimationState(animationState, true);
    }

}
