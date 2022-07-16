using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballController : MonoBehaviour
{
    public float currentPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementPoints(float offset)
    {
        currentPoints += offset;
    }

    public void MultiplyPoints(float multiplier) {
        currentPoints *= multiplier;
    }
}
