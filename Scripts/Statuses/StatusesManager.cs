using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StatusesManager : MonoBehaviour
{
    public string level;
    public string nameLevel;
    public float speed;
    public TestPattern[] AllTests;

    public Text Level;
    public Text NameLevel;
    public Text Mood;
    public Text Knowledge;
    public Text Money;

    void Start()
    {
        Statuses.Mood = 100;
        Statuses.Money = 0;
        Statuses.Know = 0;
        Statuses.Bike = false;
        Statuses.Phone = false;
        Statuses.Tests = new List<TestPattern>(AllTests);

        Level.text = "Уровень " + level + ":";
        NameLevel.text = nameLevel;
        Knowledge.text = Statuses.Know + "%";
        Money.text = Statuses.Money.ToString() + " монет";
    }

    private void Update()
    {
        if (Statuses.Mood >= 0)
        {
            Statuses.Mood -= Time.deltaTime * speed;
            Mood.text = ((int)Statuses.Mood + 1).ToString() + "/100";
        }
        else 
        {
            Mood.text = "0/100";
        }

        Knowledge.text = Statuses.Know + "%";
        Money.text = Statuses.Money.ToString() + " монет";
    }

    public void BackClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
