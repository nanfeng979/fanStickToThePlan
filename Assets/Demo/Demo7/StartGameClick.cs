using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameClick : MonoBehaviour, Y9g.IButtonClick
{
    public string NextSceneName;

    public void Execute()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}