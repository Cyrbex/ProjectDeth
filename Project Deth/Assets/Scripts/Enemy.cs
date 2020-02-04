using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Public Variables
    public GameObject player;
    public int Health = 100;
    public GameObject GM;

    // Private Variables
    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0) { Die(); }
    }

    // Destroy object
    void Die() { Destroy(gameObject); }

    // Kills player on Collision
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            // Attack
            StartCoroutine(attack());
            // Kill player
            StartCoroutine(GameMaster.KillPlayer(player));
        }
    }
    // Attack animation for Demon 
    public IEnumerator attack()
    {
        rb.velocity = new Vector3(0, 0, 0);
        anim.SetBool("IsAttacking", true);
        anim.Play("demon_attack", 0, 0);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + 2);
        anim.SetBool("IsAttacking", false);
    }
}


