using System;

namespace Player
{
    public sealed class PlayerHealth
    {
        private int _currentHealth;
        public Action<int> OnHealthChange;
        private readonly PlayerDeath _playerDeath;

        public PlayerHealth(int maxHealth, PlayerDeath playerDeath)
        {
            _currentHealth = maxHealth;
            _playerDeath = playerDeath;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            ChangeHealth();
        }

        public void TakeDamage()
        {
            _currentHealth -= 1;
            ChangeHealth();
        }

        private void ChangeHealth()
        {
            OnHealthChange?.Invoke(_currentHealth);
            if (_currentHealth <= 0)
            {
                _playerDeath.Die();
            }
        }
    }
}