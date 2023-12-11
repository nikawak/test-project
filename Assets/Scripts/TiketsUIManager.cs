using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TiketsUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tiketsText;

	private int _tikets => DataKeeper.GetTikets();
	public void Update()
	{
		_tiketsText.text = _tikets.ToString();
	}
}
