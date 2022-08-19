using System;
using PlayFab.ClientModels;
using UnityEngine;

namespace SystemOfExtras
{
    public class TimeService : MonoBehaviour, ITimeService
    {
        [SerializeField] private float timeVelocity;
        [SerializeField] private int horaAnochecer, minutoAnochecer;
        private Tiempo _currentTime;

        private void Awake()
        {
            _currentTime = new Tiempo(horaAnochecer, minutoAnochecer);
        }

        private void Update()
        {
            _currentTime.AddTime(Time.deltaTime * timeVelocity);
            Debug.Log(_currentTime.GetTime());
        }

        public void Anochecio()
        {
            throw new NotImplementedException();
        }
    }
}