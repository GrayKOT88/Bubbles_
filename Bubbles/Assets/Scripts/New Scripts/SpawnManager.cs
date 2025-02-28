using System.Collections;
using System.Threading;
using UnityEngine;
using Zenject;

namespace NewScripts
{
    public class SpawnManager : MonoBehaviour
    {
        [Inject] private IGameModel _gameModel;        
        private ParticlePool _particlePool;
        private BubblePool _bubblePool;
        private float _spawnRate = 1f;

        private CancellationTokenSource _cancellationTokenSource;

        [Inject]
        public void Construct(ParticlePool particlePool, BubblePool bubblePool)
        {            
            _particlePool = particlePool;
            _bubblePool = bubblePool;
        }

        private void Start()
        {          
            DifficultyButton.OnDifficultySelected += OnSpawn;            
        }

        private void OnSpawn(int difficulty)
        {
            _spawnRate /= difficulty;
            _cancellationTokenSource = new CancellationTokenSource();
            StartCoroutine(SpawnBubbles(_spawnRate, _cancellationTokenSource.Token));            
        }        

        IEnumerator SpawnBubbles(float time, CancellationToken token)
        {            
            while (_gameModel.IsGameActive && !token.IsCancellationRequested)
            {
                yield return new WaitForSeconds(time);
                if(_gameModel.IsGameActive && !token.IsCancellationRequested)
                {
                    Bubbles bubbles = _bubblePool.GetBubble();
                    bubbles.Initialize(_gameModel,_particlePool);
                }
            }
        }

        private void OnDestroy()
        {
            _cancellationTokenSource?.Cancel();
            DifficultyButton.OnDifficultySelected -= OnSpawn;            
        }
    }
}