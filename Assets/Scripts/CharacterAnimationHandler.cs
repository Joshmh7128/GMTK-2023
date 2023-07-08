using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] float moveSpeed;

    [SerializeField] bool manualAnim; // are we testing animations?

    Vector3 startRot; // our euler rotation at the start of play

    public enum States
    {
        Idle, Taunt, Defeated, Angry, Brooklyn, Texting,

        Max,

        Death, Twerk, GetHit,
    }

    [SerializeField] States targetState; // use this to set states

    private void Start()
    {
        if (!manualAnim)
            StartCoroutine(PlayAnimation());

        startRot = transform.eulerAngles;
    }

    // runs to play animation
    IEnumerator PlayAnimation()
    {
        // choose a random animation
        RequestAnimation((States)Random.Range(0, (int)States.Max));

        // wait random time
        yield return new WaitForSecondsRealtime(Random.Range(4f, 10f));

        // do it again
        StartCoroutine(PlayAnimation());
    }

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
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, moveSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, startRot, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, moveSpeed/5 * Time.deltaTime);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, startRot, moveSpeed/5 * Time.deltaTime);
        }


    }
}
