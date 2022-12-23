using System.Collections;

using UnityEngine;

using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{

    public void GoToNextScene(int level)
    {
        if (level == 0)
        {
            StartCoroutine(SceneTransition("world_1"));
        }
        else if (level == 1)
        {
            StartCoroutine(SceneTransition("world_2_mesh"));
        }
        else if (level > 1)
        {
            print("mesh_level");
            
            StartCoroutine(SceneTransition("world_2_mesh"));
            
        }
    }
    
    IEnumerator SceneTransition(string nameScene)
    {

        //Mettre le bon nom du menu

        AsyncOperation asyncload = SceneManager.LoadSceneAsync(nameScene);
        while (!asyncload.isDone)
        {
            yield return null;
        }
    }
}
