using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 start;
    private Vector2 end;
    private bool canMoveUp = false;

    [SerializeField] BoxCollider2D trigger;
    private void Start()
    {
        
        end = this.transform.GetChild(0).transform.position;
        lineRenderer = GetComponent<LineRenderer>();

    }
    private void Update()
    {
        lineRenderer.SetPosition(0, this.transform.GetChild(1).transform.position);
        lineRenderer.SetPosition(1, end);

        if (canMoveUp) MoveUp();
    }
    private void MoveUp()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, end, 2f * Time.deltaTime);
        if(Vector2.Distance(this.transform.position,end) < 0.5f)
        {
            canMoveUp = false;
            MouseController.canMove = true;
        }
        
    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            canMoveUp = true;
            MouseController.canMove = false;
            trigger.enabled = false;
        }
    }
}
