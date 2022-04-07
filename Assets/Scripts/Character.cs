using System;
using System.Collections;
using TMPro;
using UnityEngine;

public sealed class Character : MonoBehaviour
{
    [SerializeField] private Rigidbody2D characterRigidBody;
    [SerializeField] private float defaultFlySpeed = 5f;
    [SerializeField] private float flySpeedModifier = 2f;
    [SerializeField] private float flySpeedModifierTime = 1f;
    [SerializeField] private int time = 15;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    private int _direction = 1;
    private float _currentSpeed;
    private bool _canClick;
    private Obstacle _obstacle;
    private float _currentTime;
    private bool _isWin;

    private void Awake()
    {
        _currentSpeed = defaultFlySpeed;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

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

    IEnumerator Timer()
    {
        while (time > 0)
        {
            TimeCount();
            yield return new WaitForSeconds(1);
        }

        if (!_isWin)
        {
            losePanel.SetActive(true);
        }
    }

    private void TimeCount()
    {
        time -= 1;
        timeText.text = time.ToString();
    }

    public void ChangeDirection() => _direction *= -1;

    private void Move()
    {
        transform.Translate((Vector3.up * _direction * _currentSpeed) * Time.deltaTime, Space.World);
    }

    private void IncreaseSpeed()
    {
        _currentSpeed = defaultFlySpeed * flySpeedModifier;
        Debug.Log("Current speed is " + _currentSpeed);
        SetTimer();
    }

    private void DecreaseSpeed()
    {
        _currentSpeed = defaultFlySpeed / flySpeedModifier;
        Debug.Log("Current speed is " + _currentSpeed);
        SetTimer();
    }

    private void ResetSpeed() => _currentSpeed = defaultFlySpeed;

    private void SetTimer() => _currentTime = flySpeedModifierTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _canClick = true;
        other.TryGetComponent(typeof(Obstacle), out var obstacle);
        {
            _obstacle = obstacle as Obstacle;
        }
        other.TryGetComponent(typeof(FinishPoint), out var finishPoint);
        {
            if (finishPoint != null)
            {
                ChangeDirection();
                var _finishPoint = finishPoint as FinishPoint; 
                if (_finishPoint.IsStart)
                {
                    winPanel.SetActive(true);
                }
            }
        }
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
}