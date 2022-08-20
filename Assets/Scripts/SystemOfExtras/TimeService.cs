using System;
using PlayFab.ClientModels;
using PlayFab.Internal;
using UnityEngine;

namespace SystemOfExtras
{
    public class TimeService : MonoBehaviour, ITimeService
    {
        [SerializeField] private float timeVelocity;
        [SerializeField] private int horaAnochecer, minutoAnochecer, horaInicio, minutoInicio;
        private Tiempo _currentTime;

        private void Awake()
        {
            _currentTime = new Tiempo(horaAnochecer, minutoAnochecer, horaInicio, minutoInicio);
        }

        private void Update()
        {
            _currentTime.AddTime(Time.deltaTime * timeVelocity);
        }

        public void Anochecio()
        {
            Debug.Log("anochecio");
        }

        public string GetTime()
        {
            return _currentTime.GetTime();
        }
    }
}