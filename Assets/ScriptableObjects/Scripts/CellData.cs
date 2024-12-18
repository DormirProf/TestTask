using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "CellData", menuName = "Data/Cell Data", order = 2)]
    public class CellData : ScriptableObject
    {
        [SerializeField] private string _identifier;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _rotationSpriteAngle;

        public string Identifier => _identifier;
        public Sprite Sprite => _sprite;
        public float RotationSpriteAngle => _rotationSpriteAngle;
    }
}

