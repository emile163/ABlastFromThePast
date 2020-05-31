using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour
{
	public AudioMixer audiomixer;

	public GameObject KeyBinding;
	public GameObject settings;

	private bool ShowingKeyBinding = false; 

	public void SetVolume (float volume)
	{
		audiomixer.SetFloat("volume", volume);
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void SetFullScreen(bool isFullScreen)
	{
		Screen.fullScreen = isFullScreen;
	}

	public void SowKeyBindingMenu()
	{
		KeyBinding.SetActive(true);
		settings.SetActive(false);
		ShowingKeyBinding = true;
	}
	public void SowKeyBindingMenuPrinci()
	{
		KeyBinding.SetActive(true);
		settings.SetActive(false);
		ShowingKeyBinding = true;
	}

	public void HideKeyBindingMenu()
	{
		KeyBinding.SetActive(false);
		settings.SetActive(true);
		ShowingKeyBinding = false;
	}

	public void HideSetting()
	{
		settings.SetActive(false);
		if (GameManager.instance.isPaused)
		{
			Resume();
		}
	}

	public void ShowSetting()
	{
		if (ShowingKeyBinding == false)
		{
			if (settings.activeSelf == false)
				settings.SetActive(true);
			else
			{
				settings.SetActive(false);
			}

			if (GameManager.instance.isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	private void Resume()
	{
		Time.timeScale = 1.0f;
		GameManager.instance.isPaused = false;
	}

	private void Pause()
	{
		Time.timeScale = 0.0f;
		GameManager.instance.isPaused = true;
	}
}
