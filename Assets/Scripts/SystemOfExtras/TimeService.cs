using System;
using DG.Tweening;
using PlayFab.ClientModels;
using PlayFab.Internal;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

namespace SystemOfExtras
{
    public class TimeService : MonoBehaviour, ITimeService
    {
        [SerializeField] private float timeVelocity, fadeDuration;
        [SerializeField] private int horaAnochecer, minutoAnochecer, horaInicio, minutoInicio;
        [SerializeField] private FirstPersonController firstPersonController;
        [SerializeField] private Image fadeImage;
        [SerializeField] private Transform mallGatewayTransform;
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

        public void SitUntilNight()
        {
            firstPersonController.enabled = false;
            var sequence = DOTween.Sequence();
            sequence.Insert(0, fadeImage.DOFade(1, fadeDuration));
            sequence.onComplete = ONComplete;
        }

        public bool IsNigth()
        {
            return _currentTime.IsNight;
        }

        private void ONComplete()
        {
            firstPersonController.gameObject.transform.position = mallGatewayTransform.position;
            firstPersonController.transform.rotation = mallGatewayTransform.rotation;
            _currentTime.GoNight();
            var sequence = DOTween.Sequence();
            sequence.Insert(0, fadeImage.DOFade(0, fadeDuration));
            sequence.onComplete = () => { firstPersonController.enabled = true; };
        }
    }
}