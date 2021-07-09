using UnityEngine;
using Enums;

namespace Game
{
    [CreateAssetMenu(fileName = "Direction", menuName = "Direction")]
    public class Direction : ScriptableObject
    {
        public MoveDirection direction;
    }
}

