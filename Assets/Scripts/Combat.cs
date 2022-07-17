using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Combat : MonoBehaviour
{
    public float baseScoreModifier;
    private float scoreModifier;

    bool invincible;

    public float healModifier;

    public float bonusDamagePointModifier;

    public bool charging;
    public float chargeModifier;
    public float chargePointModifier;

    
    public bool vampire;
    public float vampireHealModifier;
    public float vampireHealPointModifier;
    
    public bool poisonAttack;
    public List<Poison> poisons;
    public int poisonLength;
    public float poisonDamageModifier;
    public float poisonDamagePointModifier;

    [SerializeField] public Image[] statuses;
    public bool skipped;
    public bool rest;

    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        poisons = new List<Poison>();
        skipped = false;
        vampire = false;
        charging = false;
        for(int i = 0; i < 4; i++)
            statuses[i].color = new Color(statuses[i].color.r, statuses[i].color.g, statuses[i].color.b, 0f);
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
        if(roll == 1)
        {
            charging = true;
            chargeModifier = score*chargePointModifier;
            rollMulti = 0f;
            statuses[0].color = new Color(statuses[0].color.r, statuses[0].color.g, statuses[0].color.b, 255);
        }
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
        if(skipped || rest)
        {
            damage = 0;
            skipped = false;
            rest = false;
        }
        damage = (scoreModifier * score) * rollMulti;
        Debug.Log(damage);
        if(damage != 0)
        {
            if(poisonAttack)
            { 
                poisonAttack = false;
                poisons.Add(new Poison(poisonDamageModifier*damage, poisonLength));
                statuses[2].color = new Color(statuses[2].color.r, statuses[2].color.g, statuses[2].color.b, 0f);
            }
            scoreModifier = baseScoreModifier;
            statuses[3].color = new Color(statuses[3].color.r, statuses[3].color.g, statuses[3].color.b, 0f);

            DealDamagetoBoss(damage);
        }
        
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
        if(vampire)
            vampire = false;
        //Debug.Log("u");
        int current = 4;
        int previous = GameManager.Instance.previousRoll;
        if(current == 1)
        {
            skipped = true;
        }
        else if(current == 2)
        {
            Utility(3, score);
            rest = true;
        }
        else if(current == 3)
        {
            //Debug.Log("3");
            float heal = healModifier*score;
            GameManager.Instance.phealth.Heal(heal);
        }
        else if(current == 4)
        {
            poisonAttack = true;
            poisonDamageModifier = score*poisonDamagePointModifier;
            statuses[2].color = new Color(statuses[2].color.r, statuses[2].color.g, statuses[2].color.b, 255);

        }
        else if(current == 5)
        {
            vampire = true;
            vampireHealModifier = score*vampireHealPointModifier;
            statuses[1].color = new Color(statuses[1].color.r, statuses[1].color.g, statuses[1].color.b, 255);

        }
        else if(current == 6)
        {
            //Debug.Log("6");
            scoreModifier = ((float) Math.Log(score))*bonusDamagePointModifier;
            statuses[3].color = new Color(statuses[3].color.r, statuses[3].color.g, statuses[3].color.b, 255);
            if(previous == 6 && GameManager.Instance.currentRoll == 6)
                scoreModifier*=2;
        }
    }
    public void DealDamagetoBoss(float amount)
    {
        if(charging)
        {
            amount = amount*chargeModifier;
            charging = false;
            statuses[0].color = new Color(statuses[0].color.r, statuses[0].color.g, statuses[0].color.b, 0f);
        }
        if(vampire)
        {
            GameManager.Instance.phealth.changeHealth(amount*vampireHealModifier);
            vampire = false;
            statuses[1].color = new Color(statuses[1].color.r, statuses[1].color.g, statuses[1].color.b, 0f);
        }
        GameManager.Instance.boss._bossHealth.changeHealth(-amount);
    }
}
