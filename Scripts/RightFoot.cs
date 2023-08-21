using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFoot : MonoBehaviour
{
    Vector3 sut,pos;
    Quaternion qua;
    public PlayerMovement player;


    void Start()
    {
        sut = new Vector3(0.48f, 0.28f, 0);
        pos = new Vector3(0.19f,-0.28f);
        qua = transform.rotation;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)){
            transform.position += sut;
            transform.rotation =Quaternion.Euler(0,0.42f,69);
            
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            transform.rotation = qua;
            transform.position = player.transform.position +pos;
        }
    }
}
