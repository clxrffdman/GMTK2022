using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballController : MonoBehaviour
{
    public static PinballController Instance;
    public int currentPoints;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementPoints(int offset)
    {
        currentPoints += offset;
    }

    public void MultiplyPoints(int multiplier) {
        currentPoints *= multiplier;
    }
}
