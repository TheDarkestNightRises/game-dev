using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class WeaponData : MonoBehaviour
{
    [SerializeField] public string attackName;
    [SerializeField] public float movementSpeed;
    [SerializeField] public float damageAmount;
}