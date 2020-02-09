using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("EIEI");
            StartCoroutine(Respawn(other));
        }
    }

    IEnumerator Respawn(Collider other)
    {
        BoxCollider b = other.GetComponent<BoxCollider>();
        b.enabled = false;
        yield return new WaitForSeconds(1.5f);
        b.enabled = true;
        other.transform.position = new Vector3(0, 8, 0);
    }
}
