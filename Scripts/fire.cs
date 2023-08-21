using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : enemy
{
    PlayerMovement player;
    public float deleteTimer = 3f;
    public GameObject explosion;
    ParticleSystem explosionEffect;
    GameObject expObject;
    bool collided = false;
    public float fireSpeed = 5f;

    Vector3 playerPos,firePos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Body").GetComponent<PlayerMovement>();
        playerPos = player.gameObject.transform.position;
        firePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DestroyObject", deleteTimer);

        Vector3 hareketYonu = (playerPos - firePos).normalized;
        transform.Translate(hareketYonu * fireSpeed * Time.deltaTime);
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {

            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.Hurt();



        }

        //gameObject.SetActive(false);
        //Destroy(gameObject);
        if (!collided)
        {
            expObject = Instantiate(explosion, transform.position, Quaternion.identity);
            explosionEffect = expObject.GetComponent<ParticleSystem>();
            explosionEffect.Play();
            collided = true;
            Invoke("DestroyObject", 1f);
            gameObject.SetActive(false);
            
        }
        
            
       
    }

    public void DestroyObject()
    {
        
        Destroy(explosionEffect);
        Destroy(expObject);
        Destroy(gameObject);

    }

}
