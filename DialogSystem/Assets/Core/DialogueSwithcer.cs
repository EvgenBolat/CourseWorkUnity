using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dialogue {
	public class DialogueSwitcher : MonoBehaviour
	{
        [SerializeField] private string[] _disableTags;

        [SerializeField]
		private DialogueStory _dialogueStory;
        private void Start()
        {
            if (_dialogueStory != null)
            {
                _dialogueStory.ChangedStory += Disable;
            }
            else
            {
                Debug.Log(name + ": не добавлен DialogueStory");
            }
        }

        private async void Disable(DialogueStory.Story story)
        {
            if (_disableTags.All(disableTag => story.Tag != disableTag)) return;
            await Task.Delay(1000);
            _dialogueStory.gameObject.SetActive(false);
        }
    }
}

