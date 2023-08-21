using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBlock : MonoBehaviour
{

    Vector3 firstloc;
    Vector3 velocity;
    public float speed=5f;
    public float yon = 1;
    public float genislik = 6;
    Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        firstloc = gameObject.transform.position;
        velocity = new Vector3(1, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(gameObject.transform.position.x-firstloc.x)>genislik) {
            gameObject.transform.position = firstloc + new Vector3(genislik, 0)*yon;
            yon *= -1;
        }

        gameObject.transform.position += velocity * Time.deltaTime * speed*yon;
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Rigidbody2D>();
            if (player.velocity.y == 0)
                collision.transform.SetParent(transform);
        }
        
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(yon*speed*10,0f));
        }
    }
}
