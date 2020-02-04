using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            StartCoroutine(GameMaster.KillPlayer(player));
        }
    }
}

