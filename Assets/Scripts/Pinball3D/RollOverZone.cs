using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOverZone : PointZone
{
    public int soundIndex;
    public bool isMulti;
    public MultiRollOverZone parent;
    public bool isActive;

    public Animator parentLight;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isActive)
        {
            
            if (isMulti)
            {
                if (parent.numActive == parent.maxRollovers-1)
                {
                    PinballController.Instance.IncrementPoints((int)(currentPointValue) + parent.bonus);
                }
                else
                {
                    PinballController.Instance.IncrementPoints((int)(currentPointValue));
                }
                parent.RolloverActivated();
                parentLight.Play("activate");
                
                
                isActive = true;
            }
            else
            {
                PinballController.Instance.IncrementPoints((int)currentPointValue);
                AudioManager.Instance.PlayBoardSFX(soundIndex);
            }

        }

    }
}
