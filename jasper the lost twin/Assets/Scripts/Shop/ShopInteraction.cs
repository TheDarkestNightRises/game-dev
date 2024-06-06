using UnityEngine;

public class ShopInteraction : MonoBehaviour
{
    public Canvas shopCanvas;
    public Canvas pressButtonCanvas;

    private bool playerInRange = false;
    private bool shopOpen = false;

    void Start()
    {
        if (shopCanvas == null)
        {
            Debug.LogError("Shop Canvas is not assigned.");
        }
        else
        {
            shopCanvas.gameObject.SetActive(false);
        }

        if (pressButtonCanvas != null)
        {
            pressButtonCanvas.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (!shopOpen)
            {
                pressButtonCanvas.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (!shopOpen)
            {
                pressButtonCanvas.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.B))
        {
            shopOpen = !shopOpen;
            shopCanvas.gameObject.SetActive(shopOpen);
            pressButtonCanvas.gameObject.SetActive(false);
            //Time.timeScale = shopOpen ? 0f : 1f;
        }
    }
}