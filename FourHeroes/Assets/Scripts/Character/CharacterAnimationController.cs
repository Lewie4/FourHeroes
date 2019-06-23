using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterAnimationController : MonoBehaviour
{
    public event Action<string> OnCustomEvent = s => { };

    [SerializeField] protected Character m_character;
    [SerializeField] protected Animator m_animator;

    public void SetBool(string value)
    {
        var parts = value.Split('=');

        GetComponent<Animator>().SetBool(parts[0], bool.Parse(parts[1]));
    }

    public void SetInteger(string value)
    {
        var parts = value.Split('=');

        GetComponent<Animator>().SetInteger(parts[0], int.Parse(parts[1]));
    }

    public void CustomEvent(string eventName)
    {
        OnCustomEvent(eventName);
    }

    public void SetExpression(string expression)
    {
        m_character.SetExpression(expression);
    }

    public void ResetAnimation()
    {
        m_character.UpdateAnimation();
    }

    public virtual void TakeDamage()
    { 
    }

    public virtual void Die()
    {
        m_animator.SetBool("DieBack", true);
    }
}
