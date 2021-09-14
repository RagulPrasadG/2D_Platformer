using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopperEnemy : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private Animator anim;
    [Range(20, 80)]
    [SerializeField] int randomness;
    [SerializeField] int dropRate;
    private Transform dropPoint;
    private WaitForSeconds wait;
    public static int health = 100;

    [SerializeField] float moveSpeed;
    [SerializeField] float frequency;
     Vector2[] wayPoint;
    private Vector2 currentWayPoint;
    int wayPointIndex = 0;
    private void Awake()
    {
        wayPoint = new Vector2[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            wayPoint[i] = transform.GetChild(i).position;
        }
    }

    private void Start()
    {
        wait = new WaitForSeconds(dropRate);
        anim = GetComponent<Animator>();
        dropPoint = transform.GetChild(0);
        StartCoroutine(DropBomb());


        currentWayPoint = wayPoint[wayPointIndex];
    }
    private void Update()
    {
        Move();

        if(health <= 0)
        {
            UIManager.LoadScene(1);
        }
    }
    IEnumerator DropBomb()
    {
       
        while(true)
        {
            int rand = Random.Range(0, 100);
            if (rand < randomness)
            {
                anim.SetTrigger("Drop");
                GameObject temp = Instantiate(ball, dropPoint.position, Quaternion.identity);
            }
            yield return wait;
        }
        
    }
    private void Move()
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
        this.transform.position += this.transform.up * Mathf.Sin(Time.time * frequency) * Time.deltaTime * moveSpeed;
    }
   
   
 

}
