using UnityEngine;

namespace Ghost.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        public bool isMuted;
    
        [Header("Music and ambiance")]
        public AudioClip menuMusic;
        public AudioClip levelMusic;

        [Header("Sound Effects")]
        public AudioClip dog;
        public AudioClip door;
        public AudioClip dying;
        public AudioClip save;
        public AudioClip tomb;

        AudioSource audioSource;
        
        AudioSource musicPlayer;
        AudioSource ambiancePlayer;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();

            musicPlayer = gameObject.AddComponent<AudioSource>();
            ambiancePlayer = gameObject.AddComponent<AudioSource>();
        }

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.M))
            {
                isMuted = !isMuted;
            }

            audioSource.mute = isMuted;
            musicPlayer.mute = isMuted;
            ambiancePlayer.mute = isMuted;
        }

        public void PlaySound(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        public void StartMusic(AudioClip clip)
        {
            musicPlayer.clip = clip;
            musicPlayer.loop = true;
            musicPlayer.Play();
        }
        
        public void StopMusic()
        {
            musicPlayer.Stop();
        }

        public void StartAmbiance(AudioClip clip)
        {
            ambiancePlayer.clip = clip;
            ambiancePlayer.loop = true;
            ambiancePlayer.Play();
        }

        public void StopAmbiance()
        {
            ambiancePlayer.Stop();
        }
    }
}