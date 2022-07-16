using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phases : MonoBehaviour
{
    public float phaseTime;
    public float buffer;
    public Combat todo;
    private int currentState = 0;
    int stateIndex;
    public Dictionary <int, Func<int, int>> whatdo = new Dictionary<int, Func<int, int>>()
    {
        {0, todo.Attack<int, int>},
        {1, todo.Defense},
        {2, todo.Utility}
    };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PhaseStuff());
    }
    IEnumerator PhaseStuff()
    {
        while(true)
        {
            //rolldicefunctionhere
            yield return new WaitForSeconds(phaseTime);
            currentState++;
            if(currentState > 2)
                currentState = 0;
            whatdo[currentState](1, 2);
            //for animations?
            yield return new WaitForSeconds(buffer);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Attack(int roll, int score)
    {

    }
}
