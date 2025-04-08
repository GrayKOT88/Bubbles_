using System.Collections.Generic;
using UnityEngine;

namespace NewScripts
{
    public class ParticlePool : MonoBehaviour
    {
        [SerializeField] private BurstEffect _prefabParticle;
        [SerializeField] private int _poolSize = 5;

        private Queue<BurstEffect> _particlePool = new Queue<BurstEffect>();

        private void Start()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                ExpandPool();
            }
        }

        public BurstEffect GetParticle()
        {
            if (_particlePool.Count == 0)
            {
                ExpandPool();
            }

            BurstEffect particle = _particlePool.Dequeue();
            particle.gameObject.SetActive(true);
            return particle;
        }

        public void ReturnParticle(BurstEffect particle)
        {
            particle.gameObject.SetActive(false);
            _particlePool.Enqueue(particle);
        }

        private void ExpandPool()
        {
            BurstEffect particle = Instantiate(_prefabParticle, transform);
            particle.gameObject.SetActive(false);
            _particlePool.Enqueue(particle);
        }
    }
}