using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MissileBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (other.gameObject.tag == "ChopperEnemy")
        {
            ChopperEnemy.health -= 30;
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject, 6f);
        }
    }
}
