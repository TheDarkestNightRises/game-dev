using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleData", menuName = "Data/Enemy/Pursue state")]
public class D_PursueState : ScriptableObject
{
	public float pursueSpeed = 5f;
	public float aggroTime = 2f;
}
