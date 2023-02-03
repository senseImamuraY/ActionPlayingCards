using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject effect;

    public Transform effectPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (LevelManager.instance.respawnPoint != transform.position)
            {
                LevelManager.instance.respawnPoint = transform.position;

                if (effect != null)
                {
                    Instantiate(effect, effectPoint.position, Quaternion.identity);

                    Checkpoint[] allCP = FindObjectsOfType<Checkpoint>();
                    foreach (Checkpoint cp in allCP)
                    {
                        cp.gameObject.transform.Find("StarUp").gameObject.transform.Find("rewerUpSphere").gameObject.SetActive(false);
                    }
                    transform.Find("StarUp").gameObject.transform.Find("rewerUpSphere").gameObject.SetActive(true);
                }
            }
        }
    }
}
