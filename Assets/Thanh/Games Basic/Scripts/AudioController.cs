using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME.DefenseBasic
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController AudioCtr;

        [Header("Main Setting")]
        //Set giá trị min và max cho vollum
        [Range(0f, 1f)]
        public float musicVol = 0.3f;
        [Range(0f, 1f)]
        public float soundVol = 1f;

        public AudioSource musicAus;
        public AudioSource soundAus;

        [Header("Music and Sound in play")]
        public AudioClip playerAtk;
        public AudioClip enemyDead;
        public AudioClip gameOver;
        public AudioClip[] bgMusic;

        private void Awake()
        {
            AudioCtr = this;
        }

        private void Start()
        {
            if (musicAus == null && soundAus == null) return;

            musicVol = Pref.musicVol;
            soundVol = Pref.soundVol;

            musicAus.volume = musicVol;
            soundAus.volume = soundVol;
        }

        //Phương thức làm việc với Audio Sound
        public void PlaySound(AudioClip[] sounds, AudioSource aus = null)
        {
            if (!aus)
                aus = musicAus;

            if (aus == null) return;

            if (sounds == null || sounds.Length <= 0) return;

            int randIdx = Random.Range(0, sounds.Length);
            if (sounds[randIdx])
                aus.PlayOneShot(sounds[randIdx], soundVol);
        }

        public void PlaySound(AudioClip sound, AudioSource aus = null)
        {
            if(!aus)
                aus = soundAus;

            if (aus == null) return;

            if(sound)
                aus.PlayOneShot(sound, soundVol);
        }

        //Phương thức làm việc với Audio Sound
        public void PlayMusci(AudioClip[] music, bool isLoop = true)
        {
            if (musicAus == null || music == null || music.Length <= 0) return;

            int randIdx = Random.Range(0, music.Length);

            if (music[randIdx])
            {
                musicAus.clip = music[randIdx];
                musicAus.loop = isLoop;
                musicAus.volume = musicVol;
                musicAus.Play();
            }
        }

        public void PlayMusic(AudioClip music, bool isLoop = true)
        {
            if(musicAus  == null || music == null) return;

            musicAus.clip = music;
            musicAus.loop = isLoop;
            musicAus.volume = musicVol;
            musicAus.Play();
        }

        //Các phương thức hỗ trợ Audio
        public void SetMusicVol(float vol)
        {
            if(musicAus == null) return;

            musicAus.volume = vol;
        }

        public void StopMusic()
        {
            if (musicAus == null) return;

            musicAus.Stop();
        }

        public void PlayBGMusic()
        {
            PlayMusci(bgMusic);
        }
    }
}
