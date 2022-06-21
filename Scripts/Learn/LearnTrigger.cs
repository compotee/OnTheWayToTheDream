using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnTrigger : MonoBehaviour
{
    public void TriggerLearn()
    {
        FindObjectOfType<LearnManager>().StartLearn();
    }
}
