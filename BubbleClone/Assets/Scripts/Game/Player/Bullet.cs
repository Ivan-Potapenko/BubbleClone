using UnityEngine;
using Events;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private EventListener _fixedUpdateEventListner;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private GameObject _playerBubbles;

        [SerializeField]
        private Vector3 _moveDirecton;
        public Vector3 MoveDirecton { set => _moveDirecton = value; }


        private Rigidbody2D _rigidbody2D;

        private GameObject _playerBubble;
        public GameObject PlayerBubble { set => _playerBubble = value; }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject != _playerBubble)
            {
                if (collision.gameObject.tag == "Player")
                {
                    collision.gameObject.GetComponent<PlayerBubble>().IncreaseSize();
                    Destroy(gameObject);
                }
                else
                {
                    Instantiate(_playerBubbles, gameObject.transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                
            }

        }

        private void OnEnable()
        {
            _fixedUpdateEventListner.ActionsToDo += Move;
        }

        private void OnDisable()
        {
            _fixedUpdateEventListner.ActionsToDo -= Move;
        }

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Move()
        {
            _rigidbody2D.velocity = _moveDirecton * _speed;
        }

    }

}
