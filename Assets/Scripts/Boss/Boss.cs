using System.Collections;
using UnityEngine;

public class Boss
{
    public const int maxHp=10;
    public int hp { get; set; }

    public IEnumerator AutomaticRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (hp < maxHp)
            {
                hp++;
            }
        }
    }
}

