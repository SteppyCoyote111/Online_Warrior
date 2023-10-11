using UnityEngine;

namespace Script.UI
{
    public class Barracks : MonoBehaviour
    {
        public GameObject MenuBarracks;

        public void ChangesActiveBarracks(bool stateEnableBaracks)
        {
            MenuBarracks.SetActive(stateEnableBaracks);
        }
    }
}