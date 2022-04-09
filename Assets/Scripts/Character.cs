using System;
using System.Collections;
using UnityEngine;

public sealed class Character : MonoBehaviour
{
    [SerializeField] private float defaultFlySpeed = 5f;
    [SerializeField] private float flySpeedModifier = 2f;
    [SerializeField] private float flySpeedModifierTime = 1f;

    private int _direction = 1;
    private float _currentSpeed;
    private bool _canClick;
    private Obstacle _obstacle;
    private float _currentTime;

    private void Awake() => _currentSpeed = defaultFlySpeed;

    private void Update()
    {
        Move();
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
        }
        else
        {
            ResetSpeed();
        }
    }

    private void Move() => transform.Translate((Vector3.up * _direction * _currentSpeed) * Time.deltaTime, Space.World);

    private void IncreaseSpeed()
    {
        _currentSpeed = defaultFlySpeed * flySpeedModifier;
        Debug.Log("Current speed is " + _currentSpeed);
        StartTimer();
    }

    private void DecreaseSpeed()
    {
        _currentSpeed = defaultFlySpeed / flySpeedModifier;
        Debug.Log("Current speed is " + _currentSpeed);
        StartTimer();
    }


    private void StartTimer()
    {
        _currentTime = flySpeedModifierTime;
    }


    private void ResetSpeed()
    {
        if(Math.Abs(_currentSpeed - defaultFlySpeed) < 0.1f) return;
        Debug.Log("Current speed is "  + _currentSpeed);
        if (_currentSpeed > defaultFlySpeed)
        {
            _currentSpeed -= Time.deltaTime;
        }
        else
        {
            _currentSpeed += Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        _canClick = true;
        other.TryGetComponent(out Obstacle obstacle);
        {
            _obstacle = obstacle;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        _canClick = true;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        _canClick = false;
    }

    public void CheckSpeed()
    {
        if (!_canClick) return;
        if (_obstacle.IsRedObstacle)
        {
            Debug.Log("Decreasing speed");
            DecreaseSpeed();
        }
        else
        {
            Debug.Log("Increasing speed");
            IncreaseSpeed();
        }
    }

    public void ChangeDirection() => _direction *= -1;
}