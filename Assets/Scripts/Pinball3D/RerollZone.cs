using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (other.transform.GetComponent<PinballMovement>().rb.velocity.z > 0)
            {
                GameManager.Instance.RollCurrentDice();
            }
            
        }
    }
}
