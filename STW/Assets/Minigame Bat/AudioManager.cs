using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioManager : MonoBehaviour
{
    private AudioSource backgroundMusic;

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        if (backgroundMusic == null)
        {
            Debug.LogError("Sound not found");
        }     
    }

    private void Update() 
    {
        backgroundMusic.Play();
    }
    }
