using UnityEngine;

namespace OldScripts
{
    public class Bubbles : MonoBehaviour
    {
        private Rigidbody _targetRb;
        private GameManager _gameManager;

        private float _minSpeed = 12;
        private float _maxSpeed = 18;
        private float _xRange = 4;
        private float _ySpawnPos = 0;

        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private int _pointValue;

        private void Start()
        {
            _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }

        private void OnEnable()
        {
            _targetRb = GetComponent<Rigidbody>();
            _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
            transform.position = RandomSpawnPos();
        }

        private void OnMouseDown()
        {
            if (_gameManager.IsGameActive)
            {
                Destroy(gameObject);
                Instantiate(_particleSystem, transform.position, _particleSystem.transform.rotation);
                _gameManager.UpdateScore(_pointValue);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            _gameManager.GameOver();
        }

        private Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
        }

        private Vector3 RandomSpawnPos()
        {
            return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
        }
    }
}
