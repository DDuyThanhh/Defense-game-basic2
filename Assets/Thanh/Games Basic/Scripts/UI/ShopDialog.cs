using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GAME.DefenseBasic
{
    public class ShopDialog : DiaLog, IComponentChecking
    {
        public Transform gridRoot;
        public ShopItemUI itemUIPrefabs;

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            UpdateUI();
        }

        public bool IsComponentsNull()
        {
            return GameManager.GameMg != null && ShopManager.ShopMg == null || gridRoot == null;
        }

        private void UpdateUI()
        {
            if (IsComponentsNull()) return;

            ClearChild();

            var items = ShopManager.ShopMg.items;

            if (items == null || items.Length <= 0) return;

            for (int i = 0; i < items.Length; i++)
            {
                int idx = i;

                var item = items[idx];

                var itemUIClone = Instantiate(itemUIPrefabs, Vector3.zero, Quaternion.identity);
                //Set file cha cho Items là gird
                itemUIClone.transform.SetParent(gridRoot);
                //set Scale lại là 1
                itemUIClone.transform.localScale = Vector3.one;
                //reset lại Postition
                itemUIClone.transform.localPosition = Vector3.zero;
                //Lấy các Hero từ trong mảng ShopItem
                itemUIClone.UpdateUI(item, idx);
                //
                if (itemUIClone.btn)
                {
                    itemUIClone.btn.onClick.RemoveAllListeners();
                    itemUIClone.btn.onClick.AddListener(() => ItemEvent(item, idx));
                }
            }
        }

        //Bắt sự kiện click mua item
        private void ItemEvent(ShopItem item, int itemIdx)
        {
            if (item == null) return;

            //Lấy các trạng thái của Item đã lưu trong máy người chơi
            bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);

            if (isUnlocked)
            {
                //Nếu click vào item đã sỡ hữu sẽ không thay đổi gì
                if (itemIdx == Pref.curPlayerID) return;

                //Nếu click vào item chưa sở hữu thì sẽ thay đổi giá trị item
                Pref.curPlayerID = itemIdx;
                UpdateUI();
            }
            else if(Pref.coins >= item.price)
            {
                //Khi đủ tiền mua sẽ trừ đi số vàng người chơi đang có
                Pref.coins -= item.price;
                //Khi mua được sẽ mở khóa item
                Pref.SetBool(Const.PLAYER_PREFIX_PREF + itemIdx, true);
                Pref.curPlayerID = itemIdx;
                UpdateUI();
                //Cập nhật lại số vàng còn lại của người chơi
                GUIManager.Gui.UpdateMainCoins();
            }
            else
            {
                Debug.Log("You don't have enough money!");
            }

        }

        public void ClearChild()
        {
            //Khi gridRoot không có dữ liệu thì sẽ ngắt code
            if (gridRoot == null || gridRoot.childCount <= 0) return;
            for(int i = 0; i < gridRoot.childCount; i++)
            {
                var child = gridRoot.GetChild(i);

                if (child)
                    Destroy(child.gameObject);
            }
        }
    }
}
