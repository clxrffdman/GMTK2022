using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Health boss;
    public PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //test
    }
    public void Attack(int roll, int score)
    {

    }
    public void Defense(int roll, int score)
    {
        //ignore till we know more about boss attacks+what ian meens by diff types
    }
    public void Utility(int roll, int score)
    {
        //ignore till we have more
    }
}
