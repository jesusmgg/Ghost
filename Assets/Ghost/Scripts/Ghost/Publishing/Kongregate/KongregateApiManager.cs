using UnityEngine;

namespace Ghost.Publishing.Kongregate
{
    public class KongregateApiManager : MonoBehaviour
    {
        KongregateApi kongregateApi;

        void Awake()
        {
            kongregateApi = KongregateApi.Create();
        }

        public void SubmitStats(string statName, int value)
        {
            kongregateApi.SubmitStats(statName, value);
        }
    }
}