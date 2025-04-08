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

        [SerializeField] private float _minSize = 1.5f;
        [SerializeField] private float _maxSize = 2.5f;
        [SerializeField] private Color[] _bubbleColors;

        public float MinSpeed => this._minSpeed;
        public float MaxSpeed => this._maxSpeed;
        public float XRange => this._xRange;
        public float YSpawnPos => this._ySpawnPos;
        public float MinSize => this._minSize;
        public float MaxSize => this._maxSize;
        public Color[] BubbleColors => this._bubbleColors;

    }
}