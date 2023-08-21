using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class saw : enemy 
{
    Rigidbody2D rgb;
    
    
    public float xpower=1f,ypower=1f;
    Vector3 pos;
    Quaternion rot;
    public float timer=3f;

    // Start is called before the first frame update
    void Start()
    {
        
        rgb= GetComponent<Rigidbody2D>();

        
        rgb.AddForce(Vector3.up * ypower + Vector3.right * xpower, ForceMode2D.Impulse);



    }

    

    // Update is called once per frame
    void Update()
    {

        Invoke("Destroy", timer);

    }

    public void Destroy()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
