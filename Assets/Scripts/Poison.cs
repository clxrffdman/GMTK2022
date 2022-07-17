using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison
{
    public float damage;
    public int phasesLeft;
    public Poison(float d, int p)
    {
        damage = d;
        phasesLeft = p;
    }
}
