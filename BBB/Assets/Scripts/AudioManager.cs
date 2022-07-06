using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;
	public static bool bossMusic = false;

	void Awake()
	{
		//if (instance != null)
		//{
		//	Destroy(gameObject);
		//}
		//else
		//{
		//	instance = this;
		//	DontDestroyOnLoad(gameObject);
		//}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	void Start()
	{
		if (SceneManager.GetActiveScene().name == "Tutorial")
		{
			Play("Tutorial_Theme");
		}

		if (SceneManager.GetActiveScene().name == "Level_1")
		{
			Play("L1_Theme");
		}

		if (SceneManager.GetActiveScene().name == "Level_2")
		{
			Play("L2_Theme");
		}

		if (SceneManager.GetActiveScene().name == "Level_3")
		{
			Play("L3_Theme");
		}
	}

	void Update() 
	{
		if (GameManager.inBossFight == true)
			{
				if (bossMusic == false)
				{
					bossMusic = true;
					if (SceneManager.GetActiveScene().name == "Level_1")
					{
						StopPlay("L1_Theme");
						Play("Boss_Theme");
					}

					if (SceneManager.GetActiveScene().name == "Level_2")
					{
						StopPlay("L2_Theme");
						Play("Boss_Theme");
					}

					if (SceneManager.GetActiveScene().name == "Level_3")
					{
						Debug.Log("level 3 music shift happening properly here");
						StopPlay("L3_Theme");
						Play("Boss_Theme");
					}
				}
			}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}
	public void PlayOneShot(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.PlayOneShot(s.clip, s.volume);
	}

	public void StopPlay (string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Stop ();
	}

}