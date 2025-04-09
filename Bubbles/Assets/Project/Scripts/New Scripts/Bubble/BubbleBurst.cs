using UnityEngine;

namespace NewScripts
{
    public class BubbleBurst : MonoBehaviour
    {
        private IAudioService _audioService;
        private IGameModel _gameModel;                
        private ParticlePool _particlePool;
        private int _pointValue;

        private void Start()
        {            
            _gameModel.OnGameStateChanged += BurstAllBubbles;            
        }

        public void Initialize(IAudioService audioService, IGameModel gameModel, ParticlePool particlePool, int pointValue)
        {
            _audioService = audioService;
            _gameModel = gameModel;
            _particlePool = particlePool;
            _pointValue = pointValue;
        }

        public void BurstBubbleWithScore()
        {
            BurstBubble();
            _gameModel.AddScore(_pointValue);
        }

        private void BurstBubble()
        {
            BurstEffect effect = _particlePool.GetParticle();
            effect.Initialize(_particlePool);
            effect.transform.position = transform.position;

            _audioService?.PlaySound("BubbleBurst"); // Воспроизведение звука           
            _gameModel.ReturnBubble(this.GetComponent<Bubbles>());
        }

        private void BurstAllBubbles(bool isActive)
        {
            if (!isActive)
            {
                BurstBubble();
            }
        }
    }
}