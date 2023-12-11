using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject _crossSpriteMusic;
    [SerializeField] private GameObject _checkSpriteMusic;
	[SerializeField] private GameObject _crossSpriteSound;
	[SerializeField] private GameObject _checkSpriteSound;

	[SerializeField] private AudioSource _audioSource;

	private void Start()
	{
        _audioSource = GetComponent<AudioSource>();

		_crossSpriteMusic.SetActive(!DataKeeper.GetMusicEnabled());
		_crossSpriteSound.SetActive(!DataKeeper.GetSoundEnabled());

		_checkSpriteMusic.SetActive(DataKeeper.GetMusicEnabled());
		_checkSpriteSound.SetActive(DataKeeper.GetSoundEnabled());
	}
	public void ChangeSoundActivity() 
    {
        var enabled = DataKeeper.GetSoundEnabled();
        DataKeeper.SetSoundEnabled(!enabled);
        ChangeSpriteSound(!enabled);
    }
    public void ChangeMusicActivity()
    {
        var enabled = DataKeeper.GetMusicEnabled();
        DataKeeper.SetMusicEnabled(!enabled);
        ChangeSpriteMusic(!enabled);
    }
    public void ChangeSpriteSound(bool isEnabled)
    {
        _checkSpriteSound.SetActive(isEnabled);
        _crossSpriteSound.SetActive(!isEnabled);
    }
	public void ChangeSpriteMusic(bool isEnabled)
	{
		_checkSpriteSound.SetActive(isEnabled);
		_crossSpriteSound.SetActive(!isEnabled);
	}
	public void PlayClickSound()
    {
		var enabled = DataKeeper.GetSoundEnabled();
        if (!enabled) return;

		_audioSource.Play();
    }
}
