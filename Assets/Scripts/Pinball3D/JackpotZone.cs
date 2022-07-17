using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackpotZone : PointZone
{
    public int jackpotTimeMultiplier;
    public void Update()
    {
        currentPointValue += (Time.deltaTime * jackpotTimeMultiplier);
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PinballController.Instance.IncrementPoints((int)currentPointValue);
            currentPointValue = basePointValue;
            AudioManager.Instance.PlayBoardSFX(8);
        }
    }
}
