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
    
    [Header("anims")]
    public Animator bEffect;
    public Animator pEffect;
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
        int rng = UnityEngine.Random.Range(0, 3);
        AudioManager.Instance.PlayEnemyLine(rng);
        while(true)
        {
            if(todo.bpoisons.Count != 0)
                todo.statuses[4].color = new Color(todo.statuses[4].color.r, todo.statuses[4].color.g, todo.statuses[4].color.b, 255);
            if(todo.poisons.Count != 0)
                todo.bstatuses[4].color = new Color(todo.bstatuses[4].color.r, todo.bstatuses[4].color.g, todo.bstatuses[4].color.b, 255);
            if((todo.rest || todo.skipped) && currentState == 0)
            {
                phaseTime = 0;
            }
            else if((todo.bskipped) && currentState == 1)
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
            //anims?
            whatdo[currentState](GameManager.Instance.currentRoll, PinballController.Instance.currentPoints);
            if(currentState == 0 && (!todo.rest || !todo.skipped))
            {
                if(GameManager.Instance.currentRoll > 4)
                {
                    bEffect.SetInteger("type", 3);
                }
                else if(GameManager.Instance.currentRoll > 2)
                {
                    bEffect.SetInteger("type", 2);
                }
                else if(GameManager.Instance.currentRoll == 2)
                {
                    bEffect.SetInteger("type", 1);
                }
            }
            if(currentState == 1 && !todo.bskipped)
            {
                pEffect.SetBool("attack", true);
            }
            yield return new WaitForSeconds(buffer);
            bEffect.SetInteger("type", 0);
            pEffect.SetBool("attack", false);
            //poison
            if(currentState != 0)
            {
                for(int i = todo.poisons.Count-1; i >= 0 ; i--)
                {
                    Debug.Log("poison");
                    Debug.Log(todo.poisons[i].damage);
                    todo.DealDamagetoBoss(todo.poisons[i].damage);
                    todo.poisons[i].phasesLeft--;
                    if(todo.poisons[i].phasesLeft == 0)
                        todo.poisons.Remove(todo.poisons[i]);
                }
                if(todo.poisons.Count == 0)
                {
                    todo.bstatuses[4].color = new Color(todo.bstatuses[4].color.r, todo.bstatuses[4].color.g, todo.bstatuses[4].color.b, 0f);
                }
            }
            if(currentState != 1)
            {
                for(int i = todo.bpoisons.Count-1; i >= 0 ; i--)
                {
                    Debug.Log("bpoison");
                    Debug.Log(todo.bpoisons[i].damage);
                    todo.DealDamagetoPlayer(todo.bpoisons[i].damage);
                    todo.bpoisons[i].phasesLeft--;
                    if(todo.bpoisons[i].phasesLeft == 0)
                        todo.bpoisons.Remove(todo.bpoisons[i]);
                }
                if(todo.bpoisons.Count == 0)
                {
                    todo.statuses[4].color = new Color(todo.statuses[4].color.r, todo.statuses[4].color.g, todo.statuses[4].color.b, 0f);
                }
            }
            PinballController.Instance.currentPoints = 0;
            
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
