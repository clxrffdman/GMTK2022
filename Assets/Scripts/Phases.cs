using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phases : MonoBehaviour
{
    public float basePhaseTime;
    public float phaseTime;
    public Slider timerBar;
    private float timeLeft;
    private bool timergo;
    public float buffer;
    public Combat todo;
    public Animator anim;
    private int currentState = 0;
    int stateIndex;
    public Dictionary <int, Action<int, int>> whatdo;
    // Start is called before the first frame updatea
    void Start()
    {
        phaseTime = basePhaseTime;
        timerBar.maxValue = phaseTime;
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
            if((todo.rest || todo.skipped) && currentState == 0)
            {
                phaseTime = 0;
            }
            else
            {
                GameManager.Instance.RollCurrentDice();
                phaseTime = basePhaseTime;
            }
            timeLeft = phaseTime;
            timergo = true;
            yield return new WaitForSeconds(phaseTime);
            timergo = false;
            //score = actualScore, roll = rolled, < implement later with these taking from gamemanager
            yield return new WaitForSeconds(buffer);
            whatdo[currentState](GameManager.Instance.currentRoll, PinballController.Instance.currentPoints);
            //poison
            for(int i = todo.poisons.Count-1; i >= 0 ; i--)
            {
                Debug.Log("poison");
                Debug.Log(todo.poisons[i].damage);
                todo.DealDamagetoBoss(todo.poisons[i].damage);
                todo.poisons[i].phasesLeft--;
                if(todo.poisons[i].phasesLeft == 0)
                    todo.poisons.Remove(todo.poisons[i]);
            }
            PinballController.Instance.currentPoints = 0;
            //for animations?
            
            currentState++;
            if(currentState > 2)
                currentState = 0;
            anim.SetInteger("phase", currentState);
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
