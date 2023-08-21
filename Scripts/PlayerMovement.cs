using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public Vector3 BodyPos;
    public AudioClip cýnSound;
    public AudioClip jumpSound;
    public AudioClip hurtSound;
    public AudioSource audio;
    public Rigidbody2D rgb;
    Vector3 velocity;
    public float speedAmount = 5f,jumpAmount=8f;
    public Animator animator;
    public int score = 0;
    public int life = 3;
    public int stars = 0;
    int scoretut=0;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI timeText;
    public GameObject successMenu;
    public AudioClip runningSound;
    public bool isGrounded=false;

    float raycastDistance = 0.6f;
    public LayerMask raycastLayerMask;
    
    bool touchingLeft = false;
    bool touchingRight = false;

    public GameObject heartBreak;
    float time;
    MusicPlayer mp;
    ButtonClickSound bcs;
    public float horizontal = 0;
    public bool jump=false;
    // Start is called before the first frame update
    void Start()
    {
        //int nextLevelInt = int.Parse(SceneManager.GetActiveScene().name.Split('_')[1]) + 1;
        //Debug.Log(int.Parse(SceneManager.GetActiveScene().name.Split('_')[1])+1);
        time = 0;
        Time.timeScale = 1;
        rgb = GetComponent<Rigidbody2D>();
        // panel = GameObject.Find("Basarili_panel");

        audio = gameObject.GetComponent<AudioSource>();

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        timeText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();

        successMenu.SetActive(false);

        GameObject gameSong = GameObject.FindGameObjectWithTag("GameSong");
        mp= gameSong.GetComponent<MusicPlayer>();
        mp.SetVolume(0.5f);
        mp.ResetPitch();

        GameObject buttonClickSoundObject = GameObject.Find("ButtonClickSound");
        ButtonClickSound bcs; bcs = buttonClickSoundObject.GetComponent<ButtonClickSound>();
        bcs.FindButtons();
        
        //PlayerPrefs.DeleteAll();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        BodyPos = transform.position;
        //horizontal = Input.GetAxis("Horizontal");
        //jump = Input.GetButtonDown("Jump");

        if ((touchingRight&&horizontal>=0)||(touchingLeft&& horizontal <= 0))
        {
           
        }
        else
        {
            if (Mathf.Abs(horizontal) > 0){
                Walk();
            }
            
            
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontal));


        if (jump && isGrounded)
        {
            Jump();
            
        }
        jump = false;

        if (!animator.GetBool("isJumping") && !isGrounded)
        {
            animator.SetBool("isJumping", true);
        }

        if (animator.GetBool("isJumping") && isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        if (horizontal <0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        scoreText.text = "Score: " + score;
        timeText.text = "Time: " + ((int)time);

        if (scoretut < score)
        {
            scoretut = score;
            audio.PlayOneShot(cýnSound);
        }

        if (score >= 10 && successMenu.active==false)
        {
            successMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if(transform.position.y < -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Mathf.Abs(horizontal)>0.1 && isGrounded && !audio.isPlaying)
        {
            PlayRunningSound();
        }

        Vector2 rightDirection = Vector2.right; // Karakter saða doðru hareket ediyorsa
        Vector2 leftDirection = Vector2.left; // Karakter sola doðru hareket ediyorsa

        // Saða doðru Raycast'i oluþturun
        RaycastHit2D rightHit = Physics2D.Raycast(rgb.position, rightDirection, raycastDistance,raycastLayerMask);

        // Sol'a doðru Raycast'i oluþturun
        RaycastHit2D leftHit = Physics2D.Raycast(rgb.position, leftDirection, raycastDistance,raycastLayerMask);

        // Saða doðru Raycast ile çarpýþma olup olmadýðýný kontrol edin
        if (rightHit.collider !=null)
        {
           
            touchingRight = true;
        }
        else
        {
            
            touchingRight = false;
        }
        // Sol'a doðru Raycast ile çarpýþma olup olmadýðýný kontrol edin
        if (leftHit.collider!=null)
        {
            
            touchingLeft = true;
        }
        else
        {
            
            touchingLeft = false;
        }
    }

    

    public void Hurt()
    {
        life--;

        switch (life)
        {
            case 2:
                GameObject.Find("heart_1").SetActive(false);
                break;
            case 1:
                GameObject.Find("heart_2").SetActive(false);
                break;
            case 0:
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            default:
                break;
        }

        audio.PlayOneShot(hurtSound);

        GameObject hrtBrk= Instantiate(heartBreak, transform.position, heartBreak.transform.rotation);
        hrtBrk.GetComponent<ParticleSystem>().Play();

        mp.IncreasePitch(0.3f);
    }

    public void PlayRunningSound()
    {
        audio.PlayOneShot(runningSound);
    }

    void Jump()
    {
        
        rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
        //animator.SetBool("isJumping", true);
        
        audio.PlayOneShot(jumpSound);
        
        
    }

    void Walk()
    {
        velocity = new Vector3(horizontal, 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
       
    }

    public float getTime()
    {
        return time;
    }
    
}
