using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phases : MonoBehaviour
{
    public float phaseTime;
    public Slider timerBar;
    private float timeLeft;
    private bool timergo;
    public float buffer;
    public Combat todo;
    private int currentState = 0;
    int stateIndex;
    public Dictionary <int, Action<int, int>> whatdo;
    // Start is called before the first frame updatea
    void Start()
    {
        timergo = false;
        whatdo = new Dictionary<int, Action<int, int>>
        {
            {0, todo.Attack},
            {1, todo.Defense},
            {2, todo.Utility}
        };
        StartCoroutine(PhaseStuff());
    }
    IEnumerator PhaseStuff()
    {
        while(true)
        {
            //rolldicefunctionhere
            timeLeft = phaseTime;
            timergo = true;
            yield return new WaitForSeconds(phaseTime);
            timergo = false;
            //score = actualScore, roll = rolled, < implement later with these taking from gamemanager
            whatdo[currentState](1, 2);//placeholder for now
            //for animations?
            yield return new WaitForSeconds(buffer);
            currentState++;
            if(currentState > 2)
                currentState = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(timergo)
        {
            timeLeft -= Time.deltaTime;
            timerBar.value = timeLeft;
        }
    }
}
