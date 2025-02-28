using UnityEngine;
using Zenject;

namespace NewScripts
{
    public class Bubbles : MonoBehaviour
    {        
        [SerializeField] private GameConfig _gameConfig;       
        [SerializeField] private int _pointValue;

        private ParticlePool _particlePool;        
        [Inject] private IGameModel _gameModel;

        public void Initialize(IGameModel gameModel, ParticlePool particlePool)
        {
            _gameModel = gameModel;
            _particlePool = particlePool;

            var movement = gameObject.GetComponent<BubbleMovement>();
            var input = gameObject.GetComponent<BubbleInput>();
            var burst = gameObject.GetComponent<BubbleBurst>();
            var collision = gameObject.GetComponent<BubbleCollision>();

            movement.Initialize(_gameConfig);
            input.Initialize(_gameModel);
            burst.Initialize(_gameModel, _particlePool, _pointValue);
            collision.Initialize(_gameModel);
        }
    }
}