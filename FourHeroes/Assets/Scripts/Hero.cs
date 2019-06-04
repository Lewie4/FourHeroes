using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] ClassData m_class;
    [SerializeField] Weapon m_weapon;
    [SerializeField] Armour m_armour;
    [SerializeField] Amulet m_amulet;
    [SerializeField] Relic m_relic;

    private void Attack()
    {
        Debug.Log("Attack");
    }
}