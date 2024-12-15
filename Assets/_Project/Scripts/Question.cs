using System;
using System.Linq;
using UnityEngine;

namespace _Project.Test
{
    [Serializable]
    public sealed class Question
    {
        [field: SerializeField, TextArea(4, 3)] public string QuestionText { get; private set; }
        [field: SerializeField] public Answer[] Answers { get; private set; } = new Answer[5];
        
        public Answer RightAnswer => Answers.FirstOrDefault(x => x.Type == AnswerType.Right);
    }
}

