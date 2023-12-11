using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfinityBackgroundMusic : MonoBehaviour
{
	[SerializeField] private GameObject _bgMusic;
	private AudioSource _audioSource;
	private float _time;
	private void Awake()
	{
		var sounds = GameObject.FindGameObjectsWithTag("bgMusic");

		_bgMusic = sounds.Length == 0 ? Instantiate(_bgMusic) : sounds[0];
		DontDestroyOnLoad(_bgMusic);

	}
	private void Start()
	{
		_audioSource = _bgMusic.GetComponent<AudioSource>();
		DataKeeper.SetSoundEnabled(true);
	}
	private void Update()
	{
		var isMusicEnabled = DataKeeper.GetMusicEnabled();
		if (!isMusicEnabled)
		{
			_time = _audioSource.time != 0 ? _audioSource.time : _time;
			_audioSource.Stop();
		}
		else if (isMusicEnabled && !_audioSource.isPlaying) 
		{
			_audioSource.time = _time;
			_audioSource.Play(); 
		}
	}
}
