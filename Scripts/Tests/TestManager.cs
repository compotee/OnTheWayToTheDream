using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class TestPattern
{
    public string Question;
    public string[] Answers;
    public int Price;
}

public class TestManager : MonoBehaviour
{
    public Text[] AnswersText;
    public Text QuestionText;
    public Text RightOrNotText;

    public Animator StartTestAnim;
    public Animator TestAnim;
    public Animator RightOrNOtAnim;

    private float TimeWaiting;
    public Animator NotificationAnim;
    public Text NotificationText;

    private int Random;
    private TestPattern Test;

    // Start is called before the first frame update
    void Start()
    {
        TimeWaiting = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeWaiting > 0)
            TimeWaiting -= UnityEngine.Time.deltaTime;
        else
            NotificationAnim.SetBool("NotificationOpen", false);
    }

    public void StartTest()
    {
        TestAnim.SetBool("TestOpen", true);
        StartTestAnim.SetBool("StartTestOpen", false);

        QuetsionGenerate();
    }

    private void QuetsionGenerate()
    {
        if (Statuses.Tests.Count > 0 && Statuses.Mood > 74)
        {
            Random = UnityEngine.Random.Range(0, Statuses.Tests.Count);
            Test = Statuses.Tests[Random];

            var answers = new List<string>(Test.Answers);

            QuestionText.text = Test.Question;

            for (var i = 0; i < Test.Answers.Length; i++)
            {
                var rendomAnswers = UnityEngine.Random.Range(0, answers.Count);
                AnswersText[i].text = answers[rendomAnswers];
                answers.RemoveAt(rendomAnswers);
            }
        }
        else if (Statuses.Tests.Count == 0)
        {
            
            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            NotificationText.text = "Вопросы закончились.";
            EndTest();
            print("Вы прошли игру");
        }
        else if (Statuses.Mood < 74)
        {
            TimeWaiting = 5;
            NotificationAnim.SetBool("NotificationOpen", true);
            NotificationText.text = "Повысьте настроение";
            EndTest();
            print("Повысьте настроение");
        }
    }

    public void AnswersButtons(int index) 
    {
        if (AnswersText[index].text.ToString() == Test.Answers[0])
        {
            RightOrNOtAnim.SetBool("RightOrNotOpen", true);
            RightOrNotText.text = "Правильный ответ\n+ " + Test.Price + " монет";
            print("Правильный ответ");
            Statuses.Tests.RemoveAt(Random);
            Statuses.Money += Test.Price;
            if (Statuses.Know == 92.4)
                Statuses.Know = 100;
            else
                Statuses.Know += 6.6;
        }
        else
        {
            RightOrNOtAnim.SetBool("RightOrNotOpen", true);
            RightOrNotText.text = "Неправильный ответ";
            print("Неправильный ответ");
        }

        Statuses.Mood -= 4;
        QuetsionGenerate();
    }

    public void NextClick()
    {
        RightOrNOtAnim.SetBool("RightOrNotOpen", false);
    }

    public void EndTest()
    {
        TestAnim.SetBool("TestOpen", false);
        RightOrNOtAnim.SetBool("RightOrNotOpen", false);
    }
}
