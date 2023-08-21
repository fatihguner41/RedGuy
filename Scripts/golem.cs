using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golem : MonoBehaviour
{
    PlayerMovement player;
    public Animator animator;
    public GameObject fireObject;
    public AudioClip fireSound;
    AudioSource audio;
    public float attackSpeed=2f;
    public float attackRange=10f;
    public float fireballSpeed=5f;
    float timer;
    float distx,disty;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        timer = attackSpeed;
        player = GameObject.Find("Body").GetComponent<PlayerMovement>();
       
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        distx = transform.position.x - player.transform.position.x;
        disty = transform.position.y - player.transform.position.y;
        if (timer < 0 && Mathf.Sqrt(Mathf.Pow(distx, 2) + Mathf.Pow(disty, 2)) < attackRange)
        {
            timer = attackSpeed;

            
            animator.SetBool("Attack 2", true);



            GameObject fireball= GameObject.Instantiate(fireObject, transform.position, fireObject.transform.rotation);
            fireball.GetComponent<fire>().fireSpeed = fireballSpeed;
            audio.PlayOneShot(fireSound);
            
            
            
        }
    }
}
