using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Enemy/Dead state")]
public class D_DeadState : ScriptableObject
{
	public GameObject deathVFX;
	public float highScoreWorth;
}
