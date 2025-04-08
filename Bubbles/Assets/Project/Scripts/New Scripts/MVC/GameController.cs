using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace NewScripts
{
    public class GameController : MonoBehaviour
    {        
        [Inject] private IGameModel _gameModel;
        [Inject] private IGameView _gameView;
       
        private void Start()
        {            
            _gameModel.OnGameStateChanged += OnGameStateChanged;
            _gameModel.OnScoreChanged += OnScoreChanged;

            _gameView.ShowTitleScreen();
        }
        
        private void OnGameStateChanged(bool isActive)
        {
            if (isActive)
            {
                _gameView.HideTitleScreen();                
            }
            else
            {
                _gameView.ShowGameOver();
            }
        }

        private void OnScoreChanged(int score)
        {
            _gameView.UpdateScore(score);
        }

        public void RestartGameButton()
        {
            _gameView.HideGameOver();
            Invoke("RestartGame",0.5f);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnDestroy()
        {
            _gameModel.OnGameStateChanged -= OnGameStateChanged;
            _gameModel.OnScoreChanged -= OnScoreChanged;
        }
    }
}