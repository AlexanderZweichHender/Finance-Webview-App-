using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace _Project.Services
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class AudioService : Singleton<AudioService>
    {
        [SerializeField] private AudioClip[] _sounds;

        private AudioSource _source;
        private Dictionary<string, AudioClip> _dictionary;

        protected override void Awake()
        {
            base.Awake();
            _source = GetComponent<AudioSource>();

            _dictionary = _sounds.ToDictionary(
                sound => sound.name,
                sound => sound
            );
        }

        public void PlaySound(string sound)
        {
            if (_dictionary.ContainsKey(sound))
            {
                if (SaveService.Sound)
                    _source.PlayOneShot(_dictionary[sound]);
            }
            else
            {
                Debug.Log($"</color>{sound} not found</color>");
            }
        }
    }
}
