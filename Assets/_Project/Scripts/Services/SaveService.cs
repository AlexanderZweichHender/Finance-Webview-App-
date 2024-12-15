using UnityEngine;

namespace _Project.Services
{
    public sealed class SaveService 
    {
        public static bool Sound
        {
            get
            {
                if (!PlayerPrefs.HasKey(Constants.SOUND_KEY))
                {
                    PlayerPrefs.SetInt(Constants.SOUND_KEY, 1);
                    PlayerPrefs.Save();

                    return true;
                }
                else
                {
                    return PlayerPrefs.GetInt(Constants.SOUND_KEY) == 1 ? true : false;
                }
            }

            set
            {
                if (value)
                    PlayerPrefs.SetInt(Constants.SOUND_KEY, 1);
                else
                    PlayerPrefs.SetInt(Constants.SOUND_KEY, 0);

                PlayerPrefs.Save();
            }
        }

        public static int Score
        {
            get
            {
                if (!PlayerPrefs.HasKey(Constants.SCORE_KEY))
                {
                    PlayerPrefs.SetInt(Constants.SCORE_KEY, 0);
                    PlayerPrefs.Save();

                    return 0;
                }
                else
                {
                    return PlayerPrefs.GetInt(Constants.SCORE_KEY);
                }
            }

            set
            {
                PlayerPrefs.SetInt(Constants.SCORE_KEY, value);
                PlayerPrefs.Save();
            }
        }

        public static int Level
        {
            get
            {
                if (!PlayerPrefs.HasKey(Constants.LEVEL_KEY))
                {
                    PlayerPrefs.SetInt(Constants.LEVEL_KEY, 0);
                    PlayerPrefs.Save();

                    return 0;
                }
                else
                {
                    return PlayerPrefs.GetInt(Constants.LEVEL_KEY);
                }
            }

            set
            {
                PlayerPrefs.SetInt(Constants.LEVEL_KEY, value);
                PlayerPrefs.Save();
            }
        }

    }

    public struct Constants
    {
        public const string SOUND_KEY = "Sound";
        public const string SCORE_KEY = "Score";
        public const string LEVEL_KEY = "Level";

        public const int TARGET_FRAME_RATE = 60;
    }
}
