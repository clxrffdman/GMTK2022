using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Combat : MonoBehaviour
{   
    //posion affects opposite person
    [Header("Player")]
    public float baseScoreModifier;
    private float scoreModifier;

    bool invincible;

    public float healModifier;

    public float neuterDamageModifier;
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
    //statuses 0 = chargingattack, 1 = nextisvamp, 2 = nextispois, 3 = increaseddamage, 4 = poisoned, 5 = nextisstunned, maybe a sleep for rest
    [SerializeField] public Image[] statuses;
    public bool skipped;
    public bool rest;
    private float damage;

    [Header("Boss")]
    public float minDamage;
    public float baseDamage;
    public bool moreDamage;
    public float moreBaseDamage;
    float damageModifier;
    public float baseDamageModifier;
    public float damagePointModifier;

    public bool bpoisonAttack;
    public List<Poison> bpoisons;
    public int bpoisonLength;
    public float bpoisonDamageModifier;
    public float bpoisonDamagePointModifier;

    [SerializeField] public Image[] bstatuses;
    public bool bskipped;
    // Start is called before the first frame update
    void Start()
    {
        poisons = new List<Poison>();
        bpoisons = new List<Poison>();
        skipped = false;
        bskipped = false;
        vampire = false;
        charging = false;
        for(int i = 0; i < 6; i++)
        {
            statuses[i].color = new Color(statuses[i].color.r, statuses[i].color.g, statuses[i].color.b, 0f);
            bstatuses[i].color = new Color(bstatuses[i].color.r, bstatuses[i].color.g, bstatuses[i].color.b, 0f);
        }
        scoreModifier = baseScoreModifier;
        damageModifier = baseDamageModifier;
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
        if(roll == 1f)
        {
            charging = true;
            chargeModifier = ((float) Math.Log(score+1))*chargePointModifier;
            rollMulti = 0f;
            statuses[0].color = new Color(statuses[0].color.r, statuses[0].color.g, statuses[0].color.b, 255);
        }
        if(roll > 2)
        {
            rollMulti = 1.3f;
        }
        if (roll > 3f)
        {
            rollMulti = 1.6f;
        }
        if (roll == 6f)
        {
            SkipBoss();
        }
        damage = (scoreModifier * score) * rollMulti;
        if(skipped || rest)
        {
            damage = 0;
            removeSkipPlayer();
            rest = false;
        }
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
        bAttack(roll, score);
    }
    public void Utility(int roll, int score)
    {
        if(vampire)
            vampire = false;
        //Debug.Log("u");
        int current = roll;
        int rn;
        int previous = GameManager.Instance.previousRoll;
        if(current == 1)
        {
            rn = UnityEngine.Random.Range(1, 3);
            if(rn == 1)
                skipped = true;
            else 
            {
                scoreModifier = ((float) Math.Log(score+1))*scoreModifier*neuterDamageModifier;
            }
        }
        else if(current == 2)
        {
            moreDamage = true;
            scoreModifier = ((float) Math.Log(score+1))*scoreModifier*neuterDamageModifier*1.2f;
        }
        else if(current == 3)
        {
            //Debug.Log("3");
            Utility(4, score);
            rest = true;
        }
        else if(current == 4)
        {
            
            float heal = healModifier*score;
            GameManager.Instance.phealth.Heal(heal);

        }
        else if(current == 5)
        {
            rn = UnityEngine.Random.Range(1, 3);
            if(rn == 1)
            {
                PoisonActivate(score);
            }
            else
            {
                VampActivate(score);
            }

        }
        else if(current == 6)
        {
            //Debug.Log("6");
            rn = UnityEngine.Random.Range(1, 3);
            if(rn == 1)
            {
                VampActivate(score);
            }
            scoreModifier = scoreModifier*((float) Math.Log(score+1))*bonusDamagePointModifier;
            statuses[3].color = new Color(statuses[3].color.r, statuses[3].color.g, statuses[3].color.b, 255);
            /*if(previous == 6 && current == 6)
                scoreModifier*=2;
                */
        }
    }
    public void PoisonActivate(int score)
    {
                poisonAttack = true;
                poisonDamageModifier = ((float) Math.Log(score+1))*poisonDamagePointModifier;
                statuses[2].color = new Color(statuses[2].color.r, statuses[2].color.g, statuses[2].color.b, 255);
    }
    public void VampActivate(int score)
    {
            vampire = true;
                vampireHealModifier = score*vampireHealPointModifier;
                statuses[1].color = new Color(statuses[1].color.r, statuses[1].color.g, statuses[1].color.b, 255);
    }
    public void SkipPlayer()
    {
        skipped = true;
        statuses[5].color = new Color(statuses[5].color.r, statuses[5].color.g, statuses[5].color.b, 255);
    }
    public void removeSkipPlayer()
    {
        skipped = false;
        statuses[5].color = new Color(statuses[5].color.r, statuses[5].color.g, statuses[5].color.b, 0f);
    }
    
    public void SkipBoss()
    {
        bskipped = true;
        bstatuses[5].color = new Color(bstatuses[5].color.r, bstatuses[5].color.g, bstatuses[5].color.b, 255);
    }
    public void removeSkipBoss()
    {
        bskipped = false;
        bstatuses[5].color = new Color(bstatuses[5].color.r, bstatuses[5].color.g, bstatuses[5].color.b, 0f);
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
    void bAttack(int roll, int score)
    {
        Debug.Log(damageModifier);
        damageModifier = ((float) Math.Log(score+1))*damagePointModifier;
        Debug.Log("L");
        Debug.Log(damageModifier);
        float calc;
        if(!moreDamage)
            calc = baseDamage - damageModifier;
        else
        {
            moreDamage = false;
            calc = moreBaseDamage - damageModifier;
        }
        if(calc < minDamage)
            calc = minDamage;
        if(roll == 2f)
            bpoisonAttack = true;
        else if (roll == 1f)
            skipped = true;
        else if (roll == 6f)
            calc = 0;
        if(bpoisonAttack)
        { 
            bpoisonAttack = false;
            bpoisons.Add(new Poison(bpoisonDamageModifier*calc, bpoisonLength));
            bstatuses[2].color = new Color(bstatuses[2].color.r, bstatuses[2].color.g, bstatuses[2].color.b, 0f);
        }
        Debug.Log("huh");
        Debug.Log(calc);
        Debug.Log("hey");
        DealDamagetoPlayer(calc);
        damageModifier = baseDamageModifier;
    }
    public void DealDamagetoPlayer(float amount)
    {
        if(amount > GameManager.Instance.phealth.health)
        {
            amount = GameManager.Instance.phealth.health;
            GameManager.Instance.phealth.changeBalls(-1);
        }
        else
        {
            GameManager.Instance.phealth.changeHealth(-amount);
        }
    }
}
