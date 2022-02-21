using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manage the background audio of the game
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
	private static AudioManager instance;
	
	private List<AudioSource> uniqueAudios;
	private AudioSource backGroundMusic;
	
	private void Start()
	{
		if(instance)
		{
			Destroy(instance);
		}
		instance = this;
		uniqueAudios = new List<AudioSource>();
		backGroundMusic = GetComponent<AudioSource>();
	}
	
	public static AudioManager GetInstance()
	{
		if(!instance)
		{
			GameObject managerObject = new GameObject("AudioManager");
			managerObject.AddComponent<AudioManager>();
		}
		return instance;
	}
	
	public static AudioClip GetBackGroundMusic()
	{
		return GetInstance().backGroundMusic.clip;
	}
	
	public static void SetBackGroundMusic(AudioClip clip)
	{
		if(clip)
		{
			GetInstance().backGroundMusic.clip = clip;
		}
	}
	
	public static void StopBackGroundMusic()
	{
		GetInstance().backGroundMusic.Stop();
	}

	//Use this to create and AudioSource that will only play once
	#region Temporal Audios
	public static AudioSource TemporalAudio(AudioClip clip, Transform t, Vector3 p)
	{
		GameObject audioObject = new GameObject("TemporalAudio");
		audioObject.transform.parent = t;
		audioObject.transform.position = p;
		AudioSource audioSource = audioObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		AutoDestroy autoDestroy = audioObject.AddComponent<AutoDestroy>();
		autoDestroy.totalTimeToDestroy = clip.length;
		autoDestroy.StartCountDown();
		return audioSource;
	}

	public static AudioSource TemporalAudio(AudioClip clip, Transform t)
	{
		return TemporalAudio(clip, t, t.position);
	}

	public static AudioSource TemporalAudio(AudioClip clip, Vector3 p)
	{
		return TemporalAudio(clip, null, p);
	}
    #endregion

    //Use this to create and AudioSource that can play multiple times, but can't play if it's already playing
    #region Unique Audios
    public static AudioSource UniqueAudio(AudioClip clip, Transform t, Vector3 p)
	{
		AudioManager audioManager = GetInstance();
		AudioSource uniqueAudio = null;
		int index = 0;
		while(!uniqueAudio && index < audioManager.uniqueAudios.Count)
		{
			if(audioManager.uniqueAudios[index].clip.name == clip.name)
			{
				uniqueAudio = audioManager.uniqueAudios[index];
			}
			index++;
		}
		if(uniqueAudio)
		{
			if(uniqueAudio.isPlaying)
			{
				return null;
			}
			uniqueAudio.transform.parent = t;
			uniqueAudio.transform.position = p;
			uniqueAudio.Play();
			return uniqueAudio;
		}
		GameObject audioObject = new GameObject("UniqueAudio");
		uniqueAudio = audioObject.AddComponent<AudioSource>();
		uniqueAudio.clip = clip;
		audioObject.transform.parent = t;
		audioObject.transform.position = p;
		uniqueAudio.Play();
		audioManager.uniqueAudios.Add(uniqueAudio);
		return uniqueAudio;
	}

	public static AudioSource UniqueAudio(AudioClip clip, Transform t)
	{
		return UniqueAudio(clip, t, t.position);
	}

	public static AudioSource UniqueAudio(AudioClip clip, Vector3 p)
	{
		return UniqueAudio(clip, null, p);
	}
    #endregion

    public static AudioClip GetAudioClip(string name)
	{
		return Resources.Load<AudioClip>("Audio/" + name);
	}
}