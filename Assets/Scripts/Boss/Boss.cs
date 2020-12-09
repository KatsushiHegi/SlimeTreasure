using System.Collections;
using UnityEngine;

public class Boss
{
    public const int maxHp=50;
    public int hp { get; set; }

    public void Recovery()
    {
        if (hp < maxHp)hp+=3;
    }
}

