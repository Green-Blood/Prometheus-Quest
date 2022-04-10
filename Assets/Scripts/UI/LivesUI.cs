using System.Collections.Generic;
using Player;
using UnityEngine;

namespace UI
{
    public sealed class LivesUI : MonoBehaviour
    {
        [SerializeField] private GameObject live;

        private PlayerHealth _playerHealth;
        private int _playerHealthAmount;
        private List<GameObject> _instantiatedLives;

        public void Init(PlayerHealth playerHealth, int playerHealthAmount)
        {
            _instantiatedLives = new List<GameObject>();
            _playerHealth = playerHealth;
            _playerHealthAmount = playerHealthAmount;
            _playerHealth.OnHealthChange += UpdateHealthUI;
            InstantiateHealthObjects();
        }

        private void InstantiateHealthObjects()
        {
            for (int index = 0; index < _playerHealthAmount; index++)
            {
                _instantiatedLives.Add(Instantiate(live, transform));
            }
        }

        private void UpdateHealthUI(int health)
        {
            for (int index = 0; index < _instantiatedLives.Count; index++)
            {
                _instantiatedLives[index].SetActive(index < health);
            }
        }
    }
}