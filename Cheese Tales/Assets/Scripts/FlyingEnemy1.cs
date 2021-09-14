using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FlyingEnemy1 : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2[] wayPoint;
    private Vector2 currentWayPoint;
    int wayPointIndex = 0;
    private void Awake()
    {
        wayPoint = new Vector2[transform.childCount];
        for(int i=0;i<transform.childCount;i++)
        {
            wayPoint[i] = transform.GetChild(i).position;
        }
    }
    private void Start()
    {
        currentWayPoint = wayPoint[wayPointIndex];
        if (wayPoint == null)
        {
            Debug.LogWarning("Set WayPoints for Flying Enemy 1 Note:: Minimum 2 Max Any");
        }
    }
    private void Update()
    {
        if (Vector2.Distance(this.transform.position, currentWayPoint) < 0.01f)
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
        this.transform.position = Vector2.MoveTowards((Vector2)this.transform.position, currentWayPoint, 3f * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") { UIManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    }
}
