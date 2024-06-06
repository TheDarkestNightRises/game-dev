using UnityEngine;

public class Coin : MonoBehaviour
{
	public int value = 20;
	[SerializeField] AudioClip coinSVX;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
	        AudioSource.PlayClipAtPoint(coinSVX, Camera.main.transform.position);
           GameSession.instance.AddToGold(value);
            Destroy(gameObject);
        }
    }
}
