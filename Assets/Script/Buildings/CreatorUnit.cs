using System;
using Script;
using TMPro;
using UnityEngine;

//Пока доступна только одна очередь
public class CreatorUnit : MonoBehaviour
{
    public int TimeSecondsCreateOneUnit;
    public int PriceOneUnitEat, PriceOneUnitWood;

    public int QueueForOneBuilding = 1;
    //UI
    public TMP_InputField InputCurrentLearnUnitInput;
    public int CountDefaultCreateUnit = 100;
    public DataTraning[] QueueCreate;
    public GameObject Barracks;
    public GameObject PrewiewCreateUI;
    public GameObject InProgresCreateUI;
    public bool IsPreviewCreateUI;
    public TextMeshProUGUI CurrentCreateUnitText;
    public TextMeshProUGUI CurrentTimeCreateUnitText;

    private void FixedUpdate()
    {
        if (QueueCreate != null && QueueCreate.Length != 0 &&  QueueCreate[0] != null)
        {
            int endTime =  Convert.ToInt32((QueueCreate[0].EndTimeLearnUnit - DateTime.Now).TotalSeconds);

            if (endTime <= 0)
            {
                QueueCreate[0].EndTimeSeconds = 0;
                EndLearn(QueueCreate[0]);
                IsPreviewCreateUI = true;
                InProgresCreateUI.SetActive(!IsPreviewCreateUI);
            }
            else
            {
                QueueCreate[0].EndTimeSeconds = endTime;
                IsPreviewCreateUI = false;
                CurrentCreateUnitText.text = QueueCreate[0].CountCreateUnit.ToString();
                CurrentTimeCreateUnitText.text = QueueCreate[0].EndTimeSeconds.ToString();
            }
        }
        else
        {
            IsPreviewCreateUI = true;
        }
    }

    private void EndLearn(DataTraning endQueue)
    {
        CastleData.UnitOneLevel += endQueue.CountCreateUnit;
        QueueCreate[0] = null;
    }

    public void OpenBuilding()
    {
        PrewiewCreateUI.SetActive(IsPreviewCreateUI);
        InProgresCreateUI.SetActive(!IsPreviewCreateUI);
        Barracks.gameObject.SetActive(true);
    }

    public void CloseBuilding() =>
        Barracks.gameObject.SetActive(false);

    public void EntryLearnUnit()
    {
        int countCreateUnit;
        try
        {
            countCreateUnit = int.Parse(InputCurrentLearnUnitInput.text);
        }
        catch (Exception e)
        {
            countCreateUnit = CountDefaultCreateUnit;
        }
      
        var countResEat = PriceOneUnitEat * countCreateUnit;
        var countResWood = PriceOneUnitWood * countCreateUnit;

        bool isResultEat =  CastleData.CheckValidationRes(TypeResource.Eat, countResEat);
        bool isResultWood =  CastleData.CheckValidationRes(TypeResource.Wood, countResWood);

        if (isResultEat && isResultWood)
            CreateTimerUnit(countCreateUnit);
        else
        {
Debug.Log("Не хватает рессурсов для начала производства юнитов.");
        }
    }

    public void CreateTimerUnit(int countCreateUnit)
    {
        var countResEat = PriceOneUnitEat * countCreateUnit;
        var countResWood = PriceOneUnitWood * countCreateUnit;
        var countTime = TimeSecondsCreateOneUnit * countCreateUnit;
        CastleData.RemoveResource(TypeResource.Eat, countResEat);
        CastleData.RemoveResource(TypeResource.Wood, countResWood);

        QueueCreate = new DataTraning[1];
         QueueCreate[0] = new DataTraning()
            { EndTimeLearnUnit = DateTime.Now.AddSeconds(countTime), CountCreateUnit = countCreateUnit };

         OpenBuilding();
    }
    
    public void CLoseQueueUnit()
    {
        
    }
}
