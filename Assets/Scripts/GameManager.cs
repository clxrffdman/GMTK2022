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
    public int totalPoints;
    public TextMeshProUGUI pointText;
    [Header("Launch")]
    public RectTransform chargeBar;
    public bool isLaunching;
    public float launchCharge;
    public float ballChargeRate;
    public float baseLaunchMultiplier;
    public float maxCharge;
    public ExitZone exitZone;


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
        LaunchBall();
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

    public void LaunchBall()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Space))
        {
            exitZone.ResetEffectWall();
            if(launchCharge < maxCharge)
            {
                launchCharge += Time.deltaTime * ballChargeRate;
            }
        }
        else
        {
            currentPinball.GetComponent<PinballMovement>().rb.AddForce(0,0,baseLaunchMultiplier * launchCharge,ForceMode.Impulse);
            launchCharge = 0;
        }
        chargeBar.transform.localScale = new Vector3(chargeBar.transform.localScale.x, 1 * (launchCharge/maxCharge), chargeBar.transform.localScale.z);
        
    }



    public void Defeat()
    {

    }

    public void Victory()
    {

    }
}
