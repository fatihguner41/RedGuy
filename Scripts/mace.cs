using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class mace : MonoBehaviour
{

    public float throwTimer = 3;
    public float deleteTimer = 3;
    float timer2;
    public float xpower = 1,ypower=1;
    public saw saw;
    // Start is called before the first frame update
    void Start()
    {
        timer2 = throwTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer2 -= Time.deltaTime;

        if (timer2 < 0)
        {
            timer2 = throwTimer;
            
            
              
            saw.xpower = xpower;
            saw.ypower = ypower;
            //saw.transform.position = transform.position;
            //saw.transform.rotation = transform.rotation;
            saw newSaw=Instantiate(saw, transform.position, transform.rotation);
            newSaw.timer = deleteTimer;
        }
    }
}
