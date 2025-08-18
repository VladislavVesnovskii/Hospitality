using UnityEngine;
using System.Runtime.InteropServices;

public class AdsYandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowFullscreen();

    [DllImport("__Internal")]
    private static extern void ShowRewarded();
    [DllImport("__Internal")]
    private static extern void LoadingAPIReady();
    [DllImport("__Internal")]
    private static extern void GameplayAPIStart();
    [DllImport("__Internal")]
    private static extern void GameplayAPIStop();

    [DllImport("__Internal")]
    private static extern string GetLang();

    public string GetLanguage()
    {
        return GetLang();
    }

    public void Show1()
    {
        ShowFullscreen();
    }

    public void Show2()
    {
        ShowRewarded();
    }

    public void OnLoadingAPIReady()
    {
        LoadingAPIReady();
    }
    public void OnGameplayAPIStart()
    {
        GameplayAPIStart();
    }
    public void OnGameplayAPIStop()
    {
        GameplayAPIStop();
    }

}

