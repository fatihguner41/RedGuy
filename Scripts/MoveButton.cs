using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    
    
    GameObject player;
    PlayerMovement pMovement;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pMovement = player.GetComponent<PlayerMovement>();
        
    }
    public void OnLeftButtonDown()
    {
        pMovement.horizontal = -1;
    }

    public void OnLeftButtonUp()
    {
        pMovement.horizontal = 0;
    }

    public void OnRightButtonDown()
    {
        pMovement.horizontal = 1;
    }

    public void OnRightButtonUp()
    {
        pMovement.horizontal = 0;
    }

    public void OnJumpButtonDown()
    {
        
        
        pMovement.jump = true;

        
    }

    public void OnJumpButtonUp()
    {
        pMovement.jump = false;
    }
}
