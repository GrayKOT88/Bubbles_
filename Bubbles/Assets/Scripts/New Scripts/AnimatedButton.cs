using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace NewScripts
{
    public class AnimatedButton : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();            
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {            
            _button.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
        }
    }
}