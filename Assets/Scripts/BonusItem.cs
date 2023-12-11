using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusItem : MonoBehaviour
{
    [SerializeField] private Image _bonusBG;
    [SerializeField] private int _bonusValue;

    public void AddBonus()
    {
        var curTikets = DataKeeper.GetTikets();
        DataKeeper.SetTikets(curTikets + _bonusValue);
    }
    public void EnableBonusBG()
    {
        _bonusBG.gameObject.SetActive(true);
    }
    public void DisableBonusBG()
    {
        _bonusBG.gameObject.SetActive(false);
    }
}
