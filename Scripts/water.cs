using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class water : MonoBehaviour
{
    AudioSource audio;
    public AudioClip waterSound;
    PlayerMovement player;


    bool touchedWater = false;

    public GameObject waterSplashAnimObj;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touchedWater)
        {
            player.rgb.velocity = new Vector2(0f, -2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audio.PlayOneShot(waterSound);
            Invoke("RestartScene", 1f);

            player = collision.gameObject.GetComponent<PlayerMovement>();
            touchedWater = true;

            Color color; 
            ColorUtility.TryParseHtmlString("#68114B", out color);
            
            SpriteRenderer playerSprite=collision.gameObject.GetComponent<SpriteRenderer>();
            playerSprite.color = color;

            GameObject waterSplashAnimObj2=Instantiate(waterSplashAnimObj, collision.gameObject.transform.position, waterSplashAnimObj.transform.rotation);
            ParticleSystem ps =waterSplashAnimObj2.GetComponent<ParticleSystem>();
            ps.Play();
        }
    }
    

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
