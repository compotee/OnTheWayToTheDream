using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodAnimator : MonoBehaviour
{
    public Animator StartMoodUpAnim;

    public void OnTriggerEnter2D(Collider2D other)
    {
        StartMoodUpAnim.SetBool("MoodUpOpen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        StartMoodUpAnim.SetBool("MoodUpOpen", false);
    }
}
