using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public GameObject successMenu;
    PlayerMovement player;

   

    AudioSource audio;
    public AudioClip portalSound;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = 0f;
            
            player.audio.volume = 0 ;
            audio.PlayOneShot(portalSound);
            successMenu.SetActive(true);
            
        }
    }

    
}
