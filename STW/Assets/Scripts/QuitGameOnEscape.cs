using UnityEngine;

public class QuitGameOnEscape : MonoBehaviour
{
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Debug.Log("Quit Game");
      Application.Quit();
    }
  }
}
