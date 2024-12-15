using _Project.Services;
using UnityEngine.UI;
using UnityEngine;

namespace _Project.Screens
{
    public sealed class StartScreen : BaseScreen
    {
        [SerializeField] private Button _startButton;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_startButton, OpenMenu);
            });
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveAllListeners();
        }

        private void OpenMenu()
        {
            ScreenStateMachine.Instance.SetScreen(State.Menu);
        }
    }    
}

