using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Coin : MonoBehaviour
{

    //public Rigidbody2D rgb;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {

            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.score += 1;
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
}