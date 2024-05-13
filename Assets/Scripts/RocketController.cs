using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    private EnergySystem _energySystem;
    private RocketMovement _rocketMovement;
    
    private bool _isMoving;
    private Vector2 _movementDirection;
    private float _spendEnergyAmount = 1f;
    private float moveDuration = 1f;
    private WaitForSeconds _wait;
    private void Awake()
    {
        _energySystem = GetComponent<EnergySystem>();
        _rocketMovement = GetComponent<RocketMovement>();
        _wait = new WaitForSeconds(moveDuration);
    }

    // TODO : OnMove 구현
    private void OnMove(InputValue value)
    {
        if (_isMoving || _energySystem.UseEnergy(SpendEnergy()))
        {
            StartCoroutine(MoveDuration());
            Vector2 direction = value.Get<Vector2>().normalized;
            _rocketMovement.ApplyMovement(direction);
        }
    }

    // TODO : OnBoost 구현
    // private void OnBoost...
    private void OnBoost(InputValue value)
    {
        _rocketMovement.ApplyBoost(value.isPressed);
    }

    private float SpendEnergy()
    {
        return _rocketMovement.IsBoosted ? _spendEnergyAmount * 3f : _spendEnergyAmount;
    }

    private IEnumerator MoveDuration()
    {
        _isMoving = true;
        yield return _wait;
        _isMoving = false;
    }
}