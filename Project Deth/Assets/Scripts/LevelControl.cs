using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    
    private bool Triggered = false;
    public Animator anim;

    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (!Triggered)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {

                player.GetComponent<PlayerMovement>().enabled = false;
                Triggered = true;
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(2, 0, 0f);
                anim.Play("FadeOUT", 0, 0);
                GameObject.FindGameObjectWithTag("GameOver").GetComponent<Text>().text = " ";
                GameObject.FindGameObjectWithTag("PepeLaugh").GetComponent<Image>().enabled = false;
                yield return new WaitForSeconds(5);
                SceneManager.LoadScene("Level_00");
            }
        }
    }
}