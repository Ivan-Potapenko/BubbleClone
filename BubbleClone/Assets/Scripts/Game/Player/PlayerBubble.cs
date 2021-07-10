using UnityEngine;
using Enums;
using Events;
using ScriptableObjects;
using System.Collections.Generic;
using System.Collections;

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

        [SerializeField]
        private float _maxVelocity;

        [SerializeField]
        private Vector2ScriptableObject _mousePosition;

        [SerializeField]
        private EventListener _rotationPlayerEventListner;

        [SerializeField]
        private GameObject _bulletSpawnGameObject;

        [SerializeField]
        private EventListener _shootEventListner;

        [SerializeField]
        private GameObject _bullet;

        private Vector3 _mouseVector;

        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private int _bubbleSize;

        [SerializeField]
        private List<float> _bubbleScales;

        [SerializeField]
        private List<float> _bubbleGravityScales;

        [SerializeField]
        private int _maxSize;

        [SerializeField]
        private EventListener _jumpEventListner;

        [SerializeField]
        private bool _onFloor;

        [SerializeField]
        private float _jumpForce;

        [SerializeField]
        private float _timeShutdownOnFloor;

        private bool _destroyMe = false;

        private void OnEnable()
        {
            _moveEventListner.ActionsToDo += Move;
            _rotationPlayerEventListner.ActionsToDo += Rotation;
            _shootEventListner.ActionsToDo += Shoot;
            _jumpEventListner.ActionsToDo += Jump;
        }

        private void OnDisable()
        {
            _moveEventListner.ActionsToDo -= Move;
            _rotationPlayerEventListner.ActionsToDo -= Rotation;
            _shootEventListner.ActionsToDo -= Shoot;
            _jumpEventListner.ActionsToDo -= Jump;
            StopCoroutine(ShutdownOnFloor());
        }

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            SetSize();
        }

        private void Jump()
        {
            if (_onFloor)
            {
                if (_rigidbody2D.gravityScale > 0)
                {
                    _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
                else
                {
                    _rigidbody2D.AddForce(Vector2.down * _jumpForce, ForceMode2D.Impulse);
                }
                _onFloor = false;
            }

        }
        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_bubbleSize < _maxSize && collision.gameObject.tag == "BubbleJar")
            {
                IncreaseSize();
                Destroy(collision.gameObject);
            }
        }

        

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                _onFloor = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                StartCoroutine(ShutdownOnFloor());
            }
        }

        IEnumerator ShutdownOnFloor()
        {
            yield return new WaitForSeconds(_timeShutdownOnFloor);
            _onFloor = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_bubbleSize < _maxSize && collision.gameObject.tag == "Player")
            {
                if (_destroyMe)
                {
                    Death();
                }
                var playerBubble = collision.gameObject.GetComponent<PlayerBubble>();
                if (playerBubble._bubbleSize < playerBubble._maxSize)
                {
                    
                    playerBubble._destroyMe = true;
                    IncreaseSize();
                }

            }
            if (collision.gameObject.tag == "DeathlyTouch")
            {
                Death();
            }

            if (collision.gameObject.tag == "Floor")
            {
                _onFloor = true;
            }
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        private void Shoot()
        {
            if (_bubbleSize > 0)
            {
                var bullet = Instantiate(_bullet, _bulletSpawnGameObject.transform.position, Quaternion.identity);
                var bulletComponent = bullet.GetComponent<Bullet>();
                bulletComponent.MoveDirecton = _mouseVector;
                bulletComponent.PlayerBubble = gameObject;
                ReduceSize();
            }

        }

        private void ReduceSize()
        {
            if (_bubbleSize > 0)
            {
                _onFloor = false;
                _bubbleSize--;
                SetSize();
            }
        }

        public void IncreaseSize()
        {
            if (_bubbleSize < _maxSize)
            {
                _onFloor = false;
                _bubbleSize++;
                SetSize();
            }
        }

        private void SetSize()
        {
            gameObject.transform.localScale = new Vector3(_bubbleScales[_bubbleSize], _bubbleScales[_bubbleSize],
                    _bubbleScales[_bubbleSize]);
            _rigidbody2D.gravityScale = _bubbleGravityScales[_bubbleSize];
        }

        private void Rotation()
        {
            _mouseVector = (new Vector3(_mousePosition.value.x, _mousePosition.value.y, 0) -
                gameObject.transform.position).normalized;

            var angleOfRotation = Vector3.Angle(Vector3.right, _mouseVector);

            if (Vector3.Angle(Vector3.down, _mouseVector) < 90)
            {
                angleOfRotation *= -1;
            }


            int xRotation = 0;
            if (Vector3.Angle(Vector3.left, _mouseVector) < 90)
            {
                angleOfRotation *= -1;
                xRotation = 180;
            }

            gameObject.transform.localEulerAngles = new Vector3(xRotation, 0, angleOfRotation);
        }

        private void Move()
        {
            switch (_moveDirection.direction)
            {
                case MoveDirection.Left:
                    MoveWithDirectionVector(new Vector2(-1, 0));
                    break;

                case MoveDirection.Right:
                    MoveWithDirectionVector(new Vector2(1, 0));
                    break;
            }
        }

        private void MoveWithDirectionVector(Vector2 DirectionVector2)
        {
            if (_rigidbody2D.velocity.x * DirectionVector2.x <= _maxVelocity)
            {
                _rigidbody2D.AddForce(DirectionVector2 * _speed, ForceMode2D.Impulse);
            }
        }

    }

}
