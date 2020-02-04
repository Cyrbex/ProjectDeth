using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public Transform SpawnLocation1;
    public Transform SpawnLocation2;
    public Transform SpawnLocation3;
    public Transform SpawnLocation4;
    public GameObject Enemy1;

    private bool Triggered = false;   

    // Spawn monsters
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                Triggered = true;
                Instantiate(Enemy1, SpawnLocation1.position, SpawnLocation1.rotation);
                Instantiate(Enemy1, SpawnLocation2.position, SpawnLocation2.rotation);
                Instantiate(Enemy1, SpawnLocation3.position, SpawnLocation3.rotation);
                Instantiate(Enemy1, SpawnLocation4.position, SpawnLocation4.rotation);
                Destroy(gameObject);
            }
        }
    }
}
