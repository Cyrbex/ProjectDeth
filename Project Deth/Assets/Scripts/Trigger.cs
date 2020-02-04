using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private bool Triggered = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                Triggered = true;
            }
        }
    }
}

