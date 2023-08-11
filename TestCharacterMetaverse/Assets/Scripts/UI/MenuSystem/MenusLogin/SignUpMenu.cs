using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using jdmozo.Backend;

namespace jdmozo.UI
{
    public class SignUpMenu : Menu
    {
        [SerializeField] private TMP_InputField _emailInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        [SerializeField] private TMP_InputField _passwordRepeatInputField;
        [SerializeField] private Button _registerBtn;
        [SerializeField] private Button _loginBtn;

        [SerializeField] private Menu _LoginMenu;

        private void Start()
        {
            _registerBtn.onClick.AddListener(delegate { SignIn(); });
            _loginBtn.onClick.AddListener(delegate { MenuManager.ChangeMenu(this, _LoginMenu); });
        }

        private void SignIn() => StartCoroutine(SignInProcess());

        private IEnumerator SignInProcess()
        {
            AuthController.instance.SignUpEmail(_emailInputField.text, _passwordInputField.text);

            yield return new WaitUntil(() => AuthController.instance.logged == true);

            AuthController.instance.database.AddFirestoreData("users", "ReadyPlayerMe", "-");
            AuthController.OnLogged?.Invoke();
        }
    }
}
