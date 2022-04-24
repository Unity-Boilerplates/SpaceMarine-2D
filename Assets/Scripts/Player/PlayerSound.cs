using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [Header ("Player Controller")]
        [SerializeField] PlayerController playerController;

    [Header("Clips")]
        [SerializeField] AudioClip inAirClip;
        [SerializeField] AudioClip shotClip;
        [SerializeField] AudioClip walkClip;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayShot()
    {
        audioSource.PlayOneShot(shotClip);
    }



}
