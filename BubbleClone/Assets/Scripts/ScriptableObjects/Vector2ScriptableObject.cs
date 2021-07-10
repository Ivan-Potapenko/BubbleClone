using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewVector2", menuName = "Vector2")]
    public class Vector2ScriptableObject : ScriptableObject
    {
        public Vector2 value;
    }
}

