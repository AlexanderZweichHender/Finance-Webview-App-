using System;
using UnityEngine;

namespace _Project.Test
{
    [Serializable]
    public sealed class Answer
    {
        [field: SerializeField] public string AnswerText { get; private set; }
        [field: SerializeField] public AnswerType Type { get; private set; }
    }

    public enum AnswerType
    {
        Wrong,
        Right
    }
}