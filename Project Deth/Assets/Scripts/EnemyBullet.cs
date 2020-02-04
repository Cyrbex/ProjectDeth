using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // This is script is not used yet

    // Public variables
    public Rigidbody2D rb;
    public GameObject ImpactEffect;
    public float speed = 20f;

    // Private variables
    private float delay = 40f;

    void Start()
    {
        // How far the bullet goes before it's destroyed automaticly
        delay = delay / speed;
        rb.velocity = transform.right * speed;
        Destroy(gameObject, delay);
    }

    // On Collision with player kill the player
    public void OnTriggerEnter2D(Collider2D HitInfo)
    {
        Player player = HitInfo.GetComponent<Player>();
        if (player != null)
        {
            StartCoroutine(GameMaster.KillPlayer(player));
        }
        Destroy(gameObject);
    }
}

