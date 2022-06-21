using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetTrigger : MonoBehaviour
{
    public void TriggerSheet()
    {
        FindObjectOfType<SheetManager>().StartSheet();
    }
}
