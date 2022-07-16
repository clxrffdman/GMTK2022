using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject nextPseudoball;
    public int ballAmount;
    public PinballController currentPinball;
    public float totalPoints;
    public TextMeshProUGUI pointText;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIText();
    }

    void UpdateUIText()
    {
        pointText.text = currentPinball.currentPoints + "";
    }

    public void DoAttack()
    {

    }



    public void ResetBall()
    {
        if(ballAmount > 0)
        {
            ballAmount--;
            if (nextPseudoball != null)
            {
                Destroy(nextPseudoball);

            }

            currentPinball.currentPoints = 0;
        }
        else
        {
            Defeat();
        }
        
    }

    public void Defeat()
    {

    }

    public void Victory()
    {

    }
}
