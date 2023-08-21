using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

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

    public void SetVolume(float vol)
    {
        GetComponent<AudioSource>().volume = vol;
    }
    public void IncreasePitch(float addedPitch)
    {
        GetComponent<AudioSource>().pitch += addedPitch;
    }

    public void ResetPitch()
    {
        GetComponent<AudioSource>().pitch = 1;
    }

   

    // Daha fazla kod ve i�levselli�i buraya ekleyebilirsiniz
}
