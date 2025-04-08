using UnityEngine;
using UnityEngine.UI;

namespace OldScripts
{
    public class DifficultyButton : MonoBehaviour
    {
        private Button _button;
        private GameManager _gameManager;

        [SerializeField] private int _difficulty;

        private void Start()
        {
            _button = GetComponent<Button>();
            _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            _button.onClick.AddListener(SetDifficulty);
        }

        private void SetDifficulty()
        {
            Debug.Log(gameObject.name + " was clicked");
            _gameManager.StartGame(_difficulty);
        }
    }
}