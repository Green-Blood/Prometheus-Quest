using Enums;
using UnityEngine;

namespace Game
{
    public sealed class PickUpObject : MonoBehaviour
    {
        [SerializeField] private PickUpEnum pickUpEnum;

        public PickUpEnum PickUpEnum => pickUpEnum;
    }
}
