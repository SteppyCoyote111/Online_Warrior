using System;
using System.Collections;
using UnityEngine;

namespace Script.Timers
{
    public class ControllerTimers : MonoBehaviour, IControllerTimers
    {
        public static IControllerTimers S_Instance;
        
        private void Awake()
        {
            if (S_Instance == null)
                S_Instance = this;
            else
                Destroy(gameObject);
        }

        public void StartCoroutineInParentObj(IEnumerator cor)
        {
            StartCoroutine(cor);
        }

        public void StopCoroutines(IEnumerator cor)
        {
            StopCoroutine(cor);   
        }
    }
}