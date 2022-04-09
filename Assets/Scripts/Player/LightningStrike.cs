namespace Player
{
    public sealed class LightningStrike
    {
        private readonly int _strikeLimit;
        private readonly PlayerHealth _playerHealth;
        private int _strikes;

        public LightningStrike(int strikeLimit, PlayerHealth playerHealth)
        {
            _strikeLimit = strikeLimit;
            _playerHealth = playerHealth;
        }

        public void IncreaseStrikeCount()
        {
            _strikes++;
            if (_strikes >= _strikeLimit)
            {
                _playerHealth.TakeDamage();
            }
        }
    }
}