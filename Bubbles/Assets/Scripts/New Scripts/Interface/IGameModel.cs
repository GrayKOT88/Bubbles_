using System;

namespace NewScripts
{
    public interface IGameModel
    {
        int Score { get; }
        bool IsGameActive { get; }
        int DifficultyLevel { get; }

        event Action<int> OnScoreChanged;
        event Action<bool> OnGameStateChanged;

        void AddScore(int points);
        void SetGameActive(bool isActive);
        void SetDifficulty(int difficulty);
        void ReturnBubble(Bubbles bubble);
    }
}