using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerSciprt : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.75f;
    public Vector3 offset;

    private void FixedUpdate()
    {

        Vector3 desiredPosition = target.position + offset;
        
        // This is necessary, this allows camera to not look DIRECTLY at our target object. (Looking directly causes this object to disappear)
        desiredPosition.z = -10f;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * 1.4f * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
