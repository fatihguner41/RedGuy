using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    AudioSource clickAudioSource; // Unity Inspector'dan atanacak ses kaynaðý
    public AudioClip clip;

    private static ButtonClickSound instance;

    private void Awake()
    {
        
        // Birden fazla MusicPlayer nesnesi oluþmasýný önlemek için, eðer instance yoksa bu nesneyi instance olarak ayarlayýn
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Müzik çalarý sahneler arasýnda korumak için DontDestroyOnLoad kullanýn
        }
        else
        {
            // Birden fazla MusicPlayer nesnesi varsa, bunu yok edin
            Destroy(gameObject);
        }


        
    }


    public void FindButtons()
    {
        clickAudioSource = GetComponent<AudioSource>();
        Button[] buttons = FindObjectsOfType<Button>(); // Bütün Button nesnelerini al
        foreach (Button button in buttons)
        {
            if (!button.CompareTag("MoveButton"))
            {
                button.onClick.AddListener(PlayClickSound); // Her butona PlayClickSound iþlevini ekle

            }
        }
    }
    public void PlayClickSound()
    {
        if (clickAudioSource != null)
        {
            clickAudioSource.PlayOneShot(clip);
        }
    }
}
