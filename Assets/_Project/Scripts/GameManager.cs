using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Project.Screens;
using _Project.Services;
using UnityEngine;

namespace _Project.Test
{
    public sealed class GameManager : Singleton<GameManager>
    {
        [SerializeField] private QuizCategory[] _categories;
        [SerializeField] private IntroScreen _introScreen;
        [SerializeField] private  QuizScreen _quizScreen;
        
        public QuizCategory CurrentCategory { get; private set; }
        public int Time { get; private set; }
        public int RightQuestionCount { get; private set; }

        public void SetCategory(CategoryType category)
        {
            CurrentCategory = _categories.FirstOrDefault(x => x.Category == category);
            _introScreen.Init(CurrentCategory);
            _quizScreen.Init(CurrentCategory.Questions);
            StartCoroutine(CountTime());
        }

        public void AnswerRight()
        {
            RightQuestionCount++;
            Debug.Log($"</color=green>Score: {RightQuestionCount}</color>");
        }

        private IEnumerator CountTime()
        {
            for (;;)
            {
                Time++;
                yield return new WaitForSeconds(1f);
            }
        }
    }    
}

