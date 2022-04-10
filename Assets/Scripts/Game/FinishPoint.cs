using Player;
using UnityEngine;

namespace Game
{
    public sealed class FinishPoint : MonoBehaviour
    {
        [SerializeField] private bool isStart;

        public bool IsStart => isStart;

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.TryGetComponent(out Character character);
            {
                character.ChangeDirection();
                character.ChangeAnimation();
                Events.Instance.OnCharacterGetToTheTop?.Invoke();
                if (IsStart)
                {
                    Events.Instance.OnCharacterEnter?.Invoke();
                }
            }
        }
    }
}