using UnityEngine.SceneManagement;
using jdmozo.Backend;

namespace jdmozo.UI
{
    public class LoginMenuManager : MenuManager
    {
        public Menu LoginMenu;
        public Menu SignUpMenu;

        private void OnEnable() => AuthController.OnLogged += ChangeScreen;

        private void OnDisable() => AuthController.OnLogged -= ChangeScreen;

        private void ChangeScreen() => SceneManager.LoadScene(1);

    }
}
