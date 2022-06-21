using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class MoodManager : MonoBehaviour
{
    private bool CanUp;
    private float Time;
    private float TimeWaiting;

    public Animator NotificationAnim;
    public Text NotificationText;

    // Start is called before the first frame update
    void Start()
    {
        TimeWaiting = 0;
        Time = 0;
        CanUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time > 0)
            Time -= UnityEngine.Time.deltaTime;
        if (Time <= 0 && Statuses.Mood < 99)
            CanUp = true;

        if(TimeWaiting > 0)
            TimeWaiting -= UnityEngine.Time.deltaTime;
        else
            NotificationAnim.SetBool("NotificationOpen", false);
    }

    public void MoodUpButton()
    {
        if (CanUp)
        {
            Time = 60;
            CanUp = false;

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
                NotificationText.text = "Подождите ещё " + ((int)Time).ToString() + " сек.";
        }
    }
}
