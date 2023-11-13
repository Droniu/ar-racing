using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textAccelerometer : MonoBehaviour
{
    
    public string textValue;
    public Text textElement;
    // Start is called before the first frame update
    void Start()
    {
        textElement.text = "Accelerometer Data: ";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acceleration = Input.acceleration;

        textElement.text = "Accelerometer Data: " + acceleration.ToString(); 
    }
}
