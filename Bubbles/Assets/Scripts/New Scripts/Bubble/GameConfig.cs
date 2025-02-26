using UnityEngine;

namespace NewScripts
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/GameConfig")]
    public class GameConfig : ScriptableObject
    {        
        [SerializeField] private float _minSpeed = 13f;
        [SerializeField] private float _maxSpeed = 18f;
        [SerializeField] private float _xRange = 4f;
        [SerializeField] private float _ySpawnPos = 0f;
                
        public float MinSpeed => this._minSpeed;
        public float MaxSpeed => this._maxSpeed;
        public float XRange => this._xRange;
        public float YSpawnPos => this._ySpawnPos;  
        
    }
}