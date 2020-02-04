using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenkäFall : MonoBehaviour
{
    public GameObject kenkä;

    private bool Triggered = false;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Triggered");
                Triggered = true;
                kenkä.GetComponent<Rigidbody2D>().gravityScale = 3;                

            }
        }
    }
}
