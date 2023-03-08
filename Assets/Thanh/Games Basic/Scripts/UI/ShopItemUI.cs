using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GAME.DefenseBasic
{
    public class ShopItemUI : MonoBehaviour
    {
        public Text priceTxt;
        public Image hud;
        public Button btn;

        public void UpdateUI(ShopItem item, int itemIdx)
        {
            if (item == null) return;

            if (hud)
                hud.sprite = item.image;

            bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);

            if(isUnlocked)
            {
                if(Pref.curPlayerID == itemIdx)
                {
                    if (priceTxt)
                        priceTxt.text = "Active";
                }
                else if(priceTxt)
                {
                    priceTxt.text = "Owned";
                }
            }
            else
            {
                if(priceTxt)
                    priceTxt.text = item.price.ToString();
            }
        }
    }
}
