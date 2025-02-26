using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NewScripts
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _gameOverText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _titleScreen;

        public void UpdateScore(int score)
        {
            _scoreText.text = "Score: " + score;
        }

        public void ShowGameOver()
        {
            _gameOverText.gameObject.SetActive(true);
            _restartButton.gameObject.SetActive(true);
        }

        public void HideGameOver()
        {
            _gameOverText.gameObject.SetActive(false);
            _restartButton.gameObject.SetActive(false);
        }

        public void ShowTitleScreen()
        {
            _titleScreen.gameObject.SetActive(true);
        }

        public void HideTitleScreen()
        {
            _titleScreen.gameObject.SetActive(false);
        }
    }
}