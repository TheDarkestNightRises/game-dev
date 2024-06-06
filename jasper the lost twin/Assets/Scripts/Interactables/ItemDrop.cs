using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private Rigidbody2D itemRB;
    public float dropForce = 5;
	[SerializeField] int pointsForCoinPickup = 1;
	[SerializeField] AudioClip healthSVX;
	bool isCollected = false;

    void Start()
    {
        itemRB = GetComponent<Rigidbody2D>();
	    itemRB.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isCollected)
        {
	        GameSession.instance.AddToGold(pointsForCoinPickup);
	        isCollected = true;
	        AudioSource.PlayClipAtPoint(healthSVX, Camera.main.transform.position);
	        Destroy(gameObject);
        }
    }
}