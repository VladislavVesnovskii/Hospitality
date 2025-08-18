using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastTrigger : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OpenCutScene2();
        }
    }
    public void OpenCutScene2()
    {
        SceneManager.LoadScene("CutScene2");
    }
}
