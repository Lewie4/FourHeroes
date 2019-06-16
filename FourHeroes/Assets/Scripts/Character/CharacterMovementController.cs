using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.HeroEditor.Common.CharacterScripts;


public class CharacterMovementController : MonoBehaviour
{
    private Vector3 _speed = Vector3.zero;
    private Character _character;
    private CharacterController _controller; // https://docs.unity3d.com/ScriptReference/CharacterController.html

    public void Start()
    {
        _character = GetComponent<Character>();
        _character.Animator.SetBool("Ready", true);
        _controller = GetComponent<CharacterController>();
    }

    public void Move(Vector2 direction)
    {
        if (_controller.isGrounded)
        {
            _speed = Vector3.zero;

            if (direction.x != 0)
            {
                _speed.x += direction.x > 0 ? 5 : -5;
            }

            if (_speed.magnitude > 0)
            {
                Turn(_speed.x);
            }
        }

        _character.Animator.SetBool("Run", _controller.isGrounded && Math.Abs(_speed.x) > 0.01f); // Go to animator transitions for more details
        _character.Animator.SetBool("Jump", !_controller.isGrounded);

        _speed.y -= 25 * Time.deltaTime; // Depends on project physics settings
        _controller.Move(_speed * Time.deltaTime);
    }

    public void Turn(float direction)
    {
        if (direction * transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
        }
    }
}
