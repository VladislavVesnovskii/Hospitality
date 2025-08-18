using System.Collections;
using System.Collections.Generic;
//using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public int health;
    [SerializeField] Image blackPanel;
    [SerializeField] float alfa;
    public GameObject[] healthArray;



    private void Start()
    {
        Invoke("Kostil", 0.1f);
    }

    void Kostil()
    {
        for (int i = 0; i < health; i++)
        {
            healthArray[i].SetActive(true);
        }
    }
    public void TakeDamage(int Damage)
    {
        health -= Damage;
        EventBus.OnSaveGame?.Invoke();
        GetKnockOut();
        
    }

    public void ChooseScene()
    {
        if (health <= 0)
        {
            //SaveSystem.ResetData();
            health = 3;
            EventBus.OnSaveGame?.Invoke();
            OpenCutScene1();
        }
        else
        {

            OpenSampleScene();
        }
    }
    void OpenCutScene1()
    {
        SceneManager.LoadScene("CutScene1");
    }

    void GetKnockOut()
    {
        StartCoroutine(BlackPanel()); 
    }

    void OpenSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator BlackPanel()
    {
        yield return new WaitForSeconds(0.1f);
        alfa += 0.05f;
        blackPanel.color = new Color(blackPanel.color.r, blackPanel.color.g, blackPanel.color.b, alfa);
        StartCoroutine(BlackPanel());
        if (alfa >= 1)
        {
            ChooseScene();
            blackPanel.color = Color.black;
            StopCoroutine(BlackPanel());
        }
    }

}
