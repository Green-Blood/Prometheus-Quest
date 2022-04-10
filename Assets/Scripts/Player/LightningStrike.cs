using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Animations;
using Game;
using UI;
using UnityEngine;

namespace Player
{
    public sealed class LightningStrike
    {
        private readonly int _strikeLimit;
        private readonly PlayerHealth _playerHealth;
        private readonly PickedUpObjects _pickedUpObjects;
        private readonly LightningBolt _lightningBolt;
        private readonly Character _character;
        private readonly WinLose _winLose;
        private readonly GameAudio _gameAudio;
        private int _strikes;

        public LightningStrike(int strikeLimit, PlayerHealth playerHealth, PickedUpObjects pickedUpObjects,
            LightningBolt lightningBolt, Character character, WinLose winLose, GameAudio gameAudio)
        {
            _strikeLimit = strikeLimit;
            _playerHealth = playerHealth;
            _pickedUpObjects = pickedUpObjects;
            _lightningBolt = lightningBolt;
            _character = character;
            _winLose = winLose;
            _gameAudio = gameAudio;
        }

        public IEnumerator StartRandomStrikes(float minTimeBetweenStrikes, float maxTimeBetweenStrikes)
        {
            while (_winLose.IsGameRunning)
            {
                float time = Random.Range(minTimeBetweenStrikes, maxTimeBetweenStrikes);
                yield return new WaitForSeconds(time);
                 Strike();
            }
        }

        public void IncreaseStrikeCount()
        {
            _strikes++;
            if (_strikes < _strikeLimit)
            {
                return;
            }
            ResetStrikes();
            Strike();
        }

        private void Strike()
        {
            _character.StartStrikeAnimation();
            _gameAudio.PlaySound(SoundsEnum.Lightning);
             _lightningBolt.PlayLightningAnimation();


            if (!_pickedUpObjects.UsePickedUpObject())
            {
                _playerHealth.TakeDamage();
            }
        }

        private void ResetStrikes() => _strikes = 0;
    }
}