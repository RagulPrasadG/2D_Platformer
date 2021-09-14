using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMortar : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private bool isAlive = true;
    [SerializeField] Transform target;
    [SerializeField] GameObject fireBallPrefab;
    private Transform firePoint;
    [SerializeField] float speed;
    private WaitForSeconds wait;
    private Animator anim;


    private void Awake()
    {
        anim = this.GetComponent<Animator>();
        wait = new WaitForSeconds(fireRate);
        firePoint = this.transform.GetChild(0).transform;
    }
    private void Start()
    {     
        StartCoroutine(Fire());  
        
    }
    IEnumerator Fire()
    {
      
        while(isAlive)
        {
            yield return wait;
            if (CalculateAngle() != null)
            {
                anim.SetTrigger("Fire");
                GameObject temp = Instantiate(fireBallPrefab, firePoint.position, Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().AddForce(speed * firePoint.transform.right, ForceMode2D.Impulse);

            } 
        }
    }
    private void Update()
    {
        CheckForPlayer();      // Checks for player around a radius

        float? angle = CalculateAngle();
        if (angle != null)
        {
            firePoint.transform.localEulerAngles = new Vector3(0f, 0f, (float)angle);
        }

        
    }
    
    float? CalculateAngle()
    {
        Vector2 targetDir = target.transform.position - this.transform.position;
        float y = targetDir.y;
        targetDir.y = 0f;
        float x = targetDir.x;
        float gravity = 9.81f;
        float sSqr = speed * speed;
        float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);

        if (underTheSqrRoot >= 0f)
        {
            float root = Mathf.Sqrt(underTheSqrRoot);
            float highAngle = sSqr + root;
            return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);

        }
        else
            return null;
    }
    private void CheckForPlayer()
    {
        if (Physics2D.CircleCast(this.transform.position, 18f, transform.right))
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 18f);
    }
}
