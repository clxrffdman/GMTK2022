using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{

    public float bumpForceMultiplier;
    public int pointWorth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PinballMovement>().rb.AddForce(collision.GetContact(0).normal * -bumpForceMultiplier, ForceMode.Impulse);
            PinballController.Instance.IncrementPoints(pointWorth);
        }
    }
}
