using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Animator Anim;
    public float FireRate = 0f;
    public CharacterController2D Controller;
    public Transform player;
    public GameObject BulletPrefab;
    public bool Direction = true;
    public int posOffset;
    public int rotationOffset = 90;
    public Texture2D VihreäCursor;
    public Texture2D PunainenCursor;
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;
    private bool allowFire = true;


    void Awake()
    {
        Direction = true;
        firePoint = transform.Find("FirePoint");
        if (firePoint == null) { }
    }

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

        if (Direction == true) { posOffset = 0; }
        if (Direction == false) { posOffset = 0; }

        if (angle > 0f && angle < 80f || angle < 0f && angle > -80f)
        {
            if (Direction == false)
            {
                Direction = true;
                Flip();
            }
        }

        if (angle > 100f && angle < 180f || angle < -100f && angle > -180f)
        {
            if (Direction == true)
            {
                Direction = false;
                Flip();
            }
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + posOffset));  //Rotating!
        if ((Direction == true && transform.rotation.z > -0.3 && transform.rotation.z < 0.3) || (Direction == false && (transform.rotation.z < -0.95 || transform.rotation.z > 0.95)))
        {
            Cursor.SetCursor(VihreäCursor, hotSpot, cursorMode);
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Shoot());
            }
        }
        else { Cursor.SetCursor(PunainenCursor, hotSpot, cursorMode); }
    }

    IEnumerator Shoot()
    {
        
        Vector3 Diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float Rotation_Z = Mathf.Atan2(Diff.y, Diff.x) * Mathf.Rad2Deg;
        Vector2 Suunta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (allowFire)
        {

            if (Controller.m_Grounded == true)
            {
                Anim.Play("player_stand_shoot", 0, 0f);
                
            }
            else if (Controller.m_Grounded == false)
            {
                Anim.Play("player_jump_shoot", 0, 0f);
            }
            allowFire = false;
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(FireRate);
            allowFire = true;
        }
    }

    public void Flip()
    {
        player.transform.Rotate(0f, 180f, 0f);
    }
}
