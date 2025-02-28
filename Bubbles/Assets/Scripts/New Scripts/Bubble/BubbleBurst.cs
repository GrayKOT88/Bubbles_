using UnityEngine;

namespace NewScripts
{
    public class BubbleBurst : MonoBehaviour
    {
        private IGameModel _gameModel;                
        private ParticlePool _particlePool;
        private int _pointValue;

        private void Start()
        {
            _gameModel.OnGameStateChanged += BursrAllBubbles;
        }

        public void Initialize(IGameModel gameModel, ParticlePool particlePool, int pointValue)
        {
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
            
            _gameModel.ReturnBubble(this.GetComponent<Bubbles>());
        }

        private void BursrAllBubbles(bool isActive)
        {
            if (!isActive)
            {
                BurstBubble();
            }
        }
    }
}