using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterEvents
{
    public static UnityAction<GameObject, float> CharacterDamaged;

    public static UnityAction<GameObject, float> CharacterHealed;

    public static UnityAction<float, float> OnHealthChanged;
}