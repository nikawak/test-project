using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewSwitcher : MonoBehaviour
{
	[SerializeField] private GameObject _settingsView;
	[SerializeField] private GameObject _giftsView;
	[SerializeField] private GameObject _menuView;
    public void SwitchToMainScene()
    {
        SceneManager.LoadScene("Menu");
    }
	public void SwitchToShopScene()
	{
		SceneManager.LoadScene("Shop");
	}
	public void SwitchToLevelsScene()
	{
		SceneManager.LoadScene("Levels");
	}
    public void SwitchToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SwitchToSettings()
	{
		_settingsView.SetActive(true);
        _menuView.SetActive(false);
	}
	public void SwitchToGifts()
	{
		_giftsView.SetActive(true);
        _menuView.SetActive(false);
	}
	public void SwitchToMenu()
	{
		_giftsView.SetActive(false);
		_settingsView.SetActive(false);
        _menuView.SetActive(true);
    }
}
