using System.Collections;

namespace Script.Timers
{
    public interface IControllerTimers
    {
        void StartCoroutineInParentObj(IEnumerator cor);
        void StopCoroutines(IEnumerator cor);
    }
}