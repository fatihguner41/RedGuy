using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SuccessMenu : MonoBehaviour
{

    public Image scoreImage;
    public Sprite star0;
    public Sprite star1;
    public Sprite star2;
    public Sprite star3;
    public float timeGoal = 60;

    public TMP_Text timeText;
    public TMP_Text scoreText;
    public TMP_Text lifeText;

    public GameObject timeStar;
    public GameObject scoreStar;
    public GameObject lifeStar;
    PlayerMovement player;

    GameObject gameSong;
    MusicPlayer mp;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.active == true)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

            CountStars();

            gameSong = GameObject.Find("GameSong");
            mp = gameSong.GetComponent<MusicPlayer>();
            mp.SetVolume(1f);
            mp.ResetPitch();
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CountStars()
    {
        timeText.text = timeText.text + ((int)player.getTime())+ "s(Goal:"+timeGoal+"s)";
        scoreText.text = scoreText.text + player.score;
        lifeText.text = lifeText.text + player.life;

        if (player.getTime() <= timeGoal)
        {
            player.stars++;
            timeStar.SetActive(true);

            
        }
        if (player.score == 3)
        {
            player.stars++;
            scoreStar.SetActive(true);
            
        }
        if (player.life == 3)
        {
            player.stars++;
            lifeStar.SetActive(true);
            
        }
        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "Stars") < player.stars)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Stars", player.stars);

        }

        switch (player.stars)
        {
            case 0:
                scoreImage.sprite = star0;
                break;
            case 1:
                scoreImage.sprite = star1;
                break;
            case 2:
                scoreImage.sprite = star2;
                break;
            case 3:
                scoreImage.sprite = star3;
                break;
            default:
                break;
        }

        PlayerPrefs.SetInt("CurrentLevel", int.Parse(SceneManager.GetActiveScene().name.Split('_')[1]) + 1);
        Debug.Log(PlayerPrefs.GetInt("CurrentLevel") + ". level is unlocked");
        PlayerPrefs.Save();
    }
}
