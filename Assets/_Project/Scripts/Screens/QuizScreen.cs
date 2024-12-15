using _Project.Test;
using UnityEngine.UI;
using System;
using System.Linq;
using _Project.Services;
using TMPro;
using UnityEngine;

namespace _Project.Screens
{
    public sealed class QuizScreen : BaseScreen
    {
        [SerializeField] private AnswerButton[] _answerButtons;
        [SerializeField] private TMP_Text _questionCounter;
        [SerializeField] private TMP_Text _questionText;
        
        [SerializeField] private Button _nextButton;
        
        private Answer _currentAnswer;
        private Question[] _questions;
        private Question _currentQuestion;
        
        public void Init(Question[] questions)
        {
            _questions = questions;
            _currentQuestion = questions[0];
            UpdateQuestion(_currentQuestion);
        }

        private void OnEnable()
        {
            AnswerButton.OnAnswered += OnAnswered;
            
            _nextButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_nextButton, AnswerQuestion);
            });
        }

        private void OnAnswered(Answer answer)
        {
            _currentAnswer = answer;
            
            _answerButtons
                .Where(x => x.Answer != _currentAnswer)
                .ToList()
                .ForEach(x => x.Deselect());

            _nextButton.interactable = true;
        }

        private void OnDisable()
        {
            AnswerButton.OnAnswered -= OnAnswered;
            _nextButton.onClick.RemoveAllListeners();
        }

        private void UpdateQuestion(Question question)
        {
            _questionCounter.text = $"Вопрос {Array.IndexOf(_questions, question) + 1}";
            _questionText.text = question.QuestionText;

            for (int i = 0; i < _currentQuestion.Answers.Length; i++)
            {
                _answerButtons[i].Init(_currentQuestion.Answers[i]);
            }
            _nextButton.interactable = false;
        }

        private void AnswerQuestion()
        {
            foreach (var answerButton in _answerButtons)
            {
                answerButton.Deselect();
            }
            
            var nextAnswerIndex = Array.IndexOf(_questions, _currentQuestion) + 1;

            if (nextAnswerIndex < _questions.Length)
            {
                _currentQuestion = _questions[nextAnswerIndex];
                UpdateQuestion(_questions[nextAnswerIndex]);
            
                if (_currentAnswer.Type == AnswerType.Right)
                {
                    GameManager.Instance.AnswerRight();
                }
                else
                {
                    Debug.Log("incorrect answer");
                }
            }
            else
            {
                ScreenStateMachine.Instance.SetScreen(State.End);
            }
        }
    }
}
