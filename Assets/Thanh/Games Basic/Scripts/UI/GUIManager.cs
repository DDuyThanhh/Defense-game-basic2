using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GAME.DefenseBasic
{
    public class GUIManager : MonoBehaviour
    {
        public static GUIManager Gui;

        public GameObject homeGUI;
        public GameObject gameGUI;
        public DiaLog gameOverDialog;
        public Text mainCoinsTxt;
        public Text gamePlayCoinsTxt;

        private void Awake()
        {
            Gui = this;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        public void ShowGameGUI(bool isShow)
        {
            //Khi hiển thị gameGUI thì homeGUI sẽ bị ẩn và ngược lại
            if(gameGUI)
                gameGUI.SetActive(isShow);

            if(homeGUI)
                homeGUI.SetActive(!isShow);
        }

        public void UpdateMainCoins()
        {
            if(mainCoinsTxt)
                mainCoinsTxt.text = Pref.coins.ToString();
        }

        public void UpdateGamePlayCoins()
        {
            if(gamePlayCoinsTxt)
                gamePlayCoinsTxt.text = Pref.coins.ToString();
        }
    }
}
