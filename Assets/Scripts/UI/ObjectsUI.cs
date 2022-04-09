using System.Collections.Generic;
using Enums;
using Game;
using UnityEngine;

namespace UI
{
    public sealed class ObjectsUI : MonoBehaviour
    {
        [SerializeField] private GameObject shieldPrefab;
        [SerializeField] private GameObject helmPrefab;
        private List<GameObject> _pickedUpObjectsImages;

        public void Init()
        {
            _pickedUpObjectsImages = new List<GameObject>();
        }

        public void InstantiatePickableObjects(PickUpEnum pickUpEnum)
        {
            var instantiatedObject = pickUpEnum switch
            {
                PickUpEnum.Helm => Instantiate(helmPrefab, transform),
                PickUpEnum.Shield => Instantiate(shieldPrefab, transform),
                _ => null
            };

            if (instantiatedObject != null)
            {
                instantiatedObject.SetActive(false);
            }

            _pickedUpObjectsImages.Add(instantiatedObject);
        }

        public void ShowObject(int index, PickUpEnum pickupObjectPickUpEnum)
        {
            if (_pickedUpObjectsImages[index] != null)
            {
                _pickedUpObjectsImages[index].SetActive(true);
            }
        }

        public void HideObject(int index, PickUpEnum pickUpEnum)
        {
            if (_pickedUpObjectsImages[index] != null)
            {
                _pickedUpObjectsImages[index].SetActive(false);
            }
        }
    }
}