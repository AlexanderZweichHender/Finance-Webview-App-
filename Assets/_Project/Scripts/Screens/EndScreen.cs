using System;
using System.ComponentModel;
using _Project.Screens;
using _Project.Test;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Scripts.Screens
{
    public sealed class EndScreen : BaseScreen
    {
        [SerializeField] private TMP_Text _questionCount;
        [SerializeField] private TMP_Text _timeCount;

        [SerializeField] private Button _menuButton;

        private void Start()
        {
            StopAllCoroutines();

            _questionCount.text =
                $"Верные ответы: {GameManager.Instance.RightQuestionCount}/{GameManager.Instance.CurrentCategory.Questions.Length}";
            var time = TimeSpan.FromSeconds(GameManager.Instance.Time).ToString(@"mm\:ss");
            _timeCount.text = $"Ваше время: {time}";
        }

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_menuButton, Restart);
            });
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveAllListeners();
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
