using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spider : MonoBehaviour
{
 
    private LineRenderer lineRenderer;
    private Vector2 start;
    private Vector2 end;
    private bool canGoDown = false;
   

    private void Start()
    {
        start = this.transform.position;
        end = this.transform.GetChild(0).transform.position;
        lineRenderer = GetComponent<LineRenderer>();
       
    }
    private void Update()
    {
        lineRenderer.SetPosition(0,start);
        lineRenderer.SetPosition(1,this.transform.position);
        if(canGoDown)
        {
           StartCoroutine(MoveDown());
        }
        else
        {
            MoveUp();
        }
       
    }
    private void MoveUp()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, start, 2f * Time.deltaTime);
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
    IEnumerator MoveDown()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, end, 5f * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        canGoDown = false;
           
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            canGoDown = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            UIManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
