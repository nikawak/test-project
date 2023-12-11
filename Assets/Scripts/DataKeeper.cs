using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeeper : MonoBehaviour
{
	public static void SetTikets(int value) => PlayerPrefs.SetInt("tikets", value);
	public static void SetIsPurchased(string itemName) => PlayerPrefs.SetInt("Is" + itemName + "Purchased", 1);
	public static void SetIsUnlocked(string itemName) => PlayerPrefs.SetInt("Is" + itemName + "Unlocked", 1);
	public static void SetLevel(int levelNum) => PlayerPrefs.SetInt("level" + levelNum, 1);
	public static void SetLastClaimDay(int value) => PlayerPrefs.SetInt("lastDay", value);
	public static void SetLastClaimDate(DateTime value) => PlayerPrefs.SetString("lastDate", value.ToString());
	public static void SetMusicEnabled(bool value) => PlayerPrefs.SetInt("musicEnabled", Convert.ToInt32(value));
	public static void SetSoundEnabled(bool value) => PlayerPrefs.SetInt("soundEnabled", Convert.ToInt32(value));

	public static int GetTikets() => PlayerPrefs.GetInt("tikets");
	public static bool GetIsPurchased(string itemName) => PlayerPrefs.GetInt("Is" + itemName + "Purchased") != 0;
	public static bool GetIsUnlocked(string itemName) => PlayerPrefs.GetInt("Is" + itemName + "Unlocked") != 0;
	public static bool GetLevel(int levelNum) => PlayerPrefs.GetInt("level" + levelNum) == 1;
    public static int GetLastClaimDay() => PlayerPrefs.GetInt("lastDay");
	public static DateTime GetLastClaimDate() =>
		string.IsNullOrEmpty(PlayerPrefs.GetString("lastDate"))
			? DateTime.MinValue: Convert.ToDateTime(PlayerPrefs.GetString("lastDate"));
	public static bool GetMusicEnabled() => PlayerPrefs.GetInt("musicEnabled") == 1;
	public static bool GetSoundEnabled() => PlayerPrefs.GetInt("soundEnabled") == 1;
}
