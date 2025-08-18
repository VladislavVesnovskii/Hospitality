using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Menu : MonoBehaviour
{
    public int language;
    public int firstGame;
    [SerializeField] TMP_Text startGameButtonText;
    [SerializeField] TMP_Text continueGameButtonText;
    [SerializeField] TMP_Text gameName;
    [SerializeField] TMP_Text sign;
    [SerializeField] TMP_Text yesButton;
    [SerializeField] TMP_Text noButton;



    void Start()
    {
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("NoReboot");
        //if (objs.Length > 1)
        //Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLanguage(string lang)
    {
        if (lang != null)
        {
            if(lang == "ru")
            {
                SetRussianLanguage();
            }
            else
            {
                SetEnglishLanguage();
            }
        }
        else
        {
            SetEnglishLanguage();
        }
    }

    public void SetEnglishLanguage()
    {
        language = 0;
        startGameButtonText.text = "Start new game";
        continueGameButtonText.text = "Continue";
        gameName.text = "HOSPITALITY";
        sign.text = "All saved data will be deleted! \n Do you still want to continue?";
        yesButton.text = "YES";
        noButton.text = "NO";
    }

    public void SetRussianLanguage()
    {
        language = 1;
        startGameButtonText.text = "Начать новую игру";
        continueGameButtonText.text = "Продолжить";
        gameName.text = "ГОСТЕПРИИМСТВО";
        sign.text = "Все сохраненные данные будут удалены! \n Вы все равно хотите продолжить?";
        yesButton.text = "ДА";
        noButton.text = "НЕТ";
    }

}
