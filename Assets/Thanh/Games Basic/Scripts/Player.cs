using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME.DefenseBasic
{
    public class Player : MonoBehaviour, IComponentChecking
    {
        private Animator m_anim;
        public float atkRate;
        private float m_curAtkRate;
        private bool m_isAttacked;
        private bool isDead;

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAtkRate = atkRate;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        public bool IsComponentsNull()
        {
            return m_anim == null || GameManager.GameMg == null;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsComponentsNull()) return;
            //Check Ckick chuột trái
            if (Input.GetMouseButtonDown(0) && !m_isAttacked)
            {
                m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_isAttacked = true;
            }

            if (m_isAttacked)
            {
                m_curAtkRate -= Time.deltaTime;

                if (m_curAtkRate <= 0)
                {
                    m_isAttacked = false;
                    m_curAtkRate = atkRate;
                }
            }
        }

        public void ResetAtkAnim()
        {
            if (IsComponentsNull()) return;
            m_anim.SetBool(Const.ATTACK_ANIM, false);
        }

        public void PlayAtkSound()
        {
                AudioController.AudioCtr.PlaySound(AudioController.AudioCtr.playerAtk);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(IsComponentsNull()) return;
            if (col.CompareTag(Const.WEAPON_TAG) && !isDead)
            {
                m_anim.SetTrigger(Const.DEAD_ANIM);
                isDead = true;
                gameObject.layer = LayerMask.NameToLayer(Const.DEAD_LAYER);
                //Khi người chơi chết hiện GameOver
                GameManager.GameMg.GameOver();
            }
        }
    }
}
