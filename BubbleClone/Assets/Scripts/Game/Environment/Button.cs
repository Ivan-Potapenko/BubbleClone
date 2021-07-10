using UnityEngine;

namespace Game
{
    public class Button : MonoBehaviour
    {
        [SerializeField]
        private Door _door;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                ButtonDown();
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && !_door.IsOpen)
            {
                ButtonDown();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                ButtonUp();
            }
        }

        private void ButtonDown()
        {
            _door.OpenDoor();
        }
        private void ButtonUp()
        {
            _door.CloseDoor();
        }

        

    }
}
