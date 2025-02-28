using UnityEngine;

namespace NewScripts
{
    public class BubbleInput : MonoBehaviour, IClickable
    {
        private IGameModel _gameModel;
        private BubbleBurst _bubbleBurst;

        public void Initialize(IGameModel gameModel)
        {
            _gameModel = gameModel;
            _bubbleBurst = GetComponent<BubbleBurst>();
        }

        public void OnClick()
        {
            if (_gameModel.IsGameActive)
            {
                _bubbleBurst.BurstBubbleWithScore();
            }
        }
    }
}