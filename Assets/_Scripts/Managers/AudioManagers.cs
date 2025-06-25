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
        // Load lại giá trị âm lượng từ PlayerPrefs
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f); // Mặc định 1
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Cập nhật giá trị volume ban đầu
        ChangeBGMusic();

        // Gán sự kiện mỗi khi slider thay đổi
        MusicSlider.onValueChanged.AddListener((value) => SaveVolumes());
        SFXSlider.onValueChanged.AddListener((value) => SaveVolumes());

        // Bắt đầu phát nhạc nền
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
        if (BGMusic != null)
            BGMusic.volume = MusicSlider.value;

        if (SFX != null)
            SFX.volume = SFXSlider.value;
    }

    public void SFXPlay(AudioClip clip)
    {
        if (SFX != null && clip != null)
        {
            SFX.PlayOneShot(clip);
        }
    }

    private void SaveVolumes()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefs.Save(); 
    }
}
