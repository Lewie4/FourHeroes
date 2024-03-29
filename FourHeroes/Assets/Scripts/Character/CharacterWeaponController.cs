﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterWeaponController : MonoBehaviour
{
    public Character Character;
    public Transform ArmL;
    public Transform ArmR;
    public bool FixHorizontal;

    private bool m_locked;

    public void Attack()
    {
        m_locked = !Character.Animator.GetBool("Ready") || Character.Animator.GetInteger("Dead") > 0;

        if (m_locked) return;

        switch (Character.WeaponType)
        {
            case WeaponType.Melee1H:
            case WeaponType.Melee2H:
            case WeaponType.MeleePaired:
                {
                    Character.Animator.SetTrigger(Time.frameCount % 2 == 0 ? "Slash" : "Jab"); // Play animation randomly                
                    break;
                }
            case WeaponType.Bow:
                {
                    Character.BowShooting.Attack();
                }
                break;
            case WeaponType.Supplies:
                /*if (Input.GetKeyDown(FireButton))
                {
                    Character.Animator.Play(Time.frameCount % 2 == 0 ? "UseSupply" : "ThrowSupply", 0); // Play animation randomly
                }*/
                break;
        }
    }

    public void ReadyWeapon()
    {
        m_locked = !Character.Animator.GetBool("Ready") || Character.Animator.GetInteger("Dead") > 0;

        if (m_locked) return;

        switch (Character.WeaponType)
        {
            case WeaponType.Bow:
                {
                    Character.BowShooting.Charge();
                }
                break;
        }
    }

    /// <summary>
    /// Called each frame update, weapon to mouse rotation example.
    /// </summary>
    public void LateUpdate()
    {
        if (m_locked) return;

        Transform arm;
        Transform weapon;

        switch (Character.WeaponType)
        {
            case WeaponType.Bow:
                arm = ArmL;
                weapon = Character.BowRenderers[3].transform;
                break;
            default:
                return;
        }

        RotateArm(arm, weapon, FixHorizontal ? arm.position + 1000 * Vector3.right : Camera.main.ScreenToWorldPoint(Input.mousePosition), -40, 40);
    }

    /// <summary>
    /// Selected arm to position (world space) rotation, with limits.
    /// </summary>
    public void RotateArm(Transform arm, Transform weapon, Vector2 target, float angleMin, float angleMax) // TODO: Very hard to understand logic
    {
        target = arm.transform.InverseTransformPoint(target);

        var angleToTarget = Vector2.SignedAngle(Vector2.right, target);
        var angleToFirearm = Vector2.SignedAngle(weapon.right, arm.transform.right) * Math.Sign(weapon.lossyScale.x);
        var angleFix = Mathf.Asin(weapon.InverseTransformPoint(arm.transform.position).y / target.magnitude) * Mathf.Rad2Deg;
        var angle = angleToTarget + angleToFirearm + angleFix;

        angleMin += angleToFirearm;
        angleMax += angleToFirearm;

        var z = arm.transform.localEulerAngles.z;

        if (z > 180) z -= 360;

        if (z + angle > angleMax)
        {
            angle = angleMax;
        }
        else if (z + angle < angleMin)
        {
            angle = angleMin;
        }
        else
        {
            angle += z;
        }

        arm.transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}