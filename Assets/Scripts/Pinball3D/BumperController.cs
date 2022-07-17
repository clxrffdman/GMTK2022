using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{

    public float bumpForceMultiplier;

    // Start is called before the first frame update

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PinballMovement>().rb.AddForce(collision.GetContact(0).normal * -bumpForceMultiplier, ForceMode.Impulse);
            AudioManager.Instance.PlayBoardSFX(0);
        }
    }
}
