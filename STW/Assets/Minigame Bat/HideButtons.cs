using UnityEngine;
using UnityEngine.UI;

public class HideButtons : MonoBehaviour
{
  private Button storyButton;
  
  private void Start()
  {
    storyButton = GetComponent<Button>();
    storyButton.onClick.AddListener(HideButton);
   }

  private void HideButton()
  {
    storyButton.gameObject.SetActive(false);
  }
}
