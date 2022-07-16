using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationZone : MonoBehaviour
{

    public float speedMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if(other.transform.GetComponent<PinballMovement>().rb.velocity.z > 0)
            {
                other.transform.GetComponent<PinballMovement>().ModifyBallVelocity(speedMultiplier);
            }
            
        }
    }
}
