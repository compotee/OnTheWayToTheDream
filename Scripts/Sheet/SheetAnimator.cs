using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetAnimator : MonoBehaviour
{
    public Animator StartSheetAnim;

    public void OnTriggerEnter2D(Collider2D other)
    {
        StartSheetAnim.SetBool("StartSheetOpen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        StartSheetAnim.SetBool("StartSheetOpen", false);
    }
}
