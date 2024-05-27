using UnityEngine;

public class IcyPlatforms : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float SlipperyFriction = 0.2f;
    private float currentPlayerFriction;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Slip(other.gameObject);
        }
    }

    private void Slip(GameObject other)
    {
        var player = other.GetComponent<PlayerScript>();
        //currentPlayerFriction = player.playerData.friction; TODO: make it work / it doesn't retreive the current friction
        player.playerData.friction = SlipperyFriction;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        print("No longer in contact with " + other.transform.name);
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerScript>();
            player.playerData.friction = 30f;
        }
    }
}