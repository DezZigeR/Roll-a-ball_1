using UnityEngine;
using static UnityEngine.Random;

namespace Geekbrains
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        protected Color _color;

        private bool _isInteractable;

        protected bool IsInteractable
        {
             get { return _isInteractable; }
             private set
             {
                 _isInteractable = value;
                 GetComponent<Renderer>().enabled = _isInteractable;
                 GetComponent<Collider>().enabled = _isInteractable;
             }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            IsInteractable = false;
            Interaction();
        }

        protected abstract void Interaction();
        public abstract void Execute();

        private void Start()
        {
            IsInteractable = true;
            _color = ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }
    }
}
