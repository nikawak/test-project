using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DailyBonusChecker : MonoBehaviour
{
    [SerializeField] List<BonusItem> Rewards;
    [SerializeField] TextMeshProUGUI TimeToBonusText;

    private int _maxBonusDay => Rewards.Count;
    private TimeSpan _timeToGetNext => TimeSpan.FromSeconds(10);
    private TimeSpan _deadlineClaim => _timeToGetNext * 2;

    public void Start()
    {
        StartCoroutine(TryGetBonus());
    }
    private IEnumerator TryGetBonus()
    {
        while (true)
        {
            var waitTime = DataKeeper.GetLastClaimDate() + _timeToGetNext - DateTime.UtcNow;

            waitTime = waitTime < TimeSpan.Zero ? TimeSpan.Zero : waitTime;

            TimeToBonusText.text = new TimeSpan(waitTime.Hours, waitTime.Minutes, waitTime.Seconds).ToString();
            var canGetBonus = CanGetBonus();
            if (canGetBonus.canGet) Rewards[DataKeeper.GetLastClaimDay()].EnableBonusBG();
            else if (canGetBonus.isDeadline)
            {
                Reset();
            }

            yield return new WaitForSeconds(1);
        }
    }
    private (bool canGet, bool isDeadline) CanGetBonus()
    {
        var deadLine = DataKeeper.GetLastClaimDate() + _deadlineClaim - DateTime.UtcNow;
        deadLine = deadLine < TimeSpan.Zero ? TimeSpan.Zero : deadLine;

        var curDate = DateTime.UtcNow;
        var canGet = curDate > DataKeeper.GetLastClaimDate() + _timeToGetNext
                  && deadLine != TimeSpan.Zero;
        return (canGet, deadLine == TimeSpan.Zero);
    }
    public void GetBonus()
    {
        var canGet = CanGetBonus();

        if (!canGet.canGet && !canGet.isDeadline) return;

        Rewards[DataKeeper.GetLastClaimDay()].AddBonus();
        Rewards[DataKeeper.GetLastClaimDay()].DisableBonusBG();


        BonusCounted();
    }
    private void BonusCounted()
    {
        var newClaimDay = (DataKeeper.GetLastClaimDay() + 1) % _maxBonusDay;
        DataKeeper.SetLastClaimDay(newClaimDay);

        DataKeeper.SetLastClaimDate(DateTime.UtcNow);
    }
    private void Reset()
    {
		Rewards[DataKeeper.GetLastClaimDay()].DisableBonusBG();
		DataKeeper.SetLastClaimDay(0);
		DataKeeper.SetLastClaimDate(DateTime.MinValue);
		Rewards[DataKeeper.GetLastClaimDay()].EnableBonusBG();
	}
}
