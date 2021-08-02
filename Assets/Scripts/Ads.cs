using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour, IUnityAdsListener
{
    private static Ads _instance;
    public static Ads instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Ads>();
            return _instance;
        }
    }

    string gameId = "4192085";
    bool testMode = false;
    public static bool Reklama = true;

    public string bannerID = "Banner_Android";
    public string rewardedID = "Rewarded_Android";
    public string videoID = "Interstitial_Android";

    public void ShowVideo()
    {
        if (Reklama)
        {
            Advertisement.Show(videoID);
        }
    }

    public void ShowRewardedVideo()
    {
        if (Reklama)
        {
            Advertisement.Show(rewardedID);
        }
    }

    void Start()
    {
        StartCoroutine(ShowBannerWhenReady());
    }

    public void StopReklama()
    {
        StopCoroutine(ShowBannerWhenReady());
        Advertisement.Banner.Hide(true);
    }

    IEnumerator ShowBannerWhenReady()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);

        while (!Advertisement.IsReady(bannerID))
        {
            yield return new WaitForSeconds(0.1f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(bannerID);
    }
    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == rewardedID)
        {
            if (showResult == ShowResult.Finished)
            {
                //StateMachine.instance.SwitchState(StateMachine.States.Continue);
            }
            else
            {
                //StateMachine.instance.SwitchState(StateMachine.States.Restart);
            }
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }
}