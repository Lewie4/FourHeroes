using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroup : Group
{
    private void Start()
    {
        GameManager.Instance.RegisterPlayerGroup(this);
    }
}
