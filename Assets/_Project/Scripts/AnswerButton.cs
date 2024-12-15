using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Test
{
    [RequireComponent(typeof(Button))]
    public sealed class AnswerButton : MonoBehaviour
    { 
        public static Action<Answer> OnAnswered;
        
        [SerializeField] private Image _checkmark;
        [SerializeField] private Sprite _selected, _unselected;

        [SerializeField] private TMP_Text _answerText;
        
        public bool IsSelected => _checkmark.sprite == _selected;
        public Answer Answer { get; private set; }
        private Button _button;

        public void Init(Answer answer)
        {
            Answer = answer;
            _answerText.text = Answer.AnswerText;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(() =>
            {
                Select();
                OnAnswered?.Invoke(Answer);
            });
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();   
        }

        public void Select()
        {
            _checkmark.sprite = _selected;
        }

        public void Deselect()
        {
            _checkmark.sprite = _unselected;
        }

       private void Awake()
       {
           _button = GetComponent<Button>();
       }
    }
}
