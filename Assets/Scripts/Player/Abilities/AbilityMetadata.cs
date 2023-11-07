using UnityEngine;

namespace Player.Abilities
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player/Ability Metadata", order = 0)]
    public class AbilityMetadata : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;

        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        public string Description
        {
            get => _description;
            protected set => _description = value;
        }

        public Sprite Icon
        {
            get => _icon;
            protected set => _icon = value;
        }
    }
}