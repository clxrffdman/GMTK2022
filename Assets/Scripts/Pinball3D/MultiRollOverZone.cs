using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiRollOverZone : MonoBehaviour
{

    public List<RollOverZone> childRollOvers;
    public int baseSFXIndex;
    public int numActive;
    public int maxRollovers;
    public int bonus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RolloverActivated()
    {
        AudioManager.Instance.PlayBoardSFX(baseSFXIndex + numActive);
        numActive++;
        if (numActive >= maxRollovers)
        {
            ClearRollovers();
            numActive = 0;
        }
            


    }

    public void ClearRollovers()
    {
        foreach (RollOverZone r in childRollOvers)
        {
            r.isActive = false;
        }
    }


}
