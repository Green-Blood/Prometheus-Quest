using Player;
using UnityEngine;

namespace UI
{
    public sealed class WinLose : MonoBehaviour
    {
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject winPanel;

        private PlayerMove _playerMove;
        private GameAudio _gameAudio;
        public bool IsWin { get; private set; }
        public bool IsGameRunning { get; private set; } = true;

        public void Init(PlayerMove playerMove, GameAudio gameAudio)
        {
            _playerMove = playerMove;
            _gameAudio = gameAudio;
        }

        public void WinGame()
        {
            IsWin = true;
            winPanel.SetActive(true);
            _playerMove.Stop();
            IsGameRunning = false;
            _gameAudio.PlaySound(SoundsEnum.YouWin);
        }

        public void LoseGame()
        {
            if (IsWin) return;
            losePanel.SetActive(true);
            _playerMove.Stop();
            IsGameRunning = false;
        }
    }
}