using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
	[SerializeField]
	public LayerMask whatIsPlayer;
	[SerializeField]
	public LayerMask whatIsGround;
	private PlayerInputHandler playerInputHandler;
	
	public void Start() 
	{
		playerInputHandler = GetComponent<PlayerInputHandler>();
	}
	
	public void Update()
    {
	    if(playerInputHandler.InputY < 0)
		   {
		    Physics2D.IgnoreLayerCollision(whatIsPlayer,whatIsGround,true);
		   }
	    Physics2D.IgnoreLayerCollision(whatIsPlayer,whatIsGround,false);
    }
}
