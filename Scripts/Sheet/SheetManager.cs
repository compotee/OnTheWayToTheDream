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
            BikeText.text = "��������";
        else 
            BikeText.text = "������\n50 �����";

        if (Statuses.Phone)
            PhoneText.text = "������";
        else
            PhoneText.text = "������\n80 �����";

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
                NotificationText.text = "+ " + moneyRandom + " �����";
            }
            else
            {
                TimeWaiting = 5;
                NotificationAnim.SetBool("NotificationOpen", true);
                NotificationText.text = "���� ������ � �� ����� ������ ������";
            }
        }
        else
        {
            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            NotificationText.text = "���� �� ������";
        }
    }

    public void BikeButton()
    {
        if (!Statuses.Bike && Statuses.Money >= 50)
        {
            Statuses.Bike = true;
            BikeText.text = "��������";
            CanUpMood = true;
            Statuses.Money -= 50;
        }
        else if (!Statuses.Bike && Statuses.Money < 50)
        {
            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            NotificationText.text = "������������ ����� ��� �������";
        }
        else if (Statuses.Bike)
            MoodUpButton();
        
    }

    public void PhoneButoon()
    {
        if (!Statuses.Phone && Statuses.Money >= 80)
        {
            Statuses.Phone = true;
            PhoneText.text = "������";
            CanUpMoney = true;
            Statuses.Money -= 80;
        }
        else if (!Statuses.Phone && Statuses.Money < 80)
            NotificationText.text = "������������ ����� ��� �������";
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
            NotificationText.text = "���������� ����������!";
        }
        else
        {
            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            if ((int)Statuses.Mood == 99)
                NotificationText.text = "� ��� �������� ���������� � ��� �������� �� ����!";
            else
                NotificationText.text = "��������� ��� " + ((int)TimeMood).ToString() + " ���.";
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
            NotificationText.text = "+ 10 �����";
        }
        else
        {
            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            NotificationText.text = "��������� ��� " + ((int)TimeMoney).ToString() + " ���.";
        }
    }


    public void EndSheet()
    {
        SheetAnim.SetBool("SheetOpen", false);
        StartSheetAnim.SetBool("StartSheetOpen", true);
    }
}
