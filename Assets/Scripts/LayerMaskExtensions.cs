using UnityEngine;

public static class LayerMaskExtensions
{
    public static bool Includes(
        this LayerMask mask,
        int layer)
    {
        return (mask.value & 1 << layer) > 0;
    }
        
    public static bool Includes(
        this LayerMask mask,
        Collider2D collider)
    {
        return (mask.value & 1 << collider.gameObject.layer) > 0;
    }
        
    public static bool Includes(
        this LayerMask mask,
        GameObject gameObject)
    {
        return (mask.value & 1 << gameObject.gameObject.layer) > 0;
    }
}