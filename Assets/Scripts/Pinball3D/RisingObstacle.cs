using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingObstacle : MonoBehaviour
{

    public GameObject childObstacle;
    public float raiseAmount;
    public float raiseTime;
    // Start is called before the first frame update
    void Start()
    {
        childObstacle = transform.GetChild(0).gameObject;
    }

    public void RaiseObstacle()
    {
        StopCoroutine(ShiftRoutine(true));
        StartCoroutine(ShiftRoutine(true));
    }

    public void LowerObstacle()
    {
        StopCoroutine(ShiftRoutine(false));
        StartCoroutine(ShiftRoutine(false));
    }

    public IEnumerator ShiftRoutine(bool goingUp)
    {
        if (goingUp)
        {
            LeanTween.value(gameObject, 0f, raiseAmount, raiseTime).setOnUpdate((float val) => {
                childObstacle.transform.position = transform.position + new Vector3(0, val, 0);
            });
            yield return new WaitForSeconds(raiseTime);
        }
        else
        {
            LeanTween.value(gameObject, raiseAmount, 0f, 0.1f).setOnUpdate((float val) => {
                childObstacle.transform.position = transform.position + new Vector3(0, val, 0);
            });
            yield return new WaitForSeconds(raiseTime);
        }
        
    }
}
