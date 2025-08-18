using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] footstepSounds; // ������ ��� �������� ������ �����  
    public float minTimeBetweenFootsteps = 0.3f; // ����������� ����� ����� ������� �����  
    public float maxTimeBetweenFootsteps = 0.6f; // ������������ ����� ����� ������� �����  
    private AudioSource audioSource; // ������ �� ��������� AudioSource  
    private bool isWalking = false; // ���� ��� ������������, ��� �� �����  
    private float timeSinceLastFootstep; // ����� � ���������� ����� �����  
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //footstepSounds = new AudioClip[footstepSounds.Length];
    }
    private void Update()
    {
        // ���������, ��� �� �����  
        if (isWalking)
        {
            // ���������, ������ �� ���������� ������� ��� ��������������� ���������� ����� �����  
            if (Time.time - timeSinceLastFootstep >= Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps))
            {
                // ������������� ��������� ���� ����� �� �������  
                AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
                audioSource.PlayOneShot(footstepSound);
                timeSinceLastFootstep = Time.time; // ��������� ����� � ���������� ����� �����  
            }
        }
    }
    // �������� ���� �����, ����� ����� �������� ������  
    public void StartWalking() { isWalking = true; }
    // �������� ���� �����, ����� ����� ���������������  
    public void StopWalking() { isWalking = false; }
}
