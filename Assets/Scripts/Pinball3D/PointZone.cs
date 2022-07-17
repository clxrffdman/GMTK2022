using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointZone : MonoBehaviour
{

    public int basePointValue;
    public float currentPointValue;
    // Start is called before the first frame update
    void Start()
    {
        currentPointValue = basePointValue;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PinballController.Instance.IncrementPoints((int)currentPointValue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            PinballController.Instance.IncrementPoints((int)currentPointValue);
        }
    }
}
