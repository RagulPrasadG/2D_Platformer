using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            UIManager.LoadScene(1);
        }
        else if(other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
