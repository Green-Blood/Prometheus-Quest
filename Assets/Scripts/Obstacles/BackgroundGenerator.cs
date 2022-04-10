using System.Collections;
using System.Collections.Generic;
using Game;
using Sirenix.OdinInspector;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [Title("Values")] [SerializeField] private Vector2 minDistance = new Vector2(0.3f, 0.3f);
    [SerializeField] private Vector2 maxDistance = new Vector2(10f, 10f);
    [SerializeField] private float startDistance = 10f;
    [SerializeField] private float[] weightedRandomValues = new[] { 0.45f, 0.45f, 0.05f };
    [SerializeField] private GameObject[] backgroundClouds;
    [SerializeField] private GameObject backgroundCloudDistance;
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
            float randomDistanceBetweenXObjects = Random.Range(minDistance.x, maxDistance.x);
            float randomDistanceBetweenYObjects = Random.Range(minDistance.y, maxDistance.y);
            int randomObjectToInstantiate = Random.Range(0, backgroundClouds.Length);
            var position = transform.position;
            Instantiate(backgroundClouds[randomObjectToInstantiate], new Vector3(
                    position.x + randomDistanceBetweenXObjects,
                    position.y + distance + randomDistanceBetweenYObjects, position.z),
                Quaternion.identity, transform);
            distance += randomDistanceBetweenYObjects;
        }
    }
}