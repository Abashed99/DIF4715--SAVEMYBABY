using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour
{
     public float speed = 2.0f;
     Rigidbody2D rigidbody2d;
     float horizontal;
     float vertical;
     Animator animator;
     Vector2 lookDirection = new Vector2(0,0);
     public int maxHealth = 1;
     public int health { get { return currentHealth; } }
     int currentHealth;
     AudioSource audioSource;
     public AudioSource musicSource;
     public AudioClip collectedClip;
     public AudioClip musicClipLose;
     public AudioClip musicClipWin;
     public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
       rigidbody2d = GetComponent<Rigidbody2D>(); 
       gameOver = false;
       animator = GetComponent<Animator>();
       audioSource = GetComponent<AudioSource>();
       currentHealth = maxHealth;
       animator.SetFloat("MoveX", 1);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

       Vector2 move = new Vector2(horizontal, vertical);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetFloat("MoveX", -2);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetFloat("MoveX", 1);
        }

         if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetFloat("MoveX", 2);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetFloat("MoveX", 1);
        }

    }

    void FixedUpdate()
    {
       if (gameOver == false)
       { 
       Vector2 position = rigidbody2d.position;
       
        position.x = position.x + speed * horizontal * Time.deltaTime;

        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
       }
    }

     public void ChangeHealth(int amount)
    {

        if (health == 0)
        {
            gameOver = true;
            musicSource.clip = musicClipLose;
            musicSource.Play();
        }

        if (health == 2)
        {
            gameOver = true;
            musicSource.clip = musicClipWin;
            musicSource.Play();
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
      
    }
}

