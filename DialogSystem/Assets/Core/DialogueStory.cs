using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dialogue
{
    public class DialogueStory : MonoBehaviour
    {
        public event Action<Story> ChangedStory;

        [SerializeField] private Story[] _stories;

        private Dictionary<string, Story> _storyDictionary;


        [Serializable]
        public struct Answer
        {
            [field: SerializeField] public string Text { get; private set; }
            [field: SerializeField] public string ResponseText { get; private set; }
        }

        [Serializable]
        public struct Story
        {
            [field: SerializeField] public string Tag { get; private set; }
            [field: SerializeField] public string Text { get; private set; }
            [field: SerializeField] public Answer[] Answers { get; private set; }
        }

        public void ChangeStory(string tag)
        {
            ChangedStory?.Invoke(_storyDictionary[tag]);
        }

        private void Start()
        {
            _storyDictionary = _stories.ToDictionary(key => key.Tag, element => element);
            ChangeStory(_stories[0].Tag);
        }

    }

}
