using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private bool isRedObstacle;

    public bool IsRedObstacle => isRedObstacle;
}