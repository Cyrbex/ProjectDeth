using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingTrap : MonoBehaviour
{
    public GameObject Beehive;
    private bool Triggered = false;
    
    // Drop the Beehive ... 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                Triggered = true;
                Beehive.GetComponent<Rigidbody2D>().gravityScale = 3;
            }
        }
    }
}
