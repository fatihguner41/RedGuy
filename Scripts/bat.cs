using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    
    PlayerMovement player;
    public Animator animator;
    float distx, disty;
    public float attackTime=2f,attackRange=4f,flySpeed=5f;
    public AudioClip attackSound;
    AudioSource audio;
    SpriteRenderer sprite;

    Vector3 batStartPos;
    // Start is called before the first frame update
    void Start()
    {

        audio = GetComponent<AudioSource>();
        
        player= GameObject.Find("Body").gameObject.GetComponent<PlayerMovement>();
        batStartPos = transform.position;

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        attackTime -= Time.deltaTime;
        distx = transform.position.x - player.transform.position.x;
        disty = transform.position.y - player.transform.position.y;

        if (Mathf.Sqrt(Mathf.Pow(distx, 2)+ Mathf.Pow(disty, 2))<attackRange)
        {
            transform.Translate((player.transform.position - transform.position).normalized * flySpeed * Time.deltaTime);
            //Vector3 hedefPozisyon = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            //transform.position = Vector3.MoveTowards(transform.position, hedefPozisyon, flySpeed * Time.deltaTime);

            if (distx > 1 && !sprite.flipX)
            {
                sprite.flipX = true;
            }
            else if(distx<-1 && sprite.flipX)
            {
                sprite.flipX = false;
            }
        }
        else
        {
            if((batStartPos - transform.position).magnitude>0.1)
            {
                Vector3 hedefPos = batStartPos - transform.position;
                transform.Translate(hedefPos.normalized * flySpeed * Time.deltaTime);
                if (hedefPos.x > 1 && sprite.flipX)
                {
                    sprite.flipX = false;
                }
                else if (hedefPos.x < -1 && !sprite.flipX)
                {
                    sprite.flipX = true;
                }
            }
            
        }

        

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && attackTime < 0)
        {
            player.Hurt();
            animator.SetBool("Attack", true);
            audio.PlayOneShot(attackSound);
            attackTime = 2;

        }
    }

    
}
