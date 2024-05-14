using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveData", menuName = "Data/Enemy/Detected state")]
public class D_PlayerDetected : ScriptableObject
{
	public float longRangeActionTime = 1.5f;
	public float shortRangeActionTime = 1.5f;
}
