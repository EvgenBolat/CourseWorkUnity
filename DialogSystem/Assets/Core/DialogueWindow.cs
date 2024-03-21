using UnityEngine;
using System.Collections;
using TMPro;
using System;

namespace Dialogue {
	public class DialogWindow : MonoBehaviour
	{
		private TMP_Text _text;
        [SerializeField]
		private DialogueStory _dialogueStory;

        private void Awake()
        {
            TryGetComponent(out _text);

            if (_dialogueStory != null)
            {
                _dialogueStory.ChangedStory += ChangeAnswers;
            }
            else
            {
                Debug.Log("не указан DialogueStory");
            }
        }

        private void ChangeAnswers(DialogueStory.Story story)
        {
            if (_text != null)
            {
                _text.text = story.Text;
            }
            else
            {
                Debug.Log("невозможно получить компонент TMP_Text");
            }
        }
    }
}

