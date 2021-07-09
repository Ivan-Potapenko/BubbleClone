using UnityEngine;
using Enums;
using Events;


namespace Game
{
    public class PlayerBubble : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private Direction _moveDirection;

        [SerializeField]
        private EventListener _moveEventListner;

        private Rigidbody2D _rigidbody2D;

        private void OnEnable()
        {
            _moveEventListner.ActionsToDo += Move;
        }

        private void OnDisable()
        {
            _moveEventListner.ActionsToDo -= Move;
        }

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Move()
        {
            switch(_moveDirection.direction)
            {
                case MoveDirection.Left:
                    MoveWithDirectionVector(new Vector2(0, -1));
                    break;

                case MoveDirection.Right:
                    MoveWithDirectionVector(new Vector2(0, 1));
                    break;
            }
        }

        private void MoveWithDirectionVector(Vector2 vector2)
        {

        }

    }

}
