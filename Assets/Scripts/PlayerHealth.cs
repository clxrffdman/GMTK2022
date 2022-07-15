using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    private int ballsLeft;
    [SerializeField] private Image[] balls;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        ballsLeft = balls.Length;
        BallsUI();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        //some nonsense where if you collide with the bottom -> Death(); will edit later when implementing death box
    }
    public override void Death()
    {
        Debug.Log("test");
        ballsLeft--;
        BallsUI();
        if(ballsLeft <= 0)
            GameOver();
        if(health<=0)
        {
            health = maxHealth;
            //some animation ig
            setBar();
        }
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
