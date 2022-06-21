using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimator : MonoBehaviour
{
    public Animator StartTestAnim;
    public TestManager tm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        StartTestAnim.SetBool("StartTestOpen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        StartTestAnim.SetBool("StartTestOpen", false);
        tm.EndTest();
    }
}
