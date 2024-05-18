using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	[SerializeField] public float speed;
	[SerializeField] public float resetTime;
	private float lifetime;

	
	public void ActivateBullet()
	{
		lifetime = 0;
		gameObject.SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
	    float movementSpeed = -speed * Time.deltaTime;
	    transform.Translate(movementSpeed,0,0);
	    
	    lifetime += Time.deltaTime;
	    if(lifetime > resetTime)
	    {
	    	gameObject.SetActive(false);
	    }
    }
	private void OnTriggerEnter2D()
	{
		gameObject.SetActive(false);
	}
}
