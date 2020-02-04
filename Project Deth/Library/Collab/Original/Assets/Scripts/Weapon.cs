using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Animator Anim;
    public float FireRate = 0f;
    public CharacterController2D Controller;
    
    public GameObject BulletPrefab;
    public bool Direction;
    public int posOffset;
    public int rotationOffset = 90;

    void Start()
    {
        Direction = true; // Facing Right
    }
    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.Log("No Firepoint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate FirePoint
        Vector3 MousePosition = Input.mousePosition;
        MousePosition.z = 5f;
        Vector3 ObjectPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Substract those two vectors

        MousePosition.x = MousePosition.x - ObjectPosition.x;
        MousePosition.y = MousePosition.y - ObjectPosition.y;

        float angle = Mathf.Atan2(MousePosition.y, MousePosition.x) * Mathf.Rad2Deg;

        //Debug.Log(angle + "");

        firePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + posOffset));  //Rotating!

        // Execute shoot when Fire1 is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            if (Controller.m_Grounded == true)
            {
                Anim.Play("player_stand_shoot", 0, 0f);
                Shoot();
            }
            else if (Controller.m_Grounded == false)
            {
                Anim.Play("player_jump_shoot", 0, 0f);
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector3 Diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float Rotation_Z = Mathf.Atan2(Diff.y, Diff.x) * Mathf.Rad2Deg;

        Vector2 Suunta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

    

        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
    }
}
