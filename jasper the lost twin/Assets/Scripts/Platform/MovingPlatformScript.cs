using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float PlatformSpeed;
    public int StartingPoint;
    public Transform[] Points;
    private int _currentPointIndex;

    void Start()
    {
        transform.position = Points[StartingPoint].position;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, Points[_currentPointIndex].position) < 0.1f)
        {
            _currentPointIndex++;
            if (_currentPointIndex == Points.LongLength)
            {
                _currentPointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Points[_currentPointIndex].position,
            PlatformSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        col.transform.SetParent(null);
    }
}