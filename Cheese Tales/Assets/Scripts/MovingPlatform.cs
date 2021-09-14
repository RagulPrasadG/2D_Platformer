using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType
{
    Vertical,Horizontal,Circular,Custom
}

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed;
    public float distance;
    public MoveType moveType;
    private Rigidbody2D rb;
    [SerializeField] Transform[] wayPoint;
    private Transform currentWayPoint;
    int wayPointIndex = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentWayPoint = wayPoint[wayPointIndex];
        if (wayPoint == null)
        {
            Debug.LogWarning("Set WayPoints for Platform Note:: Minimum 2 Max Any");
        }
    }
    private void Update()
    {
        switch (moveType)
        {
            case MoveType.Horizontal:
                HorizontalMove();
                break;
            case MoveType.Vertical:
                VerticalMove();
                break;
            case MoveType.Circular:
                CircularMove();
                break;
            case MoveType.Custom:
               CustomMove();
                break;
        }

    }
    void HorizontalMove()
    {
        this.transform.Translate(new Vector3(Mathf.Cos(Time.time * moveSpeed) * distance, 0f, 0f) * Time.deltaTime);
    }
    void VerticalMove()
    {
        this.transform.position  += new Vector3(0f, Mathf.Sin(Time.time * moveSpeed) * distance, 0f) * Time.deltaTime;
    }
    void CircularMove()
    {
        this.transform.position += new Vector3(Mathf.Cos(Time.time * moveSpeed) * distance, Mathf.Sin(Time.time * moveSpeed) * distance, 0f) * Time.deltaTime;
    }
    void CustomMove()
    {
        if (Vector2.Distance(this.transform.position, currentWayPoint.position) < 0.01f)
        {
            if (wayPointIndex == wayPoint.Length - 1)
            {
                wayPointIndex = 0;
                currentWayPoint = wayPoint[0];
            }
            else
            {
                currentWayPoint = wayPoint[++wayPointIndex];
            }
        }
        this.transform.position = Vector2.MoveTowards((Vector2)this.transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);
    }
    

}
