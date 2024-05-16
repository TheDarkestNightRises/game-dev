using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData : MonoBehaviour
{
	[SerializeField]
	public string attackName;
	[SerializeField]
	public float movementSpeed;
	[SerializeField]
	public float damageAmmount;
}
