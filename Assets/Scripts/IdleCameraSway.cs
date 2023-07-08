using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCameraSway : MonoBehaviour
{
    // where we're going, and where we're based
    Vector3 targetPos, startPos;
    [SerializeField] float swayRange, moveSpeed; // swaying

    // Start is called before the first frame update
    void Start()
    {
        // set start pos on start
        startPos = transform.localPosition;
        // start our coroutine
        StartCoroutine(NewPos());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move towards our target position
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
    }

    // choose our next position
    IEnumerator NewPos()
    {
        yield return new WaitForSecondsRealtime(Random.Range(0.1f, 1)); // wait a random amount of time
        // choose a new position
        targetPos = startPos + new Vector3(Random.Range(-swayRange, swayRange), Random.Range(-swayRange, swayRange), Random.Range(-swayRange, swayRange));
        // start our coroutine again
        StartCoroutine(NewPos());
    }

}
