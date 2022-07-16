using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public int ballsLeft;
    [SerializeField] public Image[] balls;
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
        int added = ballsLeft+amount;
        if(added < balls.Length)
            ballsLeft = added;
        else
            ballsLeft = balls.Length;
        BallsUI();
    }
    public void BallsUI()
    {
        for(int i = 0; i < balls.Length; i++)
        {
            if(i < ballsLeft)
                balls[i].color = new Color(balls[i].color.r, balls[i].color.g, balls[i].color.b, 255);
            else
                balls[i].color = new Color(balls[i].color.r, balls[i].color.g, balls[i].color.b, 0);
        }
    }
    public void GameOver()
    {
        alive = false;
        //idk yet
    }
}
