using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheetManager : MonoBehaviour
{
    public Text BikeText;
    public Text PhoneText;
    public Text WarningText;

    public Animator StartSheetAnim;
    public Animator SheetAnim;

    public Animator NotificationAnim;
    public Text NotificationText;
    private float TimeWaiting;


    private bool CanUseHelp;
    private bool CanUpMood;
    private bool CanUpMoney;
    private float TimeHelp;
    private float TimeMood;
    private float TimeMoney;

    private void Start()
    {
        if (Statuses.Bike)
            BikeText.text = "Кататься";
        else 
            BikeText.text = "Купить\n50 монет";

        if (Statuses.Phone)
            PhoneText.text = "Играть";
        else
            PhoneText.text = "Купить\n80 монет";

        CanUpMood = false;
        CanUpMoney = false;
        CanUseHelp = true;
    }

    void Update()
    {
        if (TimeWaiting > 0)
            TimeWaiting -= Time.deltaTime;
        else
            NotificationAnim.SetBool("NotificationOpen", false);

        if (TimeHelp > 0)
            TimeHelp -= Time.deltaTime;
        else
            CanUseHelp = true;

        if (TimeMood > 0)
            TimeMood -= Time.deltaTime;
        else
            CanUpMood = true;

        if (TimeMoney > 0)
            TimeMoney -= Time.deltaTime;
        else
            CanUpMoney = true;
    }

    public void StartSheet()
    {
        SheetAnim.SetBool("SheetOpen", true);
        StartSheetAnim.SetBool("StartSheetOpen", false);
    }

    public void HelpButton()
    {
        if (CanUseHelp)
        {
            TimeHelp = 180;
            CanUseHelp = false;

            var random = Random.Range(0, 5);
            var moneyRandom = Random.Range(30, 100);
            if (random == 2)
            {
                TimeWaiting = 5;
                Statuses.Money += moneyRandom;
                NotificationAnim.SetBool("NotificationOpen", true);
                NotificationText.text = "+ " + moneyRandom + " монет";
            }
            else
            {
                TimeWaiting = 5;
                NotificationAnim.SetBool("NotificationOpen", true);
                NotificationText.text = "Мама злится и не хочет давать деньги";
            }
        }
        else
        {
            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            NotificationText.text = "Мама на работе";
        }
    }

    public void BikeButton()
    {
        if (!Statuses.Bike && Statuses.Money >= 50)
        {
            Statuses.Bike = true;
            BikeText.text = "Кататься";
            CanUpMood = true;
            Statuses.Money -= 50;
        }
        else if (!Statuses.Bike && Statuses.Money < 50)
        {
            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            NotificationText.text = "Недостаточно монет для покупки";
        }
        else if (Statuses.Bike)
            MoodUpButton();
        
    }

    public void PhoneButoon()
    {
        if (!Statuses.Phone && Statuses.Money >= 80)
        {
            Statuses.Phone = true;
            PhoneText.text = "Играть";
            CanUpMoney = true;
            Statuses.Money -= 80;
        }
        else if (!Statuses.Phone && Statuses.Money < 80)
            NotificationText.text = "Недостаточно монет для покупки";
        else if (Statuses.Phone)
            MoneyUpButton();
    }

    public void MoodUpButton()
    {
        if (CanUpMood && Statuses.Mood < 99)
        {
            TimeMood = 60;
            CanUpMood = false;

            if (Statuses.Mood < 90)
                Statuses.Mood += 10;

            else
                Statuses.Mood = 100;

            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            NotificationText.text = "Настроение повысилось!";
        }
        else
        {
            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            if ((int)Statuses.Mood == 99)
                NotificationText.text = "У вас отличное настроение и его повышать не надо!";
            else
                NotificationText.text = "Подождите ещё " + ((int)TimeMood).ToString() + " сек.";
        }
    }

    public void MoneyUpButton()
    {
        if (CanUpMoney)
        {
            TimeMoney = 60;
            CanUpMoney = false;
            Statuses.Money += 10;

            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            NotificationText.text = "+ 10 монет";
        }
        else
        {
            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            NotificationText.text = "Подождите ещё " + ((int)TimeMoney).ToString() + " сек.";
        }
    }


    public void EndSheet()
    {
        SheetAnim.SetBool("SheetOpen", false);
        StartSheetAnim.SetBool("StartSheetOpen", true);
    }
}
