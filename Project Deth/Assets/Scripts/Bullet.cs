using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Public Variables
    public int damage = 40;
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject ImpactEffect;
    
    // Private Variables
    private float delay = 40f;
 
   void Start()
    {
        delay = delay / speed;
        rb.velocity = transform.right * speed;
        Destroy(gameObject, delay);   
    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        Enemy enemy = HitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        // Dont destroy the object, if it hits a Trigger Collider
        if (HitInfo.CompareTag("Trigger")) { }
        else
        {
            Destroy(gameObject);
        }
    }
}
