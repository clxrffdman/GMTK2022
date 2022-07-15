using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public Slider bar;
    // Start is called before the first frame update
    void Start()
    {
        bar.maxValue = health;
        bar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
    /*
        if(Input.GetKeyDown(KeyCode.S))
            changeHealth(-20);
        if(Input.GetKeyDown(KeyCode.A))
            changeHealth(20);
            */
    }
    public void setBar()
    {
        bar.value = health;
    }
    public void changeHealth(int amount)
    {
        health = health+amount;
        setBar();
    }
    public void Death()
    {
        //idk
    }
}
