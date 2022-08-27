using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Gameplay.Gemelos
{
    public class IniciarCinematicaGemelosTrigger : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Transform pointToSee;
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent.TryGetComponent(out BellsebossFPS bellsebossFPS))
            {
                animator.SetTrigger("triggerEnter");
                bellsebossFPS.CanMove = false;
                var sequence = DOTween.Sequence();
                sequence.Insert(0,
                    bellsebossFPS.GetFatherOfCamera().transform.DOLookAt(pointToSee.position, .5f).SetEase(Ease.OutCirc));
                sequence.onComplete = () => { bellsebossFPS.CanMove = true; }; 
                
            }
        }
    }
}