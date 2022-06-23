using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField]private Menu menu;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TrackGround" || other.tag == "Wall")
        {
            menu.EndGame();
            Debug.Log("You dead");
        }
    }
}
