using System.Threading.Tasks;
using Player;
using UnityEngine;

namespace Animations
{
    public class LightningBolt : MonoBehaviour
    {
        [SerializeField] private GameObject lightningBolt;
        [SerializeField] private Vector3 offset;
        [SerializeField] private Character character;

        public async Task PlayLightningAnimation()
        {
            transform.position = character.transform.position + offset;
            
            lightningBolt.SetActive(true);
            await Task.Delay(1000);
            lightningBolt.gameObject.SetActive(false);
        }
    }
}
