using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameClick : MonoBehaviour, Y9g.IButtonClick
{
    public void Execute()
    {
        SceneManager.LoadScene("Demo7_2");
    }
}