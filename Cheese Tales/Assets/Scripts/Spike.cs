using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
   GameObject[] spikes;

    private void Awake()
    {
        spikes = new GameObject[this.transform.childCount];
        for(int i =0;i<this.transform.childCount;i++)
        {
            spikes[i] = this.transform.GetChild(i).gameObject;
        }
    }
    public enum SpikeType
    {
        Fall,Static
    }
    [SerializeField] SpikeType spikeType;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpikeFall());
        }
    }
    IEnumerator SpikeFall()
    {
        if (spikeType == SpikeType.Fall)
        {
            while(true)
            {
                foreach (GameObject spike in spikes)
                {
                    spike.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    yield return new WaitForSeconds(1f);
                }
                break;
            }
            
        }
    }

}
