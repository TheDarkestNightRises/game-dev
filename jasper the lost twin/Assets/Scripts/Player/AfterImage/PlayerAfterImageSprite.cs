using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{
    public float activeTime = 0.1f;
    public float timeActivated;
    public float alpha;
    public float alphaSet = 0.8f;
    public float alphaMultiplayer = 0.85f;


    public Transform player;
    public SpriteRenderer SR;
    public SpriteRenderer playerSR;
    public Color color;

    protected void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();
        alpha = alphaSet;
        SR.sprite = playerSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultiplayer;
        color = new Color(1f, 1f, 1f, alpha);
        SR.color = color;
        if (Time.time >= (timeActivated + activeTime))
        {
            PlayerAfterImagePool.Instance.AddToPool(gameObject);
        }
    }
}