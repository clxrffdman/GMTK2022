using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public bool alive;
    public float maxHealth;
    public float health;
    public Slider bar;
    public RectTransform barSub;
    public Animator anim;
    // Start is called before the first frame update
    public virtual void Start()
    {
        anim.SetBool("happy", true);
        alive = true;
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
        //bar.value = health;
        barSub.localScale = new Vector3(1.0884f * (health / maxHealth), 1.0884f, 1.0884f);
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
        anim.SetBool("happy", false);
    }
}