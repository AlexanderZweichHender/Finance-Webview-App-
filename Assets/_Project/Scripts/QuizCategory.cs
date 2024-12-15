using UnityEngine;

namespace _Project.Test
{
    [CreateAssetMenu(fileName = "QuizCategory", menuName = "ScriptableObjects/QuizCategory", order = 1)]
    public sealed class QuizCategory : ScriptableObject
    {
        [field: SerializeField] public CategoryType Category { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField, TextArea(16, 9)] public string Description { get; private set; }
        [field: SerializeField] public int QuizTime { get; private set; } = 15;
        
        [field: Space(50)]
        [Header("Questions:")]
        [field: SerializeField] public Question[] Questions { get; private set; }
    }

    public enum CategoryType
    {
        Financial,
        RealEstate,
        FinTech
    }
}