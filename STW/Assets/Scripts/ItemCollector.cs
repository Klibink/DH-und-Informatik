using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
  private int counter = 0;

  [SerializeField] private Text WaterText;

    private void OnTriggerEnter2d(Collider2D collision)
    {
      if(collision.gameObject.CompareTag("Waterdrop"))
      {
        Destroy(collision.gameObject);
        counter++;
        WaterText.text = "Wasser: " + counter + "Liter";
      }
    }
}