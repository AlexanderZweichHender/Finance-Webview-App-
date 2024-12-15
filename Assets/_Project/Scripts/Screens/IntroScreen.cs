using _Project.Services;
using _Project.Test;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Screens
{
    public sealed class IntroScreen : BaseScreen
    {
        [SerializeField] private Image _quizIcon;
        [SerializeField] private TMP_Text _time;
        [SerializeField] private TMP_Text _questionsCount;
        [SerializeField] private TMP_Text _description;

        [SerializeField] private Button _startButton;

        private QuizCategory _category;
        
        public void Init(QuizCategory category)
        {
            _category = category;

            _quizIcon.sprite = _category.Icon;
            _time.text = $"{_category.QuizTime} мин";
            _questionsCount.text = $"{_category.Questions.Length} вопросов";
            
            _description.text = category.Description;
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_startButton, StartQuiz);
            });
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveAllListeners();
        }

        private void StartQuiz()
        {
            ScreenStateMachine.Instance.SetScreen(State.Question);
        }
    }    
}

