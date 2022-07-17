using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollZone : MonoBehaviour
{
    public float rerollCooldown;
    public float currentTime;
    public bool canReroll = true;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && canReroll)
        {
            GameManager.Instance.RollCurrentDice();
            canReroll = false;
            Invoke("LetRerollAgain", rerollCooldown);

        }
    }

    public void LetRerollAgain()
    {
        canReroll = true;
    }
    

}
