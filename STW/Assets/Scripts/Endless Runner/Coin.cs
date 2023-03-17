using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Ändert fortlaufend die Rotation des Münzobjekts
public class Coin : MonoBehaviour
{
    public int rotationSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
}
