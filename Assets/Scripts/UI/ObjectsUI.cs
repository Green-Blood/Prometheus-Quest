using System.Collections.Generic;
using System.Linq;
using Enums;
using UnityEngine;

namespace UI
{
    public sealed class ObjectsUI : MonoBehaviour
    {
        [SerializeField] private GameObject shieldPrefab;
        [SerializeField] private GameObject helmPrefab;
        private Dictionary<PickUpEnum ,List<GameObject>> _pickedUpObjectsImages;
        private List<GameObject> _instantiatedShieldList;
        private List<GameObject> _instantiatedHelmList;

        public void Init()
        {
            _pickedUpObjectsImages = new Dictionary<PickUpEnum, List<GameObject>>();
            _instantiatedHelmList = new List<GameObject>();
            _instantiatedShieldList = new List<GameObject>();
        }

        public void InstantiatePickableObjects(PickUpEnum pickUpEnum)
        {
            GameObject instantiatedObject;
            switch (pickUpEnum)
            {
                case PickUpEnum.Helm:
                    instantiatedObject = Instantiate(helmPrefab, transform);
                    _instantiatedHelmList.Add(instantiatedObject);
                    break;
                case PickUpEnum.Shield:
                    instantiatedObject = Instantiate(shieldPrefab, transform);
                    _instantiatedShieldList.Add(instantiatedObject);
                    break;
                default:
                    instantiatedObject = (GameObject)null;
                    break;
            }

            if (instantiatedObject != null)
            {
                instantiatedObject.SetActive(false);
            }
        }

        public void ShowObject(int index, PickUpEnum pickupObjectPickUpEnum)
        {
            // Shitcode should be changed
            if (pickupObjectPickUpEnum == PickUpEnum.Helm)
            {
                foreach (var list in _instantiatedHelmList.Where(list => !list.activeSelf))
                {
                    list.SetActive(true);
                    break;
                }
            }
            else if (pickupObjectPickUpEnum == PickUpEnum.Shield)
            {
                foreach (var list in _instantiatedShieldList.Where(list => !list.activeSelf))
                {
                    list.SetActive(true);
                    break;
                }
            }


        }

        public void HideObject(int index, PickUpEnum pickUpEnum)
        {
            if (pickUpEnum == PickUpEnum.Helm)
            {
                foreach (var list in _instantiatedHelmList.Where(list => list.activeSelf))
                {
                    list.SetActive(false);
                    break;
                }
            }
            else if (pickUpEnum == PickUpEnum.Shield)
            {
                foreach (var list in _instantiatedShieldList.Where(list => list.activeSelf))
                {
                    list.SetActive(false);
                    break;
                }
            }
        }
    }
}