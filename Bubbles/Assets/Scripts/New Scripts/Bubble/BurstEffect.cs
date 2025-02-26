using System.Collections;
using UnityEngine;

namespace NewScripts
{
    public class BurstEffect : MonoBehaviour
    {
        private ParticleSystem _particle;
        private ParticlePool _particlePool;
        
        public void Initialize(ParticlePool particlePool)
        {            
            _particlePool = particlePool;            
        }

        private void Awake()
        {
            _particle = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            _particle.Play();
            StartCoroutine(ReturnParticleAfterDelay(0.5f));
        }

        private IEnumerator ReturnParticleAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _particle.Stop();
            _particlePool.ReturnParticle(this);
        }        
    }
}