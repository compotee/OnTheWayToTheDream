using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnAnimator : MonoBehaviour
{
    public Animator StartLearnAnim;
    public LearnManager lm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        StartLearnAnim.SetBool("StartLearnOpen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        StartLearnAnim.SetBool("StartLearnOpen", false);
        lm.EndLearn();
    }
}
