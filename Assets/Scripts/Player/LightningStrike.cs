using Animations;
using Game;

namespace Player
{
    public sealed class LightningStrike
    {
        private readonly int _strikeLimit;
        private readonly PlayerHealth _playerHealth;
        private readonly PickedUpObjects _pickedUpObjects;
        private readonly LightningBolt _lightningBolt;
        private readonly Character _character;
        private int _strikes;

        public LightningStrike(int strikeLimit, PlayerHealth playerHealth, PickedUpObjects pickedUpObjects,
            LightningBolt lightningBolt, Character character)
        {
            _strikeLimit = strikeLimit;
            _playerHealth = playerHealth;
            _pickedUpObjects = pickedUpObjects;
            _lightningBolt = lightningBolt;
            _character = character;
        }

        public async void IncreaseStrikeCount()
        {
            _strikes++;
            if (_strikes < _strikeLimit) return;
            ResetStrikes();
            _character.StartStrikeAnimation();
            await _lightningBolt.PlayLightningAnimation();

            if (!_pickedUpObjects.UsePickedUpObject())
            {
                _playerHealth.TakeDamage();
            }
        }

        private void ResetStrikes() => _strikes = 0;
    }
}