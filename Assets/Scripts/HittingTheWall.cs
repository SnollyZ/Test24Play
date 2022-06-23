using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingTheWall : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Collider collider;
    private GameObject cubeHolderObj;
    private CubeHolder cubeHolder;
    private bool hasBeenHitted = false;

    void Start()
    {
        cubeHolderObj = GameObject.FindGameObjectWithTag("CubeHolder");
        cubeHolder = cubeHolderObj.GetComponent<CubeHolder>();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {   
        RaycastHit hit;
        Vector3 dir = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        if(Physics.Linecast(transform.position, dir, out hit))
        {
            if(other.tag == "Wall" && hit.transform.tag == "Wall" && !hasBeenHitted)
            {
                Hitt();
            }
        }
    }

    private void Hitt()
    {
        Handheld.Vibrate();
        
        tag = "Untagged";
        cubeHolder.cubes.Remove(this.transform);
        hasBeenHitted = true;
    }


}
