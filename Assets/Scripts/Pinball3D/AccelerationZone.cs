using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationZone : MonoBehaviour
{

    public float speedMultiplier;
    public bool up;
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
            if (up)
            {
                if (other.transform.GetComponent<PinballMovement>().rb.velocity.z > 0.05f)
                {
                    other.transform.GetComponent<PinballMovement>().ModifyBallVelocity(speedMultiplier);
                }
            }
            else
            {
                if (other.transform.GetComponent<PinballMovement>().rb.velocity.z < 0.05f)
                {
                    other.transform.GetComponent<PinballMovement>().ModifyBallVelocity(speedMultiplier);
                }
            }
            
            
        }
    }
}
