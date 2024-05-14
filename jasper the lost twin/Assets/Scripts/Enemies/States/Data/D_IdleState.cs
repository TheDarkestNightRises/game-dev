using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleData", menuName = "Data/Enemy/Idle state")]
public class D_IdleState : ScriptableObject
{
	public float minIdleTime = 1f;
	public float maxIdleTime = 2f;
}
