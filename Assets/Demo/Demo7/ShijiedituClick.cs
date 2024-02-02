using UnityEngine;
using UnityEngine.SceneManagement;
using Y9g;

public class ShijiedituClick : MonoBehaviour, IButtonClick
{
    [SerializeField]
    private string NextSceneName;

    public void Execute()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}