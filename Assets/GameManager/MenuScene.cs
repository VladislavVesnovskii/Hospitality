using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    [SerializeField] Menu menu;
    [SerializeField] AdsYandex AY;
    [SerializeField] string languageISO;
    private void Awake()
    {
       menu = FindObjectOfType<Menu>();
       AY = FindObjectOfType<AdsYandex>();
       AY.OnLoadingAPIReady();
       languageISO = AY.GetLanguage();
       menu.SetLanguage(languageISO);
    }

    public void StartNewGame()
    {
        SaveSystem.ResetData();
        //EventBus.OnResetGame?.Invoke();
        StartCoroutine(MainSceneDelay());
    }
    IEnumerator MainSceneDelay()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(1);
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(1);
    }

}
