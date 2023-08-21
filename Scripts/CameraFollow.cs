using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetObject;
    public Vector3 cameraOffset;
    public Vector3 targetedPosition;
    public Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.3f;
    // Update is called once per frame
    void LateUpdate()
    {
        targetedPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
    }
}
