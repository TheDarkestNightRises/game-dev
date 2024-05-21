using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHitData", menuName = "Data/Enemy/Hit state")]
public class D_HitState : ScriptableObject
{
	public float stunTime;
	public GameObject bloodVFX;
}
