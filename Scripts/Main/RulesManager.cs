using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Rules
{
    [TextArea(1, 40)]
    public string Materials;
    public bool Click;
}

public class RulesManager : MonoBehaviour
{
    public Text RulesText;

    public Animator RulesAnim;
    public Animator ClickAnim;

    public Rules[] Rules;
    private int Page;

    private void Start()
    {
        var learnPage = Rules[0];
        RulesText.text = learnPage.Materials;
    }

    public void DisplayNextSentence()
    {
        if (Page == Rules.Length - 1)
            return;

        Page += 1;
        var learnPage = Rules[Page];
        if (learnPage.Click)
            ClickAnim.SetBool("ClickOpen", true);
        else
            ClickAnim.SetBool("ClickOpen", false);
        RulesText.text = learnPage.Materials;
    }

    public void BackButton()
    {
        if (Page == 0)
            return;

        Page -= 1;
        var learnPage = Rules[Page];

        if (learnPage.Click)
            ClickAnim.SetBool("ClickOpen", true);
        else
            ClickAnim.SetBool("ClickOpen", false);

        RulesText.text = learnPage.Materials;
    }

    public void EndRules()
    {
        RulesAnim.SetBool("RulesOpen", false);
        ClickAnim.SetBool("ClickOpen", false);
    }
}
