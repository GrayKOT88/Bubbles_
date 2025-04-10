using System;
using UnityEngine;
using Zenject;

namespace NewScripts
{
    public class GameModel : IGameModel
    {
        public int Score { get; private set; }
        public bool IsGameActive { get; private set; }
        public int HighScore { get; private set; }  // Добавляем свойство для рекорда

        public event Action<int> OnScoreChanged;
        public event Action<bool> OnGameStateChanged;

        private BubblePool _bubblePool;
                
        [Inject]
        public void Construct(BubblePool bubblePool)
        {
            _bubblePool = bubblePool;
            HighScore = PlayerPrefs.GetInt("HighScore", 0);  // Загружаем рекорд при старте            
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
            if (!isActive)  // Если игра завершилась
            {                
                if (Score > HighScore)  // Если текущий счёт выше рекорда
                {
                    HighScore = Score;
                    PlayerPrefs.SetInt("HighScore", HighScore);  // Сохраняем новый рекорд
                    PlayerPrefs.Save();
                }
            }
        }

        public void ReturnBubble(Bubbles bubble)
        {
            _bubblePool.ReturnBubble(bubble);           
        }
    }
}