using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME.DefenseBasic
{
    public class Const
    {
        //Khai báo các Tag
        public const string PLAYER_TAG = "Player";
        public const string ENEMY_TAG = "Enemy";
        public const string WEAPON_TAG = "Weapon";

        //Khai báo các tham số của Animations
        public const string ATTACK_ANIM = "Attacking";
        public const string DEAD_ANIM = "Dead";

        //Khai báo các hằng số về layer
        public const string DEAD_LAYER = "Dead";

        //Hằng số cho Key của PlayerPrefs
        public const string BEST_SCORE_PREF = "best_score";
        public const string PLAYER_PREFIX_PREF = "player_";
        public const string CUR_PLAYER_ID_PREF = "cur_player_id";
        public const string COINS_PREF = "coins";

        //Key âm thanh
        public const string MUSIC_VOL_PREF = "music_vol";
        public const string SOUND_VOL_PREF = "sound_vol";

        public const string GAME_PLAY_SCENE = "Gameplay";

    }
}
