using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

  public Animator transition;

  public float transitionTime = 1;



  public void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("Player") && !other.isTrigger)
    {
      LoadNextLevel();
    }
  }

  public void LoadNextLevel()
  {
    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
  }

  IEnumerator LoadLevel(int levelIndex)
  {
    //Add Animation by name
    transition.SetTrigger("Start");
    //add transitionTime
    yield return new WaitForSeconds(transitionTime);
    //load Scene depending on levelIndex
    SceneManager.LoadScene(levelIndex);


  }

}
