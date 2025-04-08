using UnityEngine;

namespace NewScripts
{
    public class Bubbles : MonoBehaviour
    {        
        [SerializeField] private GameConfig _gameConfig;       
        [SerializeField] private int _pointValue;
        private Renderer _renderer; // Ссылка на компонент Renderer пузыря
        private ParticlePool _particlePool;        
        private IGameModel _gameModel;
        private IAudioService _audioService;

        private void Awake()
        {           
            if (_renderer == null)
            {
                _renderer = GetComponent<Renderer>();
            }
        }

        public void Initialize(IAudioService audioService, IGameModel gameModel, ParticlePool particlePool)
        {
            _audioService = audioService;
            _gameModel = gameModel;
            _particlePool = particlePool;

            var movement = gameObject.GetComponent<BubbleMovement>();
            var input = gameObject.GetComponent<BubbleInput>();
            var burst = gameObject.GetComponent<BubbleBurst>();
            var collision = gameObject.GetComponent<BubbleCollision>();

            movement.Initialize(_gameConfig);
            input.Initialize(_gameModel);
            burst.Initialize( _audioService,_gameModel, _particlePool, _pointValue);
            collision.Initialize(_gameModel);
        }

        public void SetRandomSize()
        {
            float randomSize = Random.Range(_gameConfig.MinSize, _gameConfig.MaxSize);
            transform.localScale = Vector3.one * randomSize;
        }

        public void SetRandomColor()
        {
            if (_renderer != null && _gameConfig.BubbleColors.Length > 0)
            {
                Material newMaterial = new Material(_renderer.material);
                newMaterial.color = _gameConfig.BubbleColors[Random.Range(0, _gameConfig.BubbleColors.Length)];
                _renderer.material = newMaterial;
            }
        }
    }
}