using UnityEngine;

[CreateAssetMenu(fileName = "newFlyingData", menuName = "Data/Enemy/Flying data")]
public class D_FlyingEnemy : ScriptableObject
{
	[Header("Entity")] 
	public float maxHealth = 30f;
    public float damage = 10f;

	[Header("Chase")] 
	public float flightSpeed = 4f;
    public float range = 4f;
    public LayerMask whatIsPlayer;

	[Header("Hit")] 
	public float stunTime = 0.65f;
    public GameObject bloodVFX;

	[Header("Death")] 
	public GameObject deathVFX;
	public float highScoreWorth = 10f;

}