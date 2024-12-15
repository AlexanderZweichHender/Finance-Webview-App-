using UnityEngine;
using DG.Tweening;

namespace _Project.Services
{
    public sealed class AnimationService : Singleton<AnimationService>
    {
        [SerializeField] private Vector2 _size = new Vector2(0.9f, 0.9f);
        [SerializeField, Range(0, 10)] private float _duration = 0.2f;

        public void PlayAnimation(GameObject @object, TweenCallback callback)
        {
            if (!DOTween.IsTweening(@object))
            {
                var startSize = @object.transform.localScale;

                DOTween.Sequence()
                    .SetId(@object)
                    .Append(@object.transform.DOScale(startSize * _size, _duration))
                    .Append(@object.transform.DOScale(startSize, _duration))
                    .AppendCallback(callback);
            }
        }
    }
}
