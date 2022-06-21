using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public Animator rulesAnim;

    public void PlayClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RulesClick()
    {
        rulesAnim.SetBool("RulesOpen", true);
    }

    public void EndClick()
    {
        print("Закрыта");
        Application.Quit();
    }
}
