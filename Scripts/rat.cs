using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat : MonoBehaviour
{
    public Animator animator;
    public float speed=5f;
    public float direction= 1;
    Rigidbody2D rgb;
    
    public float attackTimer =1.5f;
    public float attackTime;

    public GameObject leftLimit;
    public GameObject rightLimit;


    public AudioClip attackSound;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rgb = GetComponent<Rigidbody2D>();
        
        attackTime = attackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //rgb.AddForce(direction * speed);
        
        attackTime -= Time.deltaTime;
       
        transform.position+= speed * Time.deltaTime * new Vector3(direction,0,0);
        

       


    }


   

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && attackTime < 0)
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.Hurt();
            animator.SetBool("Hit", true);
            audio.PlayOneShot(attackSound);
            attackTime = attackTimer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == leftLimit || collision.gameObject == rightLimit)
        {
            direction *= -1;



            if (direction >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

}
