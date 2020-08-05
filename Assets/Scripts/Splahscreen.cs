using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splahscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Openmenu());
    }

    
    IEnumerator Openmenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
