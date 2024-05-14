using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newInvestigateData", menuName = "Data/Enemy/Investigate state")]
public class D_InvestigateState : ScriptableObject
{
	public int numberOfFlips = 2;
	public float timeBetweenFlip = 0.75f;
}
