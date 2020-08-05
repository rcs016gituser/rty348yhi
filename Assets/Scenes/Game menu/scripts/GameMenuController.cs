using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    public void onclickmlagents()
    {
        SceneManager.LoadScene("ML agents");
    }
    public void opencomputation()
    {
        SceneManager.LoadScene(6);
    }
    public void opencourselearning()
    {
        SceneManager.LoadScene(5);
    }

    [System.Obsolete]
    public void onwebclick()
    {
		
      
	   if (Application.isEditor)
        {
             Application.OpenURL("http://www.niazilab.com/");
        }else
		{
		 Application.ExternalEval("window.open(\"http://www.niazilab.com/\",\"_blank\")");
		}
	   
    }


    public void onquitclick()
    {

    #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
    #endif
    #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
    #elif (UNITY_STANDALONE)
        Application.Quit();
    #elif (UNITY_WEBGL)
        Application.OpenURL("about:blank");
    #endif
    

        


}
    public void onpalindromelanguage()
    {
        SceneManager.LoadScene(8);
    }

    public void openpalindromemenu()
    {
        SceneManager.LoadScene(7);
    }
    
    public void openmainmenu()
    {
        SceneManager.LoadScene(1);
    }
    public void openbracketsmenu()
    {
        SceneManager.LoadScene(9);
    }
    public void openbracketslanguage()
    {
        SceneManager.LoadScene(10);
    }
    public void openpalindromeworld()
    {
        SceneManager.LoadScene(11);
    }
    public void openbracketsworld()
    {
        SceneManager.LoadScene(12);
    }
}

