using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForceMove : MonoBehaviour
{
    public float Speed = 100f;

    private bool Triggered = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.GetComponent<PlayerMovement>().enabled = false;
                Triggered = true;
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(Speed, 0, 0f);
            }
        }
    }
}
