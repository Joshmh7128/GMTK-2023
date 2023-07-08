using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] float moveSpeed;

    public enum States
    {
        Idle, GetHit, Taunt, Defeated, Death, Twerk
    }

    [SerializeField] States targetState; // use this to set states

    private void FixedUpdate()
    {
        if (targetState != States.Idle)
            RequestAnimation(targetState);

        LerpBackToRoot();
    }

    public void RequestAnimation(States state)
    {
        // play our animation
        animator.Play(state.ToString());
        // reset the state
        targetState = States.Idle;
    }

    // lerp back to start if state is idle
    public void LerpBackToRoot()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("Idle 1"))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, moveSpeed * Time.deltaTime);
        }
    }
}
