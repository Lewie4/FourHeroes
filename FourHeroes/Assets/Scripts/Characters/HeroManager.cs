using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    [SerializeField] HeroData[] m_heroes = new HeroData[Group.GROUPSIZE];

    private void Start()
    {
        LoadHeroes();
    }

    private void LoadHeroes()
    {
        m_heroes = Heroes.Instance.GetGroupHeroes();
    }


}
