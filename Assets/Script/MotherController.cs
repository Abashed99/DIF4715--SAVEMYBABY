using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherController : MonoBehaviour
{
    public float displayTime = 3.0f;
    public GameObject dialogBox;
    float timerDisplay;
    Animator animator;
    public AudioClip collectedClip;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(true);
        timerDisplay = 2.5f;
        animator = GetComponent<Animator>();
        animator.SetTrigger("OneBaby");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);

               animator.SetTrigger("NoBaby");
            }
        }

       
    }
}
