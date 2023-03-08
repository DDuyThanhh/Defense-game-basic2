using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME.DefenseBasic
{
    public class Weapon : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag(Const.ENEMY_TAG))
            {
                Enemy enemy = col.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.Die();
                }
            }
        }
    }
}
