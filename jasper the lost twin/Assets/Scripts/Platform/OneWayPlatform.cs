using System.Collections;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private GameObject currentOneWayPlatform;
    private PlayerInputHandler playerInputHandler;
    private CapsuleCollider2D playerCapsuleCollider;
    private BoxCollider2D platformCollider;

    public void Start()
    {
        playerCapsuleCollider = GetComponent<CapsuleCollider2D>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
    }

    public void Update()
    {
        if (playerInputHandler.InputY != 0)
        {
	        if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
	{
		var platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCapsuleCollider, platformCollider, true);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(playerCapsuleCollider, platformCollider, false);
    }
}