using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameClick : MonoBehaviour, Y9g.IButtonClick, Y9g.ISpace
{
    public string NextSceneName;

    public void Execute()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}