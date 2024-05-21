using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	public int healthRestore = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
	void OnTriggerEnter2D(Collider2D collision)
	{
		Damageable damageable = collision.GetComponent<Damageable>();
		
		if(damageable)
		{
			damageable
		}
	}
    
}
