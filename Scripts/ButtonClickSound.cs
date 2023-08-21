using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    AudioSource clickAudioSource; // Unity Inspector'dan atanacak ses kayna��
    public AudioClip clip;

    private static ButtonClickSound instance;

    private void Awake()
    {
        
        // Birden fazla MusicPlayer nesnesi olu�mas�n� �nlemek i�in, e�er instance yoksa bu nesneyi instance olarak ayarlay�n
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // M�zik �alar� sahneler aras�nda korumak i�in DontDestroyOnLoad kullan�n
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
        Button[] buttons = FindObjectsOfType<Button>(); // B�t�n Button nesnelerini al
        foreach (Button button in buttons)
        {
            if (!button.CompareTag("MoveButton"))
            {
                button.onClick.AddListener(PlayClickSound); // Her butona PlayClickSound i�levini ekle

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
