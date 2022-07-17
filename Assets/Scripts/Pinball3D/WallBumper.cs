using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBumper : BumperController
{

    public Transform target;
    // Start is called before the first frame update
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            //collision.transform.GetComponent<PinballMovement>().rb.AddForce(Vector3.Normalize(collision.GetContact(0).normal) * -bumpForceMultiplier, ForceMode.Impulse);
            collision.transform.GetComponent<PinballMovement>().rb.AddForce((target.transform.position- this.transform.position).normalized * bumpForceMultiplier, ForceMode.Impulse); 
            AudioManager.Instance.PlayBoardSFX(0);
        }
    }
}
