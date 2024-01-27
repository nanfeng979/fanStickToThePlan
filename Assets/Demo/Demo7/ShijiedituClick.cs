using UnityEngine;
using UnityEngine.SceneManagement;
using Y9g;

public class ShijiedituClick : MonoBehaviour, IButtonClick
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Demo7");
    }
}