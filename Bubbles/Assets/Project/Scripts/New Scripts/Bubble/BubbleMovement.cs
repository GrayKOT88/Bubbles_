using UnityEngine;

namespace NewScripts
{
    public class BubbleMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private GameConfig _gameConfig;

        public void Initialize(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
            _rigidbody = GetComponent<Rigidbody>();
            ForceReset();
            ApplyRandomForce();
            SetRandomPosition();
        }

        private void FixedUpdate()
        {            
            if (_rigidbody.velocity.y < 0) // Мягкая кастомная гравитация
            {
                _rigidbody.AddForce(Vector3.down * _gameConfig.FallSpeed, ForceMode.Acceleration);
            }
            
            if (Random.value > 0.95f) // Добавляем случайные колебания для эффекта "дрейфа"
            {
                _rigidbody.AddForce(new Vector3(Random.Range(-_gameConfig.SwayForce,
                    _gameConfig.SwayForce),0,0),ForceMode.Impulse);
            }
        }

        private void ForceReset()
        {
            _rigidbody.velocity = new Vector3(0, 0, 0);
        } 

        private void ApplyRandomForce()
        {
            Vector3 force = Vector3.up * Random.Range(_gameConfig.MinSpeed, _gameConfig.MaxSpeed);
            _rigidbody.AddForce(force, ForceMode.VelocityChange);            
        }

        private void SetRandomPosition()
        {
            transform.position = new Vector3
                (Random.Range(-_gameConfig.XRange, _gameConfig.XRange), _gameConfig.YSpawnPos);
        }
    }
}