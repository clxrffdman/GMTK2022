using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Generics")]
    public GameObject SFXInstance;
    public Transform soundParent;
    [Header("Pinball Objects/Stats")]
    public GameObject nextPseudoball;
    public PlayerHealth phealth;
    public BossManager boss;
    public PinballController currentPinball;
    public int totalPoints;
    public TextMeshProUGUI pointText;
    public GameObject masterTableObj;
    [Header("Launch")]
    public RectTransform chargeBar;
    public bool isLaunching;
    public float launchCharge;
    public float ballChargeRate;
    public float baseLaunchMultiplier;
    public float maxCharge;
    public ExitZone exitZone;
    [Header("Dice")]
    public int currentDiceIndex;
    public int maxDiceIndex;
    public int currentRoll;
    public int previousRoll;
    public TextMeshProUGUI diceRollText;
    public List<AudioClip> diceRollSFXList;


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
        phealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIText();
        if (isLaunching)
        {
            LaunchBall();
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            //StopCoroutine(ShakeTable());
            //StartCoroutine(ShakeTable());
        }
    }

    void UpdateUIText()
    {
        pointText.text = currentPinball.currentPoints + "";
        
    }

    public void DoAttack()
    {

    }

    public int RollCurrentDice()
    {
        var sound = Instantiate(SFXInstance, transform.position, Quaternion.identity);
        sound.transform.parent = GameManager.Instance.soundParent;
        sound.GetComponent<SoundSample>().SpawnSound(diceRollSFXList[Random.Range(0,2)], 0, 1);

        previousRoll = currentRoll;
        currentRoll = Random.Range(1, currentDiceIndex + 1);
        StartCoroutine(UpdateDiceRollText());
        return currentRoll;
    }

    public IEnumerator UpdateDiceRollText()
    {
        int iterations = 10;
        for(int i = 0; i < iterations; i++)
        {
            diceRollText.text = Random.Range(1, currentDiceIndex + 1) + "";
            yield return new WaitForSeconds(0.05f);
        }
        diceRollText.text = currentRoll + "";

    }

    public IEnumerator ShakeTable()
    {
        Vector3 ogPos = masterTableObj.transform.position;
        LeanTween.value(gameObject, 0f, 1f, 0.1f).setOnUpdate((float val) => {
            masterTableObj.transform.position = ogPos + new Vector3(val, 0, 0);
        });
        yield return new WaitForSeconds(0.1f);
        LeanTween.value(gameObject, 0f, 1f, 0.1f).setOnUpdate((float val) => {
            masterTableObj.transform.position = ogPos + new Vector3(-val, 0, 0);
        });
        yield return new WaitForSeconds(0.1f);
        LeanTween.value(gameObject, 0f, 1f, 0.1f).setOnUpdate((float val) => {
            masterTableObj.transform.position = ogPos + new Vector3(val, 0, 0);
        });
        yield return new WaitForSeconds(0.1f);
        LeanTween.value(gameObject, 0f, 1f, 0.1f).setOnUpdate((float val) => {
            masterTableObj.transform.position = ogPos + new Vector3(-val, 0, 0);
        });
        yield return new WaitForSeconds(0.1f);
        masterTableObj.transform.position = ogPos;

    }



    public void ResetBall()
    {
        if(phealth.alive)
        {
            phealth.changeBalls(-1);
            isLaunching = true;
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
