using UnityEngine;
using Events;
using Enums;


namespace Game
{
    public class PlayerBubbleControl : MonoBehaviour
    {
        [SerializeField]
        private EventDispatcher _moveEventDispatcher;

        [SerializeField]
        private Direction _moveDirection;

        void Start()
        {

        }

    }
}

