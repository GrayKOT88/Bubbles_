using TMPro;
using UnityEngine;
using DG.Tweening;

namespace NewScripts
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;        
        [SerializeField] private GameObject _titleScreen;
        [SerializeField] private GameObject _gameOver;        

        public void UpdateScore(int score)
        {
            _scoreText.text = "Score: " + score;
            _scoreText.transform.DOPunchScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f);
        }

        public void ShowGameOver()
        {
            _gameOver.gameObject.SetActive(true);
            _gameOver.transform.localScale = Vector3.zero;
            _gameOver.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);           
        }

        public void HideGameOver()
        {
            _gameOver.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack)
                .OnComplete(() => _gameOver.gameObject.SetActive(false));            
        }

        public void ShowTitleScreen()
        {
            _titleScreen.gameObject.SetActive(true);
            _titleScreen.transform.localScale = Vector3.zero;
            _titleScreen.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        }

        public void HideTitleScreen()
        {            
            _titleScreen.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack)
                .OnComplete(() => _titleScreen.gameObject.SetActive(false));            
        }
    }
}