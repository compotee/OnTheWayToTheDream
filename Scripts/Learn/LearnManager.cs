using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Learn
{
    public string Topic;
    [TextArea(1, 40)]
    public string Materials;
}


public class LearnManager : MonoBehaviour
{
    public Text TopicText;
    public Text LearnText;

    public Animator LearnAnim;
    public Animator StartLearnAnim;

    public Learn[] Learn;
    private int Page;

    private void Start()
    {
        Page = 0;
    }

    public void StartLearn()
    {
        LearnAnim.SetBool("LearnOpen", true);
        StartLearnAnim.SetBool("StartLearnOpen", false);
        Page = -1;

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Page == Learn.Length - 2)
            EndLearn();
        
        Page += 1;
        var learnPage = Learn[Page];

        TopicText.text = learnPage.Topic;
        LearnText.text = learnPage.Materials;
    }

    public void BackButton()
    {
        if (Page == 0)
            return;

        Page -= 1;
        var learnPage = Learn[Page];
        
        TopicText.text = learnPage.Topic;
        LearnText.text = learnPage.Materials;
    }

    public void EndLearn()
    {
        LearnAnim.SetBool("LearnOpen", false);
    }
}
