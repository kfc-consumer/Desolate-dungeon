using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);

    }

    public void OpenSettings()
    {
        SceneManager.LoadSceneAsync(3);
    }
    

    public void QuitGame()
    {
        Debug.Log("Quit game");
    }
}
