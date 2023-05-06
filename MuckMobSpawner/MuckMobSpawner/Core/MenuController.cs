using MuckMobLoader.Behaviours;
using MuckMobSpawner;
using MuckMobSpawner.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MuckMobLoader.Core
{
    internal class MenuController
    {
        internal static MenuController menuController;

        private int ItemsPerPage = 4;
        private int PageIndex;
        private int MaxPages;

        private GameObject MainMenu;

        private Transform ButtonGrouping;
        private GameObject BaseButton;
        private GameObject LeftArrow;
        private GameObject RightArrow;

        private List<GameObject> Buttons = new List<GameObject>();

        public MenuController(Transform MainMenu)
        {
            menuController = this;
            this.MainMenu = MainMenu.gameObject;

            if (Main.VersionInvalid)
                MainMenu.Find("Version").GetComponent<TextMeshProUGUI>().text = $"New version available : {Main.OnlineVersion}";

            ButtonGrouping = MainMenu.Find("Main");
            BaseButton = ButtonGrouping.GetChild(0).gameObject;
            LeftArrow = MainMenu.Find("BackPage").gameObject;
            RightArrow = MainMenu.Find("NextPage").gameObject;
            MainMenu.gameObject.AddComponent<DestroyListener>();

            LeftArrow.transform.localPosition = new Vector3(-65, -110, 0);
            RightArrow.transform.localPosition = new Vector3(65, -110, 0);
            LeftArrow.GetComponent<Button>().onClick.AddListener(PreviousPage);
            RightArrow.GetComponent<Button>().onClick.AddListener(NextPage);

            MaxPages = MobSpawner.Instance.allMobs.Length / ItemsPerPage;
            LeftArrow.SetActive(false);

            InputManager();
            DrawPage();
            MainMenu.gameObject.SetActive(false);
        }

        private async void InputManager()
        {
            while (true)
            {
                if (menuController == null)
                    break;

                if (Input.GetKeyDown(Configuration.OpenMenuKey.Value))
                {
                    bool enabled = !MainMenu.activeSelf;
                    MainMenu.SetActive(enabled);
                    SetCursor(enabled);
                }

                if (Input.GetKeyDown(Configuration.PrevKey.Value) && LeftArrow.activeSelf)
                    PreviousPage();
                else if (Input.GetKeyDown(Configuration.NextKey.Value) && RightArrow.activeSelf)
                    NextPage();

                await Task.Delay(1);
            }

            void SetCursor(bool Enabled)
            {
                Cursor.visible = Enabled;
                Cursor.lockState = Enabled ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }

        public void DrawPage()
        {
            DestroyPage();
            int AbsoluteIndex = PageIndex * ItemsPerPage;
            for (int i = AbsoluteIndex; i < AbsoluteIndex + ItemsPerPage; i++)
            {
                if (i >= MobSpawner.Instance.allMobs.Length)
                    break;
                GameObject button = GameObject.Instantiate(BaseButton, ButtonGrouping);
                button.AddComponent<SpawnMobButton>().MobIndex = i;
                button.SetActive(true);
                Buttons.Add(button);
                i.Log();
            }
        }

        public void DestroyPage()
        {
            "Destroying Page".Log();
            foreach (var gameObject in Buttons)
            {
                GameObject.Destroy(gameObject);
            }
            Buttons.Clear();
        }

        public void NextPage()
        {
            LeftArrow.SetActive(true);
            PageIndex++;
            if (PageIndex >= MaxPages)
            {
                RightArrow.SetActive(false);
            }
            DrawPage();
        }

        public void PreviousPage()
        {
            RightArrow.SetActive(true);
            PageIndex--;
            if (PageIndex == 0)
            {
                LeftArrow.SetActive(false);
            }
            DrawPage();
        }
    }
}
