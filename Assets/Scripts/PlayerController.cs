using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text counttext;
    public Text wintext;
    string rev;
   
 
    void Start()
    {
        
       
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        wintext.text = "";

    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(9);
        }
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
           
            string cubestring = other.GetComponent<Checker>().nameLable.text.ToString();
            

            if(Spawner.TuringMachinebrackets(cubestring))
            {
                gameObject.GetComponent<AudioSource>().Play();
                other.gameObject.SetActive(false);
                count++;
                setCountText();
                
            }else
            {
                Debug.Log(Spawner.Matchingcheck(cubestring));
            }

          
        }else if(other.gameObject.CompareTag("secret"))
                    {

                     other.gameObject.SetActive(false);

            GameObject[] allcubes=GameObject.FindGameObjectsWithTag("Pick Up");
            for(int i=0;i<=allcubes.Length-1;i++)
            {
                if (Spawner.TuringMachinebrackets(allcubes[i].GetComponent<Checker>().nameLable.text.ToString()))
                    {
                    var cubeRenderer = allcubes[i].GetComponent<Renderer>();
                    allcubes[i].GetComponent<ParticleSystem>().Play();

                    cubeRenderer.material.color = Color.red;
                }
            }
        }
    }

    void setCountText()
    {
        counttext.text = "Count: " + count.ToString();
        if(count==18)
        {
            wintext.text =  18+" Balanced bracket strings captured";
        }
    }


   
}

