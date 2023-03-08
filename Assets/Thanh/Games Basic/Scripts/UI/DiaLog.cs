using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GAME.DefenseBasic
{
    public class DiaLog : MonoBehaviour
    {
        public Text titleTxt;
        public Text contentTxt;

        public virtual void Show(bool isShow)
        {
            gameObject.SetActive(isShow);
        }

        public virtual void UpdateDialog(string title, string content)
        {
            if(titleTxt)
                titleTxt.text = content;

            if(contentTxt)
                contentTxt.text = content;
        }

        public virtual void UpdateDialog()
        {

        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
