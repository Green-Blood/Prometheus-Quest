using Game;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;

namespace Obstacles
{
    public sealed class ObstacleGenerator : MonoBehaviour
    {
        [Title("Values")]
        [SerializeField] private float minDistance = 3f;
        [SerializeField] private float maxDistance = 8f;
        [SerializeField] private float startDistance = 10f;
        [SerializeField] private float[] weightedRandomValues = new[] { 0.45f, 0.45f, 0.05f };

        [Title("References")] 
        [SerializeField] private Obstacle wings;
        [SerializeField] private Obstacle wine;
        [SerializeField] private PickUpObject[] pickupObjects;
        [SerializeField] private FinishPoint finishPoint;
        [SerializeField] private ObjectsUI objectsUI;

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
                int random = WeightedRandom.GetRandomWeightedIndex(weightedRandomValues);
                InstantiateObject(random, distance, randomDistanceBetweenObjects);


                distance += randomDistanceBetweenObjects;
            }
        }

        private void InstantiateObject(int random, float distance, float randomDistanceBetweenObjects)
        {
            var position = transform.position;
            switch (random)
            {
                case 0:
                    Instantiate(wings,
                        new Vector3(position.x,
                            position.y + distance + randomDistanceBetweenObjects, position.z),
                        Quaternion.identity, transform);
                    break;
                case 1:
                    Instantiate(wine,
                        new Vector3(position.x,
                            position.y + distance + randomDistanceBetweenObjects, position.z),
                        Quaternion.identity, transform);
                    break;
                case 2:
                {
                    var randomObject = Random.Range(0, pickupObjects.Length);
                    var generatedObject = Instantiate(pickupObjects[randomObject],
                        new Vector3(position.x,
                            position.y + distance + randomDistanceBetweenObjects, position.z),
                        Quaternion.identity, transform);
                    objectsUI.InstantiatePickableObjects(generatedObject.PickUpEnum);
                    break;
                }
            }
        }
    }
}