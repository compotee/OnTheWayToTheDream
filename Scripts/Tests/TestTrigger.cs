using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    public void TriggerTest()
    {
        FindObjectOfType<TestManager>().StartTest();
    }
}
