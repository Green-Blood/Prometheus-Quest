using Enums;
using Game;
using Obstacles;
using UnityEngine;

namespace Player
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject downTorch;
        
        public bool CanClick { get; private set; }

        private Obstacle _obstacle;

        private PlayerMove _playerMove;
        private PlayerHealth _playerHealth;
        private LightningStrike _lightningStrike;
        private GameAudio _gameAudio;
        private static readonly int IsUp = Animator.StringToHash("IsUp");
        private static readonly int Strike = Animator.StringToHash("Strike");
        public int Direction { get; private set; } = 1;
        public PickUpObject PickUpObject { get; private set; }

        public void Init(PlayerMove playerMove, PlayerHealth playerHealth, LightningStrike lightningStrike, GameAudio gameAudio)
        {
            _playerMove = playerMove;
            _playerHealth = playerHealth;
            _lightningStrike = lightningStrike;
            _gameAudio = gameAudio;
        }

        private void Update()
        {
            Move();
            _playerMove.CheckMultipliedSpeedTimer();
        }

        private void Move() =>
            transform.Translate((Vector3.up * Direction * _playerMove.CurrentSpeed) * Time.deltaTime,
                Space.World);

        private void OnTriggerEnter2D(Collider2D other)
        {
            CanClick = true;
            other.TryGetComponent(out Obstacle obstacle);
            {
                _obstacle = obstacle;
            }
            other.TryGetComponent(out PickUpObject pickupObject);
            {
                PickUpObject = pickupObject;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            CanClick = true;
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            CanClick = false;
        }

        public void ChangeDirection()
        {
            Direction *= -1;
            _gameAudio.PlaySound(SoundsEnum.ZeusSCream);
        }

        public void ChangeAnimation()
        {
            animator.SetBool(IsUp, false);
            downTorch.SetActive(true);
        }

        public void StartStrikeAnimation() => animator.SetTrigger(Strike);

        public void CheckSpeed()
        {
            if (_obstacle == null) return;
            if (_obstacle.ObstacleEnum == ObstacleEnum.Wine)
            {
                _playerMove.DecreaseSpeed();
                _lightningStrike.IncreaseStrikeCount();
            }
            else
            {
                _playerMove.IncreaseSpeed();
            }
        }

        public void ResetPickedUpObject() => PickUpObject = null;
    }
}