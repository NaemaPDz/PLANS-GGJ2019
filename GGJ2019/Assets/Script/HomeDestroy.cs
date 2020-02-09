using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StartFly()); 
    }

    IEnumerator StartFly()
    {
        yield return new WaitForSeconds(3f);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 10 * Time.deltaTime, this.transform.position.z);
    }
}
