using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public float scoreModifier;
    public Health boss;
    public PlayerHealth player;
    
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

        damage = (scoreModifier * score) * rollMulti;
        boss.changeHealth(-damage);
        
    }
    public void Defense(int roll, int score)
    {
    Debug.Log("d");
        //ignore till we know more about boss attacks+what ian meens by diff types
    }
    public void Utility(int roll, int score)
    {
    Debug.Log("u");
        //ignore till we have more
    }
}
