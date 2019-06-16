using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.HeroEditor.Common.CharacterScripts;


public class CharacterMovementController : MonoBehaviour
{
    private Character m_character;

    public void Start()
    {
        m_character = GetComponent<Character>();
        m_character.Animator.SetBool("Ready", true);
    }

    public void Move(Vector3 direction)
    {  
        Vector3 newDirection = direction.normalized * 5;

        if (newDirection.magnitude > 0)
        {
            Turn(newDirection.x);
        }

        m_character.Animator.SetBool("Run", Math.Abs(newDirection.x) > 0.01f); //m_controller.isGrounded && Math.Abs(newDirection.x) > 0.01f); // Go to animator transitions for more details
        //m_character.Animator.SetBool("Jump", !m_controller.isGrounded);

        //if (!m_controller.isGrounded)
        //{
            //newDirection.y -= 25 * Time.deltaTime; // Depends on project physics settings
        //}
        transform.Translate(newDirection * Time.deltaTime);
    }

    public void StopMove()
    {
        m_character.Animator.SetBool("Run", false) ;
    }

    public void Turn(float direction)
    {
        if (direction * transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
        }
    }
}
