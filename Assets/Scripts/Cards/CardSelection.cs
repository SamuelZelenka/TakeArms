using System.Collections;
using TakeArms.Utility;
using UnityEngine;

namespace TakeArms.Gameplay
{
    public class CardSelection : MonoBehaviour
    {
        public Vector3 startHandle;
        public Vector3 endHandle;

        private AnimationCurve _positionCurve;
        private AnimationCurve _scaleCurve;

        [SerializeField]
        private float _animationTime;

        private float _startTime;
        private Quaternion _startRotation;

        private bool _isInspecting;
        private bool _isAnimating;
        private GameObject _selectedCard;

        public GameObject SelectedCard => _selectedCard;

        private void Update()
        {
            if (_selectedCard == null)
                return;

            if (Input.GetMouseButtonUp(1) && !_isAnimating)
            {
                StartCoroutine("AnimateOut", _startRotation);
            }
        }

        public void InspectCard(GameObject card)
        {
            if (_isAnimating || _selectedCard == card)
                return;
            if (_selectedCard != null)
                StartCoroutine("AnimateOut", _startRotation);

            StartCoroutine("AnimateIn", card);
        }

        private IEnumerator AnimateIn(GameObject card)
        {
            var t = 0f;
            _startTime = Time.time;
            _startRotation = card.transform.rotation;
            _selectedCard = card;
            _isInspecting = true;
            _isAnimating = true;

            while (t < 1)
            {
                t = GetAnimationTime(_startTime);
                _selectedCard.transform.position = Trajectories.GetBezierPos(_selectedCard.transform.parent.position, transform.position, startHandle, endHandle, t);
                _selectedCard.transform.rotation = Quaternion.Lerp(_startRotation, Quaternion.Euler(0, 0, 0), t);
                _selectedCard.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 1.5f, t);

                yield return null;
            }
            _isAnimating = false;
        }

        private IEnumerator AnimateOut(Quaternion toRotation)
        {
            var t = 0f;
            var card = _selectedCard;
            _startTime = Time.time;
            _isInspecting = false;
            _isAnimating = true;


            while (t < 1)
            {
                t = GetAnimationTime(_startTime);
                card.transform.position = Trajectories.GetBezierPos(transform.position, card.transform.parent.position, endHandle, startHandle, t);
                card.transform.rotation = Quaternion.Lerp(card.transform.rotation, toRotation, t);
                card.transform.localScale = Vector3.Lerp(Vector3.one * 1.5f, Vector3.one, t);
                yield return null;
            }

            if (_selectedCard == card)
                _selectedCard = null;

            _isInspecting = false;
            _isAnimating = false;
        }

        private float GetAnimationTime(float startTime)
        {
            var endTimeStamp = startTime + _animationTime;

            return Mathf.Clamp01((Time.time - startTime) / (endTimeStamp - startTime));
        }
    }
}
