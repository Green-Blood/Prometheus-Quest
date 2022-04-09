using System;
using UnityEngine;

namespace Player
{
    public sealed class PlayerMove
    {
        private readonly float _defaultFlySpeed;
        private readonly float _flySpeedModifierTime;
        private readonly float _flySpeedModifier;

        private float _currentTime;


        public float CurrentSpeed { get; private set; }

        public PlayerMove(float defaultFlySpeed, float flySpeedModifierTime, float flySpeedModifier)
        {
            _defaultFlySpeed = defaultFlySpeed;
            _flySpeedModifierTime = flySpeedModifierTime;
            _flySpeedModifier = flySpeedModifier;
            CurrentSpeed = defaultFlySpeed;
        }

        public void CheckMultipliedSpeedTimer()
        {
            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
            }
            else
            {
                ResetSpeed();
            }
        }

        public void IncreaseSpeed()
        {
            CurrentSpeed = _defaultFlySpeed * _flySpeedModifier;
            StartTimer();
        }

        public void DecreaseSpeed()
        {
            CurrentSpeed = _defaultFlySpeed / _flySpeedModifier;
            StartTimer();
        }

        private void StartTimer()
        {
            _currentTime = _flySpeedModifierTime;
        }


        private void ResetSpeed()
        {
            if (Math.Abs(CurrentSpeed - _defaultFlySpeed) < 0.1f) return;
            if (CurrentSpeed > _defaultFlySpeed)
            {
                CurrentSpeed -= Time.deltaTime;
            }
            else
            {
                CurrentSpeed += Time.deltaTime;
            }
        }

        public void Stop()
        {
            CurrentSpeed = 0;
        }
    }
}