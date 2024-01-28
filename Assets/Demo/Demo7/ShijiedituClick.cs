using UnityEngine;
using UnityEngine.SceneManagement;
using Y9g;

public class ShijiedituClick : MonoBehaviour, IButtonClick
{
    public void Execute()
    {
        SceneManager.LoadScene("Demo7");
    }
}