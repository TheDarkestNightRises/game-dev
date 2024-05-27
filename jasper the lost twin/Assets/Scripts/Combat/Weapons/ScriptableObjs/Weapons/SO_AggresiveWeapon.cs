using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Weapon")]
public class SO_AggresiveWeapon : ScriptableObject
{
    [SerializeField] public float damageAmmount;
    public GameObject hitVFX;
}