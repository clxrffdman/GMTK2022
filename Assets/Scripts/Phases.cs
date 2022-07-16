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
    public Animator anim;
    private int currentState = 0;
    int stateIndex;
    public Dictionary <int, Action<int, int>> whatdo;
    // Start is called before the first frame updatea
    void Start()
    {
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
            GameManager.Instance.RollCurrentDice();
            timeLeft = phaseTime;
            timergo = true;
            yield return new WaitForSeconds(phaseTime);
            timergo = false;
            whatdo[currentState](GameManager.Instance.currentRoll, PinballController.Instance.currentPoints);//placeholder for now
            PinballController.Instance.currentPoints = 0;
            //for animations?
            yield return new WaitForSeconds(buffer);
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
