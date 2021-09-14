using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //private SpriteRenderer sr;
    public bool isActive = true;
    public Lever otherLever;
    [SerializeField] Transform relatedLauncher;
    private void Start()
    {
        //sr = this.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (isActive)
        {
            // sr.color = Color.green;
            this.GetComponent<Animator>().SetBool("isActive",true);
        }
        else
        {
            //sr.color= Color.red;
            this.GetComponent<Animator>().SetBool("isActive", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(isActive)
            {
                Button.currentLauncher = relatedLauncher;
                this.isActive = false;
                this.otherLever.isActive = false;
            }
               
            
        }
    }
}
