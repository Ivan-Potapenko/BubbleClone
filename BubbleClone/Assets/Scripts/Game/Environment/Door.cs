using UnityEngine;

namespace Game
{
    public class Door : MonoBehaviour
    {

        private bool _isOpen = false;

        public bool IsOpen { get => _isOpen; set => _isOpen = value; }

        public void OpenDoor()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            _isOpen = true;
        }

        public void CloseDoor()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            _isOpen = false;
        }
    }
}

