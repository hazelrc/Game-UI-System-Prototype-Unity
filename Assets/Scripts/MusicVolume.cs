using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
    private AudioSource mainMusic; // drag AudioSource utama
    public Slider slider;

    private const string VolumeKey = "musicVolume";
    public void Start() {
        mainMusic = GameObject.Find("Main Camera").gameObject.GetComponent<AudioSource>();
    }

    public void Update() {
        slider.value = mainMusic.volume;
    }


    
}