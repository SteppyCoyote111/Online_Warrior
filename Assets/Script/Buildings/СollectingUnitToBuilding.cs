using System;
using TMPro;
using UnityEngine;
using static CastleData;

namespace Script.Buildings
{
    public class СollectingUnitToBuilding : MonoBehaviour 
    {
        public TextMeshProUGUI AllNoEquippedTroopsUnit;
        public TextMeshProUGUI AllEquippedTroopsUnit;
        public TMP_InputField CountAssemblingArmyUnit;
        public int PriceCollectiingUnitOneLevel;
        
        public void СollectingUnit()
        {
            var validate = CheckToValidateEquippedUnit();
            if (validate.isCollectUnit)
            {
                Gold -= validate.CountCollectUnit * PriceCollectiingUnitOneLevel;
                UnitEquippedOneLevel += validate.CountCollectUnit;
                UnitOneLevel -= validate.CountCollectUnit;
                ShowCollectUnit();
            }
        }

        public void ShowCollectUnit()
        {
            AllNoEquippedTroopsUnit.text = CastleData.UnitOneLevel.ToString();
            AllEquippedTroopsUnit.text = CastleData.UnitEquippedOneLevel.ToString();
        }

        private (bool isCollectUnit, int CountCollectUnit) CheckToValidateEquippedUnit()
        {
            bool isCollectUnit = false;
            int countCollectUnit = 0;
            try
            {
                countCollectUnit = int.Parse(CountAssemblingArmyUnit.text);
                if (countCollectUnit > UnitOneLevel)
                {
                    CountAssemblingArmyUnit.text = UnitOneLevel.ToString();
                    countCollectUnit = 0;
                }
                else if(countCollectUnit * PriceCollectiingUnitOneLevel > Gold)
                {
                    CountAssemblingArmyUnit.text =  (Gold / PriceCollectiingUnitOneLevel).ToString();
                    countCollectUnit = 0; 
                }
                else
                    isCollectUnit = true;
            }
            catch (Exception e)
            {
                isCollectUnit = false;
                countCollectUnit = 0;
                Console.WriteLine(e);
            }
            return (isCollectUnit, countCollectUnit);
        }
        
        
        public void Open()
        {
            ShowCollectUnit();
        }

        public void Close()
        {
            
        }
    }
}