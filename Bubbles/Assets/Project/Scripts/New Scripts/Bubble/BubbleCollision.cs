using UnityEngine;

namespace NewScripts
{
    public class BubbleCollision : MonoBehaviour
    {        
        private IGameModel _gameModel;

        public void Initialize(IGameModel gameModel)
        {
            _gameModel = gameModel;
        }

        private void OnTriggerEnter(Collider other)
        {
            _gameModel.ReturnBubble(this.GetComponent<Bubbles>());            
            _gameModel.SetGameActive(false);            
        }
    }
}