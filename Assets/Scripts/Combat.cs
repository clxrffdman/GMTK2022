using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public float scoreModifier;
    public int scoreThreshold;//for utility > is good stuff < is bad stuff idk
    bool invincible;
    public float healthRegain;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {

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
        Debug.Log("u");
        int current = GameManager.Instance.currentRoll;
        int previous = GameManager.Instance.previousRoll;
        if(current == 1)
        {
            //increase/decrease diceindex, if below dec, if above inc
            if(score < scoreThreshold)
            {
                if(GameManager.Instance.currentDiceIndex > 1)
                    GameManager.Instance.currentDiceIndex--;
            }
            else
            {
                if(GameManager.Instance.currentDiceIndex < GameManager.Instance.maxDiceIndex)
                    GameManager.Instance.currentDiceIndex++;
            }
        }
        else if(current == 2  || current == 3)
        {
            if(score < scoreThreshold)
            {
                GameManager.Instance.phealth.changeHealth(healthRegain);
            }
            else
            {
                GameManager.Instance.phealth.changeHealth(GameManager.Instance.phealth.maxHealth);
                GameManager.Instance.phealth.changeBalls(1);
            }
        }
        else if(current == 4)
        {

        }
        else if(current == 5)
        {
            
        }
        else if(current == 6)
        {
            if(previous == 6)
                invincible = true;
            
        }
        else
        {

        }
    }
}
