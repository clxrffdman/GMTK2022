using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float constDownforce;
    public float constDownforceMult;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0,-constDownforce * constDownforceMult,-constDownforce));
    }
}
