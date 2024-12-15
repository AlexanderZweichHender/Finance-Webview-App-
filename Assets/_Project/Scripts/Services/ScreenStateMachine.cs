using System.Collections.Generic;
using _Project.Screens;
using UnityEngine;
using System.Linq;
using System;

namespace _Project.Services
{
    public sealed class ScreenStateMachine : Singleton<ScreenStateMachine>
    {
        [SerializeField] private ScreenState[] _screens;
        [SerializeField] private State _currentScreen;

        private Dictionary<State, BaseScreen> _dictionary;

        protected override void Awake()
        {
            base.Awake();

            _dictionary = _screens.ToDictionary(
                screen => screen.State,
                screen => screen.Screen
            );             
        }

        public void SetScreen(State state)
        {
            if (_dictionary.ContainsKey(state))
            {
                _dictionary[state].gameObject.SetActive(true);
                _dictionary[_currentScreen].gameObject.SetActive(false);

                _currentScreen = state;
            }
        }
    }

    [Serializable]
    public struct ScreenState
    {
        [field: SerializeField] public BaseScreen Screen { get; private set; }
        [field: SerializeField] public State State { get; private set; }
    }

    public enum State
    {
       Start,
       Menu,
       Intro,
       Question,
       End
    }
}
