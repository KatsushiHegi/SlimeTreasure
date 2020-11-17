using System.Collections;
using UnityEngine;

public class Boss
{
    public const int maxHp=10;
    public int hp { get; set; }

    public void Recovery()
    {
        if (hp < maxHp)hp++;
    }
}

