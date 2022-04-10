using System.Collections.Generic;
using UI;

namespace Game
{
    public sealed class PickedUpObjects
    {
        private readonly List<PickUpObject> _pickupObjects;
        private readonly ObjectsUI _objectsUI;
        private readonly GameAudio _gameAudio;

        public PickedUpObjects(ObjectsUI objectsUI, GameAudio gameAudio)
        {
            _pickupObjects = new List<PickUpObject>();
            _objectsUI = objectsUI;
            _gameAudio = gameAudio;
        }

        public void Add(PickUpObject pickUpObject)
        {
            _pickupObjects.Add(pickUpObject);
            var index = _pickupObjects.IndexOf(pickUpObject);
            _objectsUI.ShowObject(index, pickUpObject.PickUpEnum);
            _gameAudio.PlaySound(SoundsEnum.PickUp);
        }

        public void Remove(PickUpObject pickUpObject)
        {
            int index = _pickupObjects.IndexOf(pickUpObject);
            _objectsUI.HideObject(index, pickUpObject.PickUpEnum);
            _pickupObjects.Remove(pickUpObject);
        }

        public void Remove()
        {
            int lastIndex = _pickupObjects.Count - 1;
            _objectsUI.HideObject(lastIndex, _pickupObjects[lastIndex].PickUpEnum);
            _pickupObjects.RemoveAt(lastIndex);
        }

        public bool UsePickedUpObject()
        {
            if (_pickupObjects.Count == 0) return false;
            Remove();
            return true;

        }
    }
}