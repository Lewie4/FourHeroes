using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroup : Group
{
    private void Start()
    {
        GameManager.Instance.RegisterPlayerGroup(this);
    }

    public override bool IsPlayer()
    {
        return true;
    }

#if UNITY_EDITOR
    [ContextMenu("Save Heros")]
    public void SaveHeros()
    {
        Heroes.Instance.AddGroupHero(m_group[0].GetHeroData());
        Heroes.Instance.AddGroupHero(m_group[1].GetHeroData());
        Heroes.Instance.AddGroupHero(m_group[2].GetHeroData());
        Heroes.Instance.AddGroupHero(m_group[3].GetHeroData());
    }
#endif
}
