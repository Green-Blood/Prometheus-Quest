using Enums;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Obstacles
{
    public sealed class Obstacle : MonoBehaviour
    {
        [SerializeField] private ObstacleEnum obstacleEnum;
        [SerializeField] private MMF_Player mmfPlayer;

        public ObstacleEnum ObstacleEnum => obstacleEnum;

        public void StartFeedback()
        {
            mmfPlayer.PlayFeedbacks();
        }
    }
}