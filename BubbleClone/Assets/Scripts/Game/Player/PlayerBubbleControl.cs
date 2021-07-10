using UnityEngine;
using Events;
using Enums;
using ScriptableObjects;

namespace Game
{
    public class PlayerBubbleControl : MonoBehaviour
    {
        [SerializeField]
        private EventDispatcher _movePlayerBubbleEventDispatcher;

        [SerializeField]
        private Direction _moveDirection;

        [SerializeField]
        private EventListener _updateEventListner;

        [SerializeField]
        private EventListener _fixedUpdateEventListner;

        [SerializeField]
        private EventDispatcher _rotationPlayerEventDispatcher;

        [SerializeField]
        private Vector2ScriptableObject _playerMousePosition;

        [SerializeField]
        private EventDispatcher _shootEventDispatcher;


        private void OnEnable()
        {
            _updateEventListner.ActionsToDo += UpdateBehaviour;
        }

        private void OnDisable()
        {
            _updateEventListner.ActionsToDo -= UpdateBehaviour;
            _fixedUpdateEventListner.ActionsToDo -= _movePlayerBubbleEventDispatcher.Dispatch;
        }

        private void UpdateBehaviour()
        {
            KeybordControl();
            MouseControl();
        }

        private void MouseControl()
        {
            var mouseVector3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _playerMousePosition.value = new Vector2(mouseVector3.x, mouseVector3.y);
            _rotationPlayerEventDispatcher.Dispatch();
            if(Input.GetMouseButtonDown(0))
            {
                _shootEventDispatcher.Dispatch();
            }
        }

        private void KeybordControl()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _fixedUpdateEventListner.ActionsToDo += _movePlayerBubbleEventDispatcher.Dispatch;
                _moveDirection.direction = MoveDirection.Left;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _fixedUpdateEventListner.ActionsToDo += _movePlayerBubbleEventDispatcher.Dispatch;
                _moveDirection.direction = MoveDirection.Right;
            }

            if (!(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
            {
                _fixedUpdateEventListner.ActionsToDo -= _movePlayerBubbleEventDispatcher.Dispatch;
            }

        }

    }
}

