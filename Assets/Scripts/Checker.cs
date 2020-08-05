using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Checker : MonoBehaviour
{

    public Text nameLable;

    void Start()
    {
  

        RaycastHit hit;
        float groundistance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, groundistance))
        {
            //spawned above the ground
        }
        else
        {
           // No ground whitin 1f distance below so inside a mountain, reinstantiate

            Vector3 position = new Vector3(UnityEngine.Random.Range(-8.1f, 37.8f), 0.5f, UnityEngine.Random.Range(18.4f, -28.2f));
            GameObject original = gameObject;
            GameObject retry = Instantiate(original, position, Quaternion.identity);

            original.SetActive(false);
            Destroy(original);
        }




    }
   
   

    // Update is called once per frame
    void Update()
    {
        Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLable.transform.position = namePose;
    }
}
