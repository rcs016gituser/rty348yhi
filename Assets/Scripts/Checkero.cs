using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Checkero : MonoBehaviour
{

    public Text nameLable;

    // Start is called before the first frame update
    void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);

        foreach (Collider col in colliders)
        {
            if (col.tag == "mazewalls")
            {
                Debug.Log("spawned too close or on wall");
               // var cubeRenderer = transform.GetComponent<Renderer>();
               //
               // cubeRenderer.material.SetColor("_Color", Color.red);

                Vector3 position= new Vector3(UnityEngine.Random.Range(-9, 9.4f), 0.5f, UnityEngine.Random.Range(-4.24f, 13.62f));
                GameObject original = gameObject;
                GameObject retry = Instantiate(original, position, Quaternion.identity);

                original.SetActive(false);
                Destroy(original);

            }
        }

              //  Destroy(transform);
    }
   
   

    // Update is called once per frame
    void Update()
    {
        Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLable.transform.position = namePose;
    }
}
