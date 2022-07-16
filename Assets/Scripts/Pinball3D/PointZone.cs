using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointZone : MonoBehaviour
{

    public int basePointValue;
    private int currentPointValue;
    // Start is called before the first frame update
    void Start()
    {
        currentPointValue = basePointValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PinballController.Instance.IncrementPoints(currentPointValue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            PinballController.Instance.IncrementPoints(currentPointValue);
        }
    }
}
