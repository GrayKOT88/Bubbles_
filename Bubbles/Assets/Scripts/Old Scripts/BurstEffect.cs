using UnityEngine;

namespace OldScripts
{
    public class BurstEffect : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 0.5f);
        }
    }
}