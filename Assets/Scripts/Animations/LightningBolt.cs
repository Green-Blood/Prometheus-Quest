using System.Collections;
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

        public void PlayLightningAnimation()
        {
            transform.position = character.transform.position + offset;
            lightningBolt.SetActive(true);
            StartCoroutine(CloseLightning());
        }

        private IEnumerator CloseLightning()
        {
            yield return new WaitForSeconds(1);
            lightningBolt.gameObject.SetActive(false);
        }
    }
}