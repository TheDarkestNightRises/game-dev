using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Enemy/Entity state")]
public class D_Entity : ScriptableObject
{
	public float wallCheckRange = 0.2f;
	public float ledgeCheckRange = 0.4f;
	public LayerMask whatIsGround;
}
