using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float speedX;

    private Rigidbody rigidbody;
    private Vector3 dir;

    void Start()
    {
        dir = new Vector3(3, 0, 0);
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(transform.position.z >= 0.5f && transform.position.z <= 4.5f)
            {
                dir = new Vector3(speedX, -3, Input.GetAxis("Mouse X") * -speed);
            }
            else if(transform.position.z < 0.5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
            }
            else if(transform.position.z > 4.5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 4.5f);
            }
        }
        else
        {
            dir = new Vector3(speedX, -3, 0);
        }
        
        rigidbody.velocity = dir;
    }
}
