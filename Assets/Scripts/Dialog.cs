using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Animator _buttonAnimator;
    [SerializeField] private Animator _dialogBoxAnimator;
    [SerializeField] private TekeCoin _money;
    [SerializeField] private TextMeshProUGUI _dialogText;

    private string _defaultText;

    private void Awake()
    {
        _defaultText = _dialogText.text;
    }

    public void OpenDialog ()
    {
        _dialogText.text = _defaultText;
        _buttonAnimator.SetBool("Open", false);
        _dialogBoxAnimator.SetBool("Open", true);
    }

    public void ExitDialog ()
    {
        _dialogBoxAnimator.SetBool("Open", false);
    }

    public void OpenButton ()
    {
        _buttonAnimator.SetBool("Open", true);
    }

    public void CloseButton ()
    {
        _buttonAnimator.SetBool("Open", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DialogTrigger")
            OpenButton();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DialogTrigger")
            CloseButton();
    }

    public void NextScene()
    {
        if (_money._money == 15)
            SceneManager.LoadScene("EndScene");
        else
            _dialogText.text = "You don't have any money!";
    }

}
