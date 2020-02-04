using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static Animator anim;
    public static Text text;
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public static IEnumerator KillPlayer(Player player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        player.GetComponent<PlayerMovement>().enabled = false;
        rb.velocity = new Vector3(0, 0, 0f); 
        rb.velocity = new Vector3(0, 15, 0f);
        player.GetComponent<CharacterController2D>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;       
        player.GetComponent<CircleCollider2D>().enabled = false;
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        yield return new WaitForSeconds(2);
        Fade();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void Fade()
    {
        anim.Play("FadeOUT", 0, 0);
        GameObject.FindGameObjectWithTag("GameOver").GetComponent<Text>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
    


