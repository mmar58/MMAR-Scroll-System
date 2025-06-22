using UnityEngine;
using UnityEngine.Events;

namespace MMAR.ScrollSystem
{
    public class Tween : MonoBehaviour
    {
        

        public float duration = 1f;
        public TweenType tweenType = TweenType.Linear;

        public Vector3 startPosition;
        public Vector3 targetPosition;
        private float elapsedTime = 0f;
        private bool isTweening = false;
        [Header("Events")]
        public UnityEvent<Vector3> OnTweenUpdate;
        public UnityEvent OnTweenComplete;

        void Update()
        {
            if (isTweening)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp(elapsedTime / duration, 0f, 1f);

                float progress = GetTweenValue(t);
                OnTweenUpdate.Invoke(Vector3.Lerp(startPosition, targetPosition, progress));
                
                if (elapsedTime >= duration)
                {
                    OnTweenComplete.Invoke();
                    isTweening = false;
                }
            }
        }

        public bool IsTweening()
        {
            return isTweening;
        }

        public void JumpToPosition(Vector3 startPosition,Vector3 targetPos, float duration = 0.5f, TweenType easeType = TweenType.Linear)
        {
            if (!isTweening) // Only start a new tween if not already in progress
            {
                this.startPosition = startPosition;
                this.duration = duration;
                this.tweenType = easeType;
                this.targetPosition = targetPos;
                elapsedTime = 0f;
                isTweening = true;
            }
        }

        private float GetTweenValue(float t)
        {
            switch (tweenType)
            {
                case TweenType.EaseIn:
                    return Mathf.Pow(t, 3);
                case TweenType.EaseOut:
                    return 1f - Mathf.Pow(1f - t, 3);
                case TweenType.EaseInOut:
                    return t < 0.5f ? 4f * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 3) / 2f;
                case TweenType.BounceIn:
                    return BounceEaseIn(t);
                case TweenType.BounceOut:
                    return BounceEaseOut(t);
                case TweenType.BounceInOut:
                    return t < 0.5f ? 0.5f * BounceEaseIn(2f * t) : 0.5f * BounceEaseOut(2f * t - 1f) + 0.5f;
                case TweenType.ElasticIn:
                    return t == 0f ? 0f : t == 1f ? 1f : -Mathf.Pow(2f, 10f * t - 10f) * Mathf.Sin((t * 10f - 10.75f) * (2f * Mathf.PI) / 3f);
                case TweenType.ElasticOut:
                    return t == 0f ? 0f : t == 1f ? 1f : Mathf.Pow(2f, -10f * t) * Mathf.Sin((t * 10f - 0.75f) * (2f * Mathf.PI) / 3f) + 1f;
                case TweenType.ElasticInOut:
                    return t == 0f ? 0f
                        : t == 1f ? 1f
                        : t < 0.5f
                            ? -(Mathf.Pow(2f, 20f * t - 10f) * Mathf.Sin((20f * t - 11.125f) * (2f * Mathf.PI) / 4.5f)) / 2f
                            : (Mathf.Pow(2f, -20f * t + 10f) * Mathf.Sin((20f * t - 11.125f) * (2f * Mathf.PI) / 4.5f)) / 2f + 1f;
                default:
                    return t; // Linear
            }
        }

        private float BounceEaseIn(float t)
        {
            return 1f - BounceEaseOut(1f - t);
        }

        private float BounceEaseOut(float t)
        {
            if (t < (1 / 2.75f))
            {
                return 7.5625f * t * t;
            }
            else if (t < (2 / 2.75f))
            {
                t -= 1.5f / 2.75f;
                return 7.5625f * t * t + 0.75f;
            }
            else if (t < (2.5 / 2.75))
            {
                t -= 2.25f / 2.75f;
                return 7.5625f * t * t + 0.9375f;
            }
            else
            {
                t -= 2.625f / 2.75f;
                return 7.5625f * t * t + 0.984375f;
            }
        }
    }
    public enum TweenType { Linear, EaseIn, EaseOut, EaseInOut, BounceIn, BounceOut, BounceInOut, ElasticIn, ElasticOut, ElasticInOut }
}