using System.Collections.Generic;
using UnityEngine;

namespace jdmozo.UI
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private List<Menu> MenusInScene;
        [SerializeField] private List<Menu> _menusLog;

        public void ChangeMenu(Menu previousMenu, Menu nextMenu)
        {
            previousMenu.gameObject.SetActive(false);
            nextMenu.gameObject.SetActive(true);
        }
    }
}
