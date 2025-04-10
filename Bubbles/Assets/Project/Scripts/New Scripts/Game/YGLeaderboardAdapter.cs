using UnityEngine;
using YG;

namespace NewScripts
{
    public class YGLeaderboardAdapter : ILeaderboardService
    {
        public void SubmitScore(int score)
        {
            if (!YandexGame.SDKEnabled)
            {
                Debug.LogWarning("Yandex SDK not ready! Score not submitted.");
                return;
            }
            YandexGame.NewLeaderboardScores("BubblesScores", score);            
        }
    }
}