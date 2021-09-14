using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BombBall : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, this.GetComponent<Rigidbody2D>().velocity.y);
            Destroy(this);
            Destroy(gameObject, 10f);
        }
        if(other.gameObject.tag == "Player")
        {
            UIManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
