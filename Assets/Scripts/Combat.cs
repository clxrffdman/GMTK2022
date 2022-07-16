using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public float baseScoreModifier;
    private float scoreModifier;
    private float basePhaseTime;
    public Phases phasething;
    public float phaseTimeModifier;
    public int scoreThreshold;//for utility > is good stuff < is bad stuff idk
    bool invincible;
    public float healthRegain;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        basePhaseTime = phasething.phaseTime;
        scoreModifier = baseScoreModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //test
        if(Input.GetKeyDown(KeyCode.S))
            Attack(5, 20);
        if(Input.GetKeyDown(KeyCode.A))
            Attack(3, 5);
    }
    public void Attack(int roll, int score)
    {
        Debug.Log("a");


        float rollMulti = 1;
        if(roll > 2)
        {
            rollMulti = 1.3f;
        }
        if (roll > 4)
        {
            rollMulti = 1.6f;
        }
        if (roll > 6)
        {
            rollMulti = 1.9f;
        }

        damage = (scoreModifier * score) * rollMulti;
        GameManager.Instance.boss._bossHealth.changeHealth(-damage);
        
    }
    public void Defense(int roll, int score)
    {
    Debug.Log("d");
        //ignore till we know more about boss attacks+what ian meens by diff types
        if(invincible)
        {
            //prevent all damage?
            invincible = false;
        }
    }
    public void Utility(int roll, int score)
    {
        phasething.phaseTime = basePhaseTime;
        scoreModifier = baseScoreModifier;
        //Debug.Log("u");
        int current = roll;
        int previous = GameManager.Instance.previousRoll;
        if(current == 1)
        {
            //Debug.Log("1");
            //increase/decrease diceindex, if below dec, if above inc
            if(score < scoreThreshold)
            {
                //Debug.Log("?");
                if(GameManager.Instance.currentDiceIndex > 1)
                    GameManager.Instance.currentDiceIndex--;
            }
            else
            {
                //Debug.Log("cool");
                if(GameManager.Instance.currentDiceIndex < GameManager.Instance.maxDiceIndex)
                {
                    GameManager.Instance.currentDiceIndex++;
                   }
            }
        }
        else if(current == 2  || current == 3)
        {
            //Debug.Log("2");
            //only heal if under threshold, regain a ball if over
            if(score < scoreThreshold)
            {
                GameManager.Instance.phealth.changeHealth(healthRegain);
            }
            else
            {
                //Debug.Log("wait");
                GameManager.Instance.phealth.changeHealth(GameManager.Instance.phealth.maxHealth);
                if(GameManager.Instance.phealth.ballsLeft < GameManager.Instance.phealth.balls.Length)
                    GameManager.Instance.phealth.changeBalls(1);
            }
        }
        else if(current == 4 || current == 5)
        {
            //Debug.Log("4");
            if(score < scoreThreshold)
            {
                phasething.phaseTime-=phaseTimeModifier;
                phasething.timerBar.maxValue-=phaseTimeModifier;
            }
            else
            {
                phasething.phaseTime+=phaseTimeModifier;
                phasething.timerBar.maxValue+=phaseTimeModifier;
            }
        }
        else if(current == 6)
        {
            //Debug.Log("6");
            if(score < scoreThreshold)
            {
                scoreModifier = scoreModifier*0.5f;
            }
            else
            {
                scoreModifier = scoreModifier*2;
            }
            if(previous == 6 && GameManager.Instance.currentRoll == 6)
                invincible = true;
        }
        else
        {
            //Debug.Log(":)");
            Defense(1, score);
            Defense(2, score);
            Defense(6, score);
        }
    }
}
