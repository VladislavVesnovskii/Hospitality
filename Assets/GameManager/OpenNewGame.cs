using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenNewGame : MonoBehaviour
{
    public AudioSource AC;
    public AudioClip ac;


    public void OpenMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void PlaySound()
    {
        AC.PlayOneShot(ac);
    }
}
