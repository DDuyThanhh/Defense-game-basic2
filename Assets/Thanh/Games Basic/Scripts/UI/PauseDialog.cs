using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GAME.DefenseBasic
{
    public class PauseDialog : DiaLog
    {
        public override void Show(bool isShow)
        {
            //Dừng tất cả thời gian lại
            Time.timeScale = 0;
            base.Show(isShow);
        }

        public void Resume()
        {
            Close();
        }

        public void Replay()
        {
            Close();
            SceneManager.LoadScene(Const.GAME_PLAY_SCENE);
        }

        public override void Close()
        {
            //Đưa tất cả quay lại bình thường
            Time.timeScale = 1f;
            base.Close();
        }
    }
}
