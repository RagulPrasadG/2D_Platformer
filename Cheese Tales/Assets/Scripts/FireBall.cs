using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireBall : MonoBehaviour
{
    private void Start()
    {
        Destroy(this, 10f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player") 
        {
            UIManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
