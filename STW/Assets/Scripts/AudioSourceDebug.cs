using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceDebug : MonoBehaviour
{

  AudioSource[] sources;

  void Start()
  {

    //Get every single audio sources in the scene.
    sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];

  }

  void Update()
  {

    // When a key is pressed list all the gameobjects that are playing an audio
    if (Input.GetKeyUp(KeyCode.A))
    {

      foreach (AudioSource audioSource in sources)
      {
        if (audioSource.isPlaying) Debug.Log(audioSource.name + " is playing " + audioSource.clip.name);
      }
      Debug.Log("---------------------------"); //to avoid confusion next time
      Debug.Break(); //pause the editor

    }
  }
}
