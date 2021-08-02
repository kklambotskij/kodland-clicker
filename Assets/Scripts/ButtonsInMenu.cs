using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsInMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }    

    public void PythonButtonEnter()
    {
        SceneManager.LoadScene(2);
    }
    public void LinkKodland()
    {
        Application.OpenURL("https://www.kodland.org/");
    }

    public void LinkYouTube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCJR2aJyOZsniAXdgEBEHOrw");
    }
    public void LinkFaceBook()
    {
        Application.OpenURL("https://www.facebook.com/kodland.school/");
    }
    public void LinkInstagramm()
    {
        Application.OpenURL("https://www.instagram.com/kodland.school/");
    }

    public void JoinDiscord()
    {
        Application.OpenURL("https://discord.gg/ZAKz7bmQTT");
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
    }
    public void SupportButton()
    {
        Ads.instance.ShowRewardedVideo();
    }

    public void RateMyAppButton()
    {
        Application.OpenURL("market://details?id=" + Application.productName);
    }
}
