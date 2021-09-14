using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GroundEnemy : MonoBehaviour
{
    [SerializeField] float patrolSpeed;
    Vector2[] movePoints;
    private Vector2 currentWayPoint;
    int wayPointIndex = 0;
    private void Awake()
    {
        movePoints = new Vector2[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            movePoints[i] = transform.GetChild(i).position;
        }
    }
    private void Start()
    { 
        currentWayPoint = movePoints[wayPointIndex];
        if (movePoints == null)
        {
            Debug.LogWarning("Set WayPoints for Ground Enemy Note:: Minimum 2 Max Any");
        }
    }
    private void Update()
    {
        if (Vector2.Distance(this.transform.position, currentWayPoint) < 0.01f)
        {
            if (wayPointIndex == movePoints.Length - 1)
            {
                wayPointIndex = 0;
                currentWayPoint = movePoints[0];
            }
            else
            {
                currentWayPoint = movePoints[++wayPointIndex];
            }

        }
        this.transform.position = Vector2.MoveTowards((Vector2)this.transform.position, currentWayPoint, patrolSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            UIManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
