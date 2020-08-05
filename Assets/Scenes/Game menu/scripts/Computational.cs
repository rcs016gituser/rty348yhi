using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computational : MonoBehaviour
{
    public void onclickpenguins()
    {
        SceneManager.LoadScene(2);
    }
    public void onclickhummingbirds()
    {
        SceneManager.LoadScene(3);
    }
    public void onclickreturn()
    {
        SceneManager.LoadScene(1);
    }
}

