using UnityEngine;
using UnityEngine.UI;

public class AudioManagers : MonoBehaviour
{
    [SerializeField] public AudioSource BGMusic;
    [SerializeField] public AudioSource SFX;
    [SerializeField] public AudioClip CoinClip;
    [SerializeField] public AudioClip JumpClip;
    [SerializeField] public AudioClip ShootClip;
    [SerializeField] public AudioClip BGMusicClip;
    [SerializeField] public Slider MusicSlider;
    [SerializeField] public Slider SFXSlider;
    public static AudioManagers Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {

        if (BGMusic != null)
        {
            BGMusic.clip = BGMusicClip;
            BGMusic.Play();
        }

    }

    private void Update()
    {
        ChangeBGMusic();
    }
    public void ChangeBGMusic()
    {
        BGMusic.volume = MusicSlider.value;
        SFX.volume = SFXSlider.value;
    }

    public void SFXPlay(AudioClip clip)
    {
        if (SFX != null && clip != null)
        {
            SFX.PlayOneShot(clip);
        }
    }
}
