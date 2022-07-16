using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public bool alive;
    public float maxHealth;
    protected float health;
    public Slider bar;
    // Start is called before the first frame update
    public virtual void Start()
    {
        alive = true;
        bar.maxValue = maxHealth;
        health = maxHealth;
        setBar();
    }

    // Update is called once per frame
    public virtual void Update()
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
    public void changeHealth(float amount)
    {
        float added = health+amount;
        if(added < maxHealth)
            health = added;
        else
            health = maxHealth;
        setBar();
        if(health <= 0)
            this.Death();
    }
    public virtual void Death()
    {
        alive = false;
    }
}