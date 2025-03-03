using System;

namespace NewScripts
{
    public interface IGameModel
    {
        int Score { get; }
        bool IsGameActive { get; }        

        event Action<int> OnScoreChanged;
        event Action<bool> OnGameStateChanged;

        void AddScore(int points);
        void SetGameActive(bool isActive);        
        void ReturnBubble(Bubbles bubble);
    }
}