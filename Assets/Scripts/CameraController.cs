using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private float smoothSpeed = 0.5f;
    [SerializeField]private Vector3 offset;
    [SerializeField]private Quaternion rotationOffset;
    
    private Transform target;
    private Vector3 startPosition;

    private void Start() 
    {
        target = GameObject.Find("Player").transform;
        transform.rotation = rotationOffset;
        startPosition = target.position + offset;
        transform.position = startPosition;
    }

    private void FixedUpdate() {
        if(target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, startPosition.y , startPosition.z) + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
        else
            Debug.Log("Camera: Can't find player");
    }

}
