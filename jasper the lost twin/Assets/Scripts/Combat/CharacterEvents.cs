using System.Collections;
using System.Collections.Generic;
using UnityEngine;	
using UnityEngine.Events;

public class CharacterEvents 
{
	public static UnityAction<GameObject, float> characterDamaged;
	
	public static UnityAction<GameObject, float> characterHealed;
	
	public static UnityAction<float, float> OnHealthChanged;	
}
