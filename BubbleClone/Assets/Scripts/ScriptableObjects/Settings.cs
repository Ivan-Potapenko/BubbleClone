using UnityEngine;

namespace ScriptableObjects
{
    
    [CreateAssetMenu(fileName = "Settings", menuName = "Settings")]
    public class Settings : ScriptableObject
    {
        public float MusicVolume;
        public float SoundVolume;
    }

}
