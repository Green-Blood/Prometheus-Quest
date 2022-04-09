using Player;
using UnityEngine;

namespace Game
{
    public sealed class ClickArea : MonoBehaviour
    {
        private PickedUpObjects _pickedUpObjects;
        private Character _character;

        public void Init(Character character, PickedUpObjects pickedUpObjects)
        {
            _character = character;
            _pickedUpObjects = pickedUpObjects;
        }

        public void OnScreenClick()
        {
            if (!_character.CanClick) return;
            _character.CheckSpeed();

            if (_character.PickUpObject == null) return;
            _pickedUpObjects.Add(_character.PickUpObject);
            _character.ResetPickedUpObject();
        }
    }
}