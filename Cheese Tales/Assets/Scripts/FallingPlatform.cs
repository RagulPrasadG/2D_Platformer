using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float fallTime = 1.5f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Fall());
            this.GetComponent<Animator>().Play("Start Falling");
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallTime);
        this.gameObject.SetActive(false);
        
        //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
