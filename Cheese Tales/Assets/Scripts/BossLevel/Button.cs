using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Button : MonoBehaviour
{
    [SerializeField] Transform launcher1;
    [SerializeField] Transform launcher2;
    public static Transform currentLauncher = null;
    [SerializeField] GameObject missile;
    [SerializeField] float missileSpeed;

    [SerializeField] Lever lever1;
    [SerializeField] Lever lever2;


   
    private void Start()
    {
        currentLauncher = null;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            lever1.isActive = true;
            lever2.isActive = true;

            this.GetComponent<Animator>().SetTrigger("Press");
            if(currentLauncher != null)
            {
                Fire();
                currentLauncher.GetComponentInParent<Animator>().SetTrigger("Shoot");
            }
        }
        currentLauncher = null;
    }
    private void Fire()
    {
        GameObject temp = Instantiate(missile, currentLauncher.position, currentLauncher.rotation);
        temp.GetComponent<Rigidbody2D>().AddForce(currentLauncher.transform.right* missileSpeed, ForceMode2D.Impulse);
    }
}
