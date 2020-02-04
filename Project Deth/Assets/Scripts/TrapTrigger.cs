using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public GameObject Trap;
    
    [SerializeField] private float moveSpeed = 2f;
    private bool Triggered = false;
    private float YCord;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                YCord = Trap.transform.position.y + 2;
                Triggered = true;
                do { Trap.transform.position = new Vector2(Trap.transform.position.x, Trap.transform.position.y + moveSpeed * Time.deltaTime);
                } while (Trap.transform.position.y < YCord);
            }
        }
    }
}
