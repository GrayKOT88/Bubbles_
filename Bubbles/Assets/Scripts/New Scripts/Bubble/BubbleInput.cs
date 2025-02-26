using UnityEngine;

namespace NewScripts
{
    public class BubbleInput : MonoBehaviour, IClickable
    {
        private IGameModel _gameModel;                
        private ParticlePool _particlePool;
        private int _pointValue;               

        public void Initialize(IGameModel gameModel, ParticlePool particlePool, int pointValue)
        {
            _gameModel = gameModel;
            _particlePool = particlePool;
            _pointValue = pointValue;
        }

        public void OnClick()
        {
            if (_gameModel.IsGameActive)
            {
                BurstBubble();
            }
        }

        private void BurstBubble()
        {
            BurstEffect effect = _particlePool.GetParticle();
            effect.Initialize(_particlePool);
            effect.transform.position = transform.position;            
            
            _gameModel.AddScore(_pointValue);
            _gameModel.ReturnBubble(this.GetComponent<Bubbles>());
        }
    }
}