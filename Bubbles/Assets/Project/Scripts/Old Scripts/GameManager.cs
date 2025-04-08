using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace OldScripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Bubbles _prefabBubbles;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _gameOverText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _titleScreen;

        private int _score;
        private float _spawnRate = 1f;

        public bool IsGameActive;

        IEnumerator SpawnBubbles()
        {
            while (IsGameActive)
            {
                yield return new WaitForSeconds(_spawnRate);
                Instantiate(_prefabBubbles);
            }
        }

        public void UpdateScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            _scoreText.text = "Score: " + _score;
        }

        public void GameOver()
        {
            _gameOverText.gameObject.SetActive(true);
            _restartButton.gameObject.SetActive(true);
            IsGameActive = false;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StartGame(int difficulty)
        {
            IsGameActive = true;
            _score = 0;
            _spawnRate /= difficulty;
            StartCoroutine(SpawnBubbles());
            UpdateScore(0);
            _titleScreen.gameObject.SetActive(false);
        }
    }
}