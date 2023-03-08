using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME.DefenseBasic
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public static GameManager GameMg;

        public float spawnTime;
        public Enemy[] enemyPrefabs;
        public ShopManager shopManager;
        private Player m_curPlayer;
        private bool m_isGameover;
        private int m_score;

        public int Score { get => m_score; set => m_score = value; }

        private void Awake()
        {
            GameMg = this;
            //MakeSingleton();
        }

        //private void MakeSingleton()
        //{
        //    if (GameMg == null)
        //    {
        //        GameMg = this;
        //        DontDestroyOnLoad(this);
        //    }
        //    else
        //    {
        //        Destroy(gameObject);
        //    }
        //}

        // Start is called before the first frame update
        void Start()
        {
            if(IsComponentsNull()) return;

            //Khi Vào game sẽ hiển thị HomeGUI trước
            GUIManager.Gui.ShowGameGUI(false);
            //Cập nhật lại coins người chời đạt được ở HomeGUI
            GUIManager.Gui.UpdateMainCoins();
        }

        public bool IsComponentsNull()
        {
            return GUIManager.Gui == null || shopManager == null || AudioController.AudioCtr == null;
        }

        //Sau khi tắt giao diện HomeGUI thì sẽ vào game
        public void PlayGame()
        {
            if(IsComponentsNull()) return;

            ActiveItem();
            StartCoroutine(SpawnEnemy());
            //Khi PlayGame sẽ hiển thị GameGUI
            GUIManager.Gui.ShowGameGUI(true);
            //Cập nhật lại số vàng người chơi đạt ducợ9 ở giao diện GameGUI
            GUIManager.Gui.UpdateGamePlayCoins();
            AudioController.AudioCtr.PlayBGMusic();
        }

        public void ActiveItem()
        {
            if(IsComponentsNull()) return;

            //Nếu người chơi chọn hero khác thì xóa hero cũ 
            if(m_curPlayer)
                Destroy(m_curPlayer.gameObject);

            var shopItems = shopManager.items;

            if (shopItems == null || shopItems.Length < 0) return;

            var newPlayerPrefabs = shopItems[Pref.curPlayerID].playerPrefab;

            //Tạo ra hero mới mà người chơi chọn
            if(newPlayerPrefabs)
                m_curPlayer = Instantiate(newPlayerPrefabs, new Vector3(- 7f, -1f, 0), Quaternion.identity);
        }

        //Set điều kiện hiển thị hộp thoại GameOver
        public void GameOver()
        {
            //Nếu game kết chưa kết thúc thì ngắt các câu lệnh bên dưới
            if(m_isGameover) return;
            //Set điều kiện thành true
            m_isGameover = true;
            //Lưu lại điểm số cao nhất cho người chơi
            Pref.bestScore = m_score;

            //Khi trò chơi kết thúc hiển thị hộp thoại GameOver
            if (GUIManager.Gui.gameOverDialog)
                GUIManager.Gui.gameOverDialog.Show(true);

            AudioController.AudioCtr.PlaySound(AudioController.AudioCtr.gameOver);
        }

        IEnumerator SpawnEnemy()
        {
            while(!m_isGameover) {
                if (enemyPrefabs != null && enemyPrefabs.Length > 0)
                {
                    int ranIdx = Random.Range(0, enemyPrefabs.Length); //Từ 0 - 3, sẽ lấy ngẫu nhie n từ 0 - 2 (không lấy giá trị max là 3)

                    Enemy enemyPrefab = enemyPrefabs[ranIdx];

                    if (enemyPrefab != null)
                    {
                        Instantiate(enemyPrefab, new Vector3(5.23f, -0.914f, 0), Quaternion.identity);
                    }
                }

                yield return new WaitForSeconds(spawnTime);
            }
        }
    }
}
