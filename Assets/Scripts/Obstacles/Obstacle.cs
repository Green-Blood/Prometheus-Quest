using Enums;
using UnityEngine;

namespace Obstacles
{
    public sealed class Obstacle : MonoBehaviour
    {
        [SerializeField] private ObstacleEnum obstacleEnum;

        public ObstacleEnum ObstacleEnum => obstacleEnum;
    }
}