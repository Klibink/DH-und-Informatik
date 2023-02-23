using UnityEngine;
using UnityEngine.UI;

public class HideOnClick : MonoBehaviour
{
  private Button button;

  private void Start()
  {
    button = GetComponent<Button>();
    button.onClick.AddListener(HideButton);
  }

  private void HideButton()
  {
    button.gameObject.SetActive(false);
  }
}
