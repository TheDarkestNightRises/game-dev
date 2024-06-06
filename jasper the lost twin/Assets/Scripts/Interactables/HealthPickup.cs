using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	public int healthRestore = 20;
	[SerializeField] AudioClip healthSVX;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerScript playerscript = collision.GetComponent<PlayerScript>();
            if (!playerscript.IsMaxHealth())
            {
	            playerscript.Heal(healthRestore);
	            AudioSource.PlayClipAtPoint(healthSVX, Camera.main.transform.position);
                Destroy(gameObject);
            }
        }
    }
}
