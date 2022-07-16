using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbox : MonoBehaviour
{

    public Transform ballStartPosition;
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
        if(other.gameObject.name == "Pinball")
        {
            GameManager.Instance.ResetBall();
            other.transform.position = ballStartPosition.position;
            other.GetComponent<PinballMovement>().rb.velocity = Vector3.zero;
        }
    }
}
