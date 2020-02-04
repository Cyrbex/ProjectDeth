using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // Script is not used yet...

    // Public variables
    public static GameObject enemyScript;
    public static float offset = 0f;
    public GameObject FirePoint;
    public Transform target;
    public Animator anim;
    public static GameObject Bullet;
    public static GameObject enemy;

    // Private variables
    private Rigidbody2D rb;
   
    void Start()
    {
        FirePoint = GameObject.FindGameObjectWithTag("EnemyFirePoint");
        anim = GetComponent<Animator>();
        enemyScript = GameObject.FindGameObjectWithTag("FlyingEnemy");
        enemyScript.GetComponent<Enemy_AI_Flying>();
    }

    public static IEnumerator EnemyShoot()
    {

        enemyScript.GetComponent<Enemy_AI_Flying>().enabled = false;
        offset = 90;
        GameObject FirePoint = GameObject.FindGameObjectWithTag("EnemyFirePoint");
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        Animator anim = enemy.GetComponent<Animator>();
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, 0, 0);
        anim.Play("Flying_monster_shoot", 0);

        Vector3 PlayerPosition = target.transform.position;
        PlayerPosition.z = 5f;
        Vector3 ObjectPosition = FirePoint.transform.position;

        PlayerPosition.x = PlayerPosition.x - ObjectPosition.x;
        PlayerPosition.y = PlayerPosition.y - ObjectPosition.y;

        float angle = Mathf.Atan2(PlayerPosition.y, PlayerPosition.x) * Mathf.Rad2Deg;

        FirePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        Instantiate(Bullet, FirePoint.transform.position, FirePoint.transform.rotation);
        Debug.DrawLine(PlayerPosition, ObjectPosition);
        yield return new WaitForSeconds(5);

        enemyScript.GetComponent<Enemy_AI_Flying>().enabled = true;
    }
}
