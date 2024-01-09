using System;
using DG.Tweening;
using PlayFab.ClientModels;
using PlayFab.Internal;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SystemOfExtras
{
    public class TimeService : MonoBehaviour, ITimeService
    {
        [SerializeField] private float timeVelocity, fadeDuration;
        [SerializeField] private int horaAnochecer, minutoAnochecer, horaInicio, minutoInicio;
        [SerializeField] private BellsebossFPS firstPersonController;
        [SerializeField] private Image fadeImage;
        [SerializeField] private Transform mallGatewayTransform;
        [SerializeField] private Dialog dialogForSayTheCCIsClose;
        private Tiempo _currentTime;
        private bool _contarElTiempo;

        private void Awake()
        {
            _currentTime = new Tiempo(horaAnochecer, minutoAnochecer, horaInicio, minutoInicio);
        }

        private void Update()
        {
            if (!_contarElTiempo) return;
            _currentTime.AddTime(Time.deltaTime * timeVelocity);
        }

        public void Anochecio()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(dialogForSayTheCCIsClose.Id);
            ServiceLocator.Instance.GetService<IDialogSystem>().OnDialogAction( isDialog =>
            {
                
            });
            ServiceLocator.Instance.GetService<IDialogSystem>().OnDialogFinish(idDialog =>
            {
                SitUntilNight();
            });
        }

        public string GetTime()
        {
            return _currentTime.GetTime();
        }

        public void SitUntilNight()
        {
            ServiceLocator.Instance.GetService<ILoadScream>().Close((() =>
            {
                SceneManager.LoadScene(4);
            }));
        }

        public bool IsNigth()
        {
            return _currentTime.IsNight;
        }

        public void AddMinutes(int minutos)
        {
            _currentTime.AddTime(minutos*60);
        }

        public void StartToCountTime()
        {
            _contarElTiempo = true;
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