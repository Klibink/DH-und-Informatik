using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Signs : MonoBehaviour
{

  public GameObject dialogBox;
  public TextMeshProUGUI dialogText;
  public string dialog;
  public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
      {
        if(dialogBox.activeInHierarchy)
      {
        dialogBox.SetActive(false);
      } else
      {
        dialogBox.SetActive(true);
        dialogText.text = dialog;
      }
      }
    }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      playerInRange = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      playerInRange = false;
      dialogBox.SetActive(false);
    }
  }

}
