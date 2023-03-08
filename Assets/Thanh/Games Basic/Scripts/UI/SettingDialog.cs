using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GAME.DefenseBasic
{
    public class SettingDialog : DiaLog, IComponentChecking
    {
        public Slider musicSlider;
        public Slider soundSlider;
        private AudioController m_auCtr;

        public bool IsComponentsNull()
        {
            return m_auCtr == null || musicSlider == null || soundSlider == null;
        }

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            m_auCtr = FindFirstObjectByType<AudioController>();

            if (IsComponentsNull()) return;

            musicSlider.value = Pref.musicVol;
            soundSlider.value = Pref.soundVol;
        }

        public void OnMusicChange(float value)
        {
            if (IsComponentsNull()) return;
            m_auCtr.musicVol = value;
            m_auCtr.musicAus.volume = value;
            Pref.musicVol = value;
        }

        public void OnSoundChange(float value)
        {
            if (IsComponentsNull()) return;

            m_auCtr.soundVol = value;
            m_auCtr.soundAus.volume = value;
            Pref.soundVol = value;
        }
    }
}
