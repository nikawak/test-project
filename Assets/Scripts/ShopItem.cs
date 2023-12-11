using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _priceText;
	[SerializeField] private TextMeshProUGUI _minLevelText;

	[SerializeField] private GameObject _blockUI;
	[SerializeField] private GameObject _successUI;

	[SerializeField] private string _itemName;
	[SerializeField] private int _realMoneyPrice = 0;
	[SerializeField] private int _price;
	[SerializeField] private int _minLevel;

	[SerializeField] private bool _isPurchased;
	[SerializeField] private bool _isUnlocked;
	[SerializeField] private int _tickets;
	public void Awake()
	{
		DataKeeper.SetLevel(1);
		_priceText.text = _price.ToString();
		_minLevelText.text = _minLevel == 0 ? "" : "Level: " + _minLevel.ToString();
		if(_minLevel == 0 || DataKeeper.GetLevel(_minLevel)) DataKeeper.SetIsUnlocked(_itemName);
		

		AccessUpdate();
	}
	public void BuyItem()
	{
		if(_realMoneyPrice == 0)
		{
			if (_tickets < _price || _isPurchased || !_isUnlocked) return;
			_tickets -= _price;

		}
		else
		{
			_tickets += _price;
		}

		DataKeeper.SetTikets(_tickets);
		DataKeeper.SetIsPurchased(_itemName);

		AccessUpdate();
	}
	public void BuyByRealMoney()
	{
		DataKeeper.SetIsPurchased(_itemName);

		AccessUpdate();
	}
	public void UnlockUI()
	{
		_blockUI.SetActive(false);
	}
	public void BuyUI()
	{
		_successUI.SetActive(true);
	}
	private void AccessUpdate()
	{
		_isPurchased = DataKeeper.GetIsPurchased(_itemName);
		_isUnlocked = DataKeeper.GetIsUnlocked(_itemName);
		_tickets = DataKeeper.GetTikets();

		if (_isUnlocked) { UnlockUI(); }
		if (_isPurchased) { BuyUI(); }
	}
}
