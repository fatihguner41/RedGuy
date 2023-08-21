using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    public Sprite star0,star1,star2,star3,lockImage;
    public Image[] images;
    bool restIsLocked=false;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetString("CurrentLevel")+"asda");
        foreach(Image image in images)
        {
            int stars = PlayerPrefs.GetInt("level_"+image.name+"Stars");
            
            switch (stars)
            {
                case 0:
                    image.sprite = star0;
                    break;
                case 1:
                    image.sprite = star1;
                    break;
                case 2:
                    image.sprite = star2;
                    break;
                case 3:
                    image.sprite = star3;
                    break;
                default:
                    break;
            }

            if (restIsLocked)
            {
                image.sprite = lockImage;
            }

            if(PlayerPrefs.GetInt("CurrentLevel").ToString() == image.name)
            {
                restIsLocked = true;
            }
        }

        GameObject buttonClickSoundObject = GameObject.Find("ButtonClickSound");
        ButtonClickSound bcs; bcs = buttonClickSoundObject.GetComponent<ButtonClickSound>();
        bcs.FindButtons();
        Debug.Log("lm");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
