using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitZone : MonoBehaviour
{
    public GameObject effectWall;
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
        if (other.transform.tag == "Player")
        {
            effectWall.SetActive(true);
            GameManager.Instance.isLaunching = false;
        }


    }

    public void ResetEffectWall()
    {
        effectWall.SetActive(false);
    }
}
