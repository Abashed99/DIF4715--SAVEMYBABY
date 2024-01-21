using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby1 : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float displayTime = 3.0f;
    float timerDisplay;

    public FiremanController firemanController;
    AudioSource audioSource;
    public AudioClip collectedClip;
    public AudioSource musicSource;
    public AudioClip musicClipLose;
    public AudioClip musicClipWin;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        GameObject firemanControllerObject = GameObject.FindWithTag("FiremanController");
        audioSource = GetComponent<AudioSource>();
        timerDisplay = 2.5f;
        Physics2D.IgnoreLayerCollision(2, 3);
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0.2f;
                audioSource.PlayOneShot(collectedClip);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        FiremanController controller = other.gameObject.GetComponent<FiremanController>();

        if (controller != null)
        {
            Destroy(gameObject);
            winTextObject.SetActive(true);
            musicSource.clip = musicClipWin;
            musicSource.Play();
        }
        else
        {
            loseTextObject.SetActive(true);
            musicSource.clip = musicClipLose;
            musicSource.Play();
            Destroy(gameObject);
        }

    }

}
