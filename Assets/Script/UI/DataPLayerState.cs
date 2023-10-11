    using TMPro;
    using UnityEngine;

    public class DataPLayerState : MonoBehaviour
    {
        public TextMeshProUGUI EatText;
        public TextMeshProUGUI WoodText;
        public TextMeshProUGUI GoldText;

        public void FixedUpdate()
        {
            EatText.text = "Еда: " +  CastleData.Eat.ToString();
            WoodText.text = "Дерево: " + CastleData.Wood.ToString();
            GoldText.text = "Золото: " +CastleData.Gold.ToString();
        }
    }
