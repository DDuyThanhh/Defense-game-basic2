using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GAME.DefenseBasic
{
    public class GameOverDialog : DiaLog
    {
        public Text bestScoreTxt;

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            if(bestScoreTxt)
                bestScoreTxt.text = Pref.bestScore.ToString("0");
        }

        public void Replay()
        {
            Close();
            SceneManager.LoadScene(Const.GAME_PLAY_SCENE);
        }

        public void QuitGame()
        {
            //Câu lệnh Application chỉ hoạt động trên đt, PC không hoạt động
            Application.Quit();
        }
    }
}
