using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionDoor : MonoBehaviour
{

    [SerializeField] int nextLevelID;
    [SerializeField] float transitDelay;

    [HideInInspector]
    public bool isUnlocked = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(ChangeScene(other));
    }
    IEnumerator ChangeScene(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           if(isUnlocked)
            {
                this.GetComponent<Animator>().SetBool("isOpen", true);
                yield return new WaitForSeconds(transitDelay);
                UIManager.LoadScene(nextLevelID);
            }
        }
    }
}
