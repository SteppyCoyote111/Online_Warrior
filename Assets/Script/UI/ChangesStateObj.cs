using UnityEngine;
using UnityEngine.Events;

namespace Script.UI
{
    public class ChangesStateObj : MonoBehaviour
    {
        public GameObject Menu;
        public UnityEvent EventInvokeInOpenObj;

        public void ChangesActiveObj(bool stateEnable)
        {
            Menu.SetActive(stateEnable);
            if (stateEnable)
                EventInvokeInOpenObj?.Invoke();
        }
    }
}