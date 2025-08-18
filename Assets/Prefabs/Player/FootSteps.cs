using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Массив для звуковых клипов шагов  
    public float minTimeBetweenFootsteps = 0.3f; // Минимальное время между звуками шагов  
    public float maxTimeBetweenFootsteps = 0.6f; // Максимальное время между звуками шагов  
    private AudioSource audioSource; // Ссылка на компонент AudioSource  
    private bool isWalking = false; // Флаг для отслеживания, идёт ли игрок  
    private float timeSinceLastFootstep; // Время с последнего звука шагов  
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //footstepSounds = new AudioClip[footstepSounds.Length];
    }
    private void Update()
    {
        // Проверяем, идёт ли игрок  
        if (isWalking)
        {
            // Проверяем, прошло ли достаточно времени для воспроизведения следующего звука шагов  
            if (Time.time - timeSinceLastFootstep >= Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps))
            {
                // Воспроизводим случайный звук шагов из массива  
                AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
                audioSource.PlayOneShot(footstepSound);
                timeSinceLastFootstep = Time.time; // Обновляем время с последнего звука шагов  
            }
        }
    }
    // Вызываем этот метод, когда игрок начинает ходить  
    public void StartWalking() { isWalking = true; }
    // Вызываем этот метод, когда игрок останавливается  
    public void StopWalking() { isWalking = false; }
}
