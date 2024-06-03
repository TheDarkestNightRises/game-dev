using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 20;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           GameSession.instance.AddToGold(value);
            Destroy(gameObject);
        }
    }
}
