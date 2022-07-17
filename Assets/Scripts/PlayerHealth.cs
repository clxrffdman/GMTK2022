using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : Health
{
    public int ballsLeft;
    public int maxBalls;
    public Image balls;
    public TextMeshProUGUI number;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        BallsUI();
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    public override void Death()
    {
        //Debug.Log("test");
        changeBalls(-1);
        if(ballsLeft <= 0)
            GameOver();
        if(health <= 0)
        {
            health = maxHealth;
            //some animation ig
            setBar();
        }
    }
    public void changeBalls(int amount)
    {
        Debug.Log("ok");
        Debug.Log(amount);
        int added = ballsLeft+amount;
        if(added < maxBalls)
            ballsLeft = added;
        else
            ballsLeft = maxBalls;
        BallsUI();
    }
    public void Heal(float amount)
    {
        Debug.Log(amount);
        float added = health+amount;
        if(added <= maxHealth)
            health = added;
        else
        {
            health = maxHealth;
            changeBalls(1);
        }
        setBar();
        if(health <= 0)
            this.Death();
    }
    public void BallsUI()
    {
        number.text = "" + ballsLeft;
        /*for(int i = 0; i < maxBalls; i++)
        {
            if(i < ballsLeft)
                balls[i].color = new Color(balls[i].color.r, balls[i].color.g, balls[i].color.b, 255);
            else
                balls[i].color = new Color(balls[i].color.r, balls[i].color.g, balls[i].color.b, 0);
        }*/
    }
    public void GameOver()
    {
        alive = false;
        anim.SetBool("happy", false);

        //idk yet
    }
}
