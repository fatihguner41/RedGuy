using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Levels : MonoBehaviour
{
    string levelText;
    // Start is called before the first frame update
    void Start()
    {
        levelText = transform.Find("Text").gameObject.GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        if (PlayerPrefs.GetInt("CurrentLevel") >= int.Parse(gameObject.name.Split('_')[1]))
        {
            SceneManager.LoadScene(gameObject.name);
        }
        else
        {
            Transform t=transform.Find("Text");
            t.gameObject.GetComponent<Text>().text="Locked";
            t.gameObject.GetComponent<Text>().color = Color.red;
            Invoke("ClearText", 1f);
        }
        
        
    }

    public void ClearText()
    {
        Transform t = transform.Find("Text");
        t.gameObject.GetComponent<Text>().text = levelText;
        t.gameObject.GetComponent<Text>().color = Color.black;
    }
}
