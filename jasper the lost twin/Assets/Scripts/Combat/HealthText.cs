using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    public Vector3 moveSpeed = Vector3.up;
    public float timeToFade = 1f;
    private RectTransform _textTransform;
    private TextMeshProUGUI _tmp;
    private float _timeElapsed;
    private Color _startColor;

    protected void Awake()
    {
        _textTransform = GetComponent<RectTransform>();
        _tmp = GetComponent<TextMeshProUGUI>();
        _startColor = _tmp.color;
    }

    // Update is called every frame, if the MonoBehaviour is enabled.
    protected void Update()
    {
        _textTransform.position += moveSpeed * Time.deltaTime;

        _timeElapsed += Time.deltaTime;

        if (_timeElapsed < timeToFade)
        {
            float fade = _startColor.a * (1 - (_timeElapsed / timeToFade));
            _tmp.color = new Color(_startColor.r, _startColor.g, _startColor.b, fade);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}