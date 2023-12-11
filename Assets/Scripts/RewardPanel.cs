using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardPanel : MonoBehaviour
{
    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private TextMeshProUGUI _tiketsText;

    private int _reward;
    public void Open(int reward)
    {
        gameObject.SetActive(true);
        _levelPanel.SetActive(false);

        _tiketsText.text = reward.ToString();
        _reward = reward;
    }
    public void Close()
    {
        gameObject.SetActive(false);
        _levelPanel.SetActive(true);
    }
    public void AddReward()
    {
        var tikets = DataKeeper.GetTikets();
        DataKeeper.SetTikets(tikets + _reward);
        Close();
    }
}
