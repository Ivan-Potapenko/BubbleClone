using UnityEngine;

namespace Game
{
    public class Key : MonoBehaviour
    {
        [SerializeField]
        private Door _door;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                GetKey();
                Destroy(gameObject);
            }
        }

        private void GetKey()
        {
            _door.OpenDoor();
        }
        

    }
}

