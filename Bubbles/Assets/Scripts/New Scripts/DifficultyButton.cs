using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace NewScripts
{
    public class DifficultyButton : MonoBehaviour
    {
        [SerializeField] private int _selectedDifficulty;
        [Inject] private IGameModel _gameModel;

        private Button _button;

        public static event System.Action<int> OnDifficultySelected;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnDifficultyButtonClicked);
        }

        private void OnDifficultyButtonClicked()
        {
            _gameModel.SetGameActive(true);
            Debug.Log(gameObject.name + " was clicked " + _selectedDifficulty + _gameModel.IsGameActive);
            OnDifficultySelected?.Invoke(_selectedDifficulty);
        }
    }
}