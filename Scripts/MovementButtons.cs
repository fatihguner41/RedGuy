

using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvents : MonoBehaviour
{
    private bool isPressed = false;

    Button button;
    GameObject player;
    PlayerMovement pMovement;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pMovement = player.GetComponent<PlayerMovement>();
        button = GetComponent<Button>();
    }

    

    public void OnPointerDown(PointerEventData eventData)
    {
        pMovement.horizontal = direction;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pMovement.horizontal = 0;
    }

   
}

