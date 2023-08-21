using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

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

   

    // Daha fazla kod ve iþlevselliði buraya ekleyebilirsiniz
}
