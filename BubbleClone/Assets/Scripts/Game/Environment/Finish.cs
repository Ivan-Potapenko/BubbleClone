using UnityEngine;
using Events;


namespace Game
{
    public class Finish : MonoBehaviour
    {
        [SerializeField]
        private EventDispatcher _nextLevelEventDispatcher;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                _nextLevelEventDispatcher.Dispatch();
            }
        }

    }
}

