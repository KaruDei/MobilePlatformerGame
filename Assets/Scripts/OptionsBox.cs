using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsBox : MonoBehaviour
{
    [SerializeField] private Animator _optionBoxAnimator;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenOptions()
    {
        _optionBoxAnimator.SetBool("Open", true);
    }

    public void CloseOptions()
    {
        _optionBoxAnimator.SetBool("Open", false);
    }
}
