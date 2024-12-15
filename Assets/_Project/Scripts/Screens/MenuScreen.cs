using UnityEngine.UI;
using _Project.Test;
using UnityEngine;
using System;
using _Project.Services;
using DG.Tweening;

namespace _Project.Screens
{
    public class MenuScreen : BaseScreen
    {
        [SerializeField] private ChooseOption[] _options;

        private void OnEnable()
        {
            foreach (var option in _options)
            {
                option.ChooseButton.onClick.AddListener(() =>
                {
                    ButtonOnClicked(option.ChooseButton, ChooseCategory(option.Category));
                });
            }
        }

        private void OnDisable()
        {
            foreach (var option in _options)
            {
                option.ChooseButton.onClick.RemoveAllListeners();
            }
        }

        private TweenCallback ChooseCategory(CategoryType type)
        {
            ScreenStateMachine.Instance.SetScreen(State.Intro);
            GameManager.Instance.SetCategory(type);
            return null;
        }
    }

    [Serializable]
    public struct ChooseOption
    {
        [field: SerializeField] public Button ChooseButton { get; set; }
        [field: SerializeField] public CategoryType Category { get; set; }
    }
}
