using Player;
using UnityEngine;

namespace UI
{
    public sealed class WinLose : MonoBehaviour
    {
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject winPanel;

        private PlayerMove _playerMove;
        private bool _isWin;

        public void Init(PlayerMove playerMove)
        {
            _playerMove = playerMove;
        }

        public void WinGame()
        {
            _isWin = true;
            winPanel.SetActive(true);
            _playerMove.Stop();
        }

        public void LoseGame()
        {
            if (_isWin) return;
            losePanel.SetActive(true);
            _playerMove.Stop();
        }
    }
}