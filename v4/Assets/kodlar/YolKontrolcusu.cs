using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YolKontrolcusu : MonoBehaviour
{
    public GameObject[] level1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "YolunBasi")
        {
            GameObject yol = Instantiate(level1[Random.Range(0, level1.Length)], other.transform.parent.Find("yolun_sonu").position,  other.transform.parent.parent.rotation, other.transform.parent.parent);
            yol.transform.position = new Vector3(yol.transform.position.x, 0, yol.transform.position.z);
        }

        if (other.tag == "YolunSonu")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
