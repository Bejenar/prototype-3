using UnityEngine;

namespace Player.Abilities
{
    public abstract class BaseModifyDamageAbility<T> : BaseAbility
    {
        public abstract T Modify(T value);

        public T Apply(T value)
        {
            return enabled ? Modify(value) : value;
        }

        public static T ApplyAll(BaseModifyDamageAbility<T>[] customizers, T initialValue)
        {
            var newValue = initialValue;
            foreach (var modifyDarknessAbility in customizers)
            {
                newValue = modifyDarknessAbility.Apply(newValue);
                Debug.Log("new damage value is " + newValue);
            }

            return newValue;
        }
    }
}