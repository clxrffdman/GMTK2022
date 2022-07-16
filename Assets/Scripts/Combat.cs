using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public float damageModifier;
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
        damage = damageModifier*score*roll;
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
