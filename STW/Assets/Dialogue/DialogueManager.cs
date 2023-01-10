using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

  private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
    sentences = new Queue<string>();
    }

  public void StartDialogue (Dialogue dialogue)
  {
    Debug.Log("Beginne Gespräch mit:" + dialogue.name);
  }
}
