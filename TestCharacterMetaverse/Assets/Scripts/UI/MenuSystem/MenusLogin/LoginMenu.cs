using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using jdmozo.Backend;

namespace jdmozo.UI
{
    public class LoginMenu : Menu
    {
        private const string _emailParam1 = "@";
        private const string _emailParam2 = ".";

        [SerializeField] private TMP_InputField _emailInputField;
        [SerializeField] private TMP_InputField _passwordInputField;

        [SerializeField] private Button _loginButton;
        [SerializeField] private Button _registerButton;

        [SerializeField] private Menu _signUpMenu;

        private void OnEnable()
        {
            _loginButton.interactable = false;
        }

        private void Start()
        {
            _emailInputField.onValueChanged.AddListener(delegate { CheckMenu(); });
            _loginButton.onClick.AddListener(delegate { Login(); });
            _registerButton.onClick.AddListener(delegate { MenuManager.ChangeMenu(this, _signUpMenu); });
        }

        private void CheckMenu()
        {
            if (_emailInputField.text.Contains(_emailParam1) && _emailInputField.text.Contains(_emailParam2))
                _loginButton.interactable = true;
            else
                _loginButton.interactable = false;
        }

        private void Login() => StartCoroutine(LogginProcess());

        private IEnumerator LogginProcess()
        {
            AuthController.instance.AuthEmail(_emailInputField.text, _passwordInputField.text);

            yield return new WaitUntil(() => AuthController.instance.logged == true );
            
            AuthController.instance.database.GetFirestoreData("users", "ReadyPlayerMe");

            AuthController.OnLogged?.Invoke();
        }
    }
}
