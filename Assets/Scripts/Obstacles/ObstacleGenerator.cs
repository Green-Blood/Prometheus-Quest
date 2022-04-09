using Sirenix.OdinInspector;
using UnityEngine;

namespace Obstacles
{
    public sealed class ObstacleGenerator : MonoBehaviour
    {
        [Title("Values")] 
        [SerializeField] private float minDistance = 3f;
        [SerializeField] private float maxDistance = 8f;
        [SerializeField] private float startDistance = 10f;

        [Title("References")] [SerializeField] private Obstacle wings;
        [SerializeField] private Obstacle wine;
        [SerializeField] private FinishPoint finishPoint;

        private void Start()
        {
            GenerateObstacles();
        }

        private void GenerateObstacles()
        {
            var distance = transform.position.y + startDistance;
            while (distance < finishPoint.transform.position.y)
            {
                float randomDistanceBetweenObjects = Random.Range(minDistance, maxDistance);
                int randomObjectToInstantiate = Random.Range(0, 2);

                var position = transform.position;
                Instantiate(randomObjectToInstantiate == 0 ? wings : wine,
                    new Vector3(position.x,
                        position.y + distance + randomDistanceBetweenObjects, position.z),
                    Quaternion.identity, transform);


                distance += randomDistanceBetweenObjects;
            }
        }
    }
}