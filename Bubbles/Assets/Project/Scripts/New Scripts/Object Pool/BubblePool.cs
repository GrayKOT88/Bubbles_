using System.Collections.Generic;
using UnityEngine;

namespace NewScripts
{
    public class BubblePool : MonoBehaviour
    {
        [SerializeField] private Bubbles _prefabBubbles;
        [SerializeField] private int _poolSize = 10;

        private Queue<Bubbles> _bubblesPool = new Queue<Bubbles>();

        private void Start()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                ExpandPool();
            }
        }

        public Bubbles GetBubble()
        {
            if (_bubblesPool.Count == 0)
            {
                ExpandPool();
            }

            Bubbles bubble = _bubblesPool.Dequeue();
            bubble.gameObject.SetActive(true);
            return bubble;
        }

        public void ReturnBubble(Bubbles bubble)
        {
            bubble.gameObject.SetActive(false);
            _bubblesPool.Enqueue(bubble);
        }

        private void ExpandPool()
        {
            Bubbles bubble = Instantiate(_prefabBubbles, transform);
            bubble.SetRandomSize();
            bubble.SetRandomColor();
            bubble.gameObject.SetActive(false);
            _bubblesPool.Enqueue(bubble);
        }
    }
}