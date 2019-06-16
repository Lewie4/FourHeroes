using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarecrowAnimationController : CharacterAnimationController
{
    public override void TakeDamage()
    {
        m_animator.SetTrigger("Impact");
    }

    public override void Die()
    {
        m_animator.SetBool("Die", true);
    }
}
