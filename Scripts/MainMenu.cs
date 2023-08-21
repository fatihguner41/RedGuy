using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    GameObject gameSong;
    AudioSource gameSongAudio;
    int currentLevel;
    private void Start()
    {
        
        Debug.Log(PlayerPrefs.GetInt("CurrentLevel"));
        if (!PlayerPrefs.HasKey("CurrentLevel")|| PlayerPrefs.GetInt("CurrentLevel")<=0)
        {
            // 'currentLevel' deðerini baþlangýç seviyesi olarak atayýn, örneðin 1. seviye
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }

        gameSong = GameObject.Find("GameSong");
        gameSongAudio = gameSong.GetComponent<AudioSource>();
        gameSongAudio.pitch = 1f;
        gameSongAudio.volume = 1f;

        GameObject buttonClickSoundObject = GameObject.Find("ButtonClickSound");
        ButtonClickSound bcs; bcs = buttonClickSoundObject.GetComponent<ButtonClickSound>();
        bcs.FindButtons();
        Debug.Log("mm");

    }
        public void PlayGame()
    {
        //SceneManager.LoadScene("level_"+PlayerPrefs.GetInt("CurrentLevel").ToString());
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        string sceneName = "level_" + currentLevel.ToString();

        // SceneManager.GetSceneByName() ile sahnenin var olup olmadýðýný kontrol edin

        LoadSceneIfExists(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelsMenu()
    {
        SceneManager.LoadScene("Levels");
    }

    private void LoadSceneIfExists(string sceneName)
    {
        if (SceneExists(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            currentLevel--;
            sceneName = "level_" + currentLevel.ToString();
            SceneManager.LoadScene(sceneName);
        }
    }

    private bool SceneExists(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string[] splitPath = scenePath.Split('/');
            string sceneNameFromPath = splitPath[splitPath.Length - 1].Replace(".unity", "");

            if (sceneNameFromPath == sceneName)
            {
                return true;
            }
        }
        return false;
    }

}
