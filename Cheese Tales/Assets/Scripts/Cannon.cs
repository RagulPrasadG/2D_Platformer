using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] bool canFire;
    private void Start()
    { 
        if(canFire)
        {
            StartCoroutine(Fire());
        }
       
    }
    IEnumerator Fire()
    {
        while(true)
        {
            GameObject temp = Instantiate(ball, this.transform.position, Quaternion.identity);
            temp.GetComponent<Rigidbody2D>().velocity = this.transform.right * 6f;
            yield return new WaitForSeconds(3f);
        }
    }
}
