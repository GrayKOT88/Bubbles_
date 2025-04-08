using UnityEngine;

namespace NewScripts
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField] private AudioClip _bubbleBurstSound;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }            
        }

        public void PlaySound(string soundId)
        {
            if (soundId == "BubbleBurst" && _bubbleBurstSound != null)
            {
                _audioSource.PlayOneShot(_bubbleBurstSound);                
            }
        }
    }
}