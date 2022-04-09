using Player;
using UnityEngine;

public sealed class FinishPoint : MonoBehaviour
{
    [SerializeField] private bool isStart;

    public bool IsStart => isStart;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.TryGetComponent(out Character character);
        {
            character.ChangeDirection();
            if (IsStart) Events.Instance.OnCharacterEnter?.Invoke();
        }
    }
}