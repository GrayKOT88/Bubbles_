using System;
using Zenject;

namespace NewScripts
{
    public class GameModel : IGameModel
    {
        public int Score { get; private set; }
        public bool IsGameActive { get; private set; }       

        public event Action<int> OnScoreChanged;
        public event Action<bool> OnGameStateChanged;

        private BubblePool _bubblePool;
                
        [Inject]
        public void Construct(BubblePool bubblePool)
        {
            _bubblePool = bubblePool;
        }

        public void AddScore(int points)
        {
            Score += points;
            OnScoreChanged?.Invoke(Score);
        }

        public void SetGameActive(bool isActive)
        {
            IsGameActive = isActive;
            OnGameStateChanged?.Invoke(isActive);           
        }

        public void ReturnBubble(Bubbles bubble)
        {
            _bubblePool.ReturnBubble(bubble);           
        }
    }
}