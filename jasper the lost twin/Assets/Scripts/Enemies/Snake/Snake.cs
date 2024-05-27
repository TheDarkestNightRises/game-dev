using UnityEngine;

public class Snake : MonoBehaviour
{
    public float moveSpeed;
    public GameObject[] wayPoints;

    private int _nextWayPoint = 1;
    private float _distToPoint;

    void Update()
    {
        Move();
    }

    // Update is called once per frame
    private void Move()
    {
        _distToPoint = Vector2.Distance(transform.position, wayPoints[_nextWayPoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[_nextWayPoint].transform.position,
            moveSpeed * Time.deltaTime);

        if (_distToPoint < 0.2f)
        {
            TakeTurn();
        }
    }

    private void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += wayPoints[_nextWayPoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextWayPoint();
    }

    private void ChooseNextWayPoint()
    {
        _nextWayPoint++;

        if (_nextWayPoint == wayPoints.Length)
        {
            _nextWayPoint = 0;
        }
    }
}