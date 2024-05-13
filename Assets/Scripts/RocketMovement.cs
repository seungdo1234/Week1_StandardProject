using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private bool _isBoosted;
    private readonly float SPEED = 5f;
    private readonly float ROTATIONSPEED = 0.01f;

    private float _rotationPer = 0.5f;
    private bool _isRotated = false;
    private bool _isRightRotate = false;
    public bool IsBoosted => _isBoosted;
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    public void ApplyMovement(Vector2 direction)
    {
        // TODO : 회전을 적용하고 이동을 적용함 -> 이에 대한 구현을 아래에서 진행할 것
         Rotate(direction);
         if (direction.y > 0)
         {
             Move();
         }
    }

    public void ApplyBoost(bool isPressed)
    {
        _isBoosted = isPressed;
    }

    private void Rotate(Vector2 direction)
    {
        if (direction.x > 0)
        {
            _isRightRotate = true;
            StartCoroutine(RocketRightRotate());
        }
        else
        {
            _isRightRotate = false;
        }
        
    }

    private void Move()
    {
       _rb2d.velocity = Vector2.up * SPEED;
    }

    private IEnumerator RocketRightRotate()
    {
        Quaternion currentRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0, 0, 90);
        while (_isRightRotate)
        {
            transform.rotation = Quaternion.Slerp(currentRot, targetRot, ROTATIONSPEED* Time.deltaTime );
            
            yield return null;
        }
    }
}