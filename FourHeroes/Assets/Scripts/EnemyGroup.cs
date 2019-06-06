using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : Group
{
    private void Start()
    {
        GameManager.Instance.RegisterEnemyGroup(this);
    }

    public override bool IsPlayer()
    {
        return false;
    }
}
