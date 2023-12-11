using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Levelitem : MonoBehaviour
{
    [SerializeField] private RewardPanel _rewardPanel;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private int _levelNumber;
    [SerializeField] private int _rewardMultipier = 20;

    private int _tiketsReward;
    
    private void Start()
    {
        _tiketsReward = _levelNumber * _rewardMultipier;
        _levelText.text = _levelNumber.ToString();
    }
    public void AddReward()
    {
        DataKeeper.SetLevel(_levelNumber);
        _rewardPanel.Open(_tiketsReward);
    }
}
