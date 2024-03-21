using UnityEngine;
using System.Collections;
using TMPro;
using System;
using UnityEngine.UI;

namespace Dialogue {
    public class AnswerButtons : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;
        private TMP_Text[] _buttonsText;
        private string[] _currentReplyTags;
        private DialogueStory _dialogueStory;

        private void Awake()
        {
            TryGetComponent(out _dialogueStory);
            if (_dialogueStory != null)
            {
                _dialogueStory.ChangedStory += ChangeAnswers;
                _buttonsText = new TMP_Text[_buttons.Length];
                _currentReplyTags = new string[_buttons.Length];

                for (int i = 0; i < _buttons.Length; i++)
                {
                    if (_buttons[i] != null)
                    {
                        int button = i;
                        _buttons[i].onClick.AddListener(() => SendAnswer(button));
                        _buttonsText[i] = _buttons[i].gameObject.GetComponentInChildren<TMP_Text>();
                    }
                    else
                    {
                        Debug.Log(name + ": количество кнопок не соотносится с количеством добавленных");
                    }
                }
            }
            else
            {
                Debug.Log(name + ": не найден dialogueStory");
            }
        }

        private void SendAnswer(int button)
        {
            if (_dialogueStory != null)
            {
                _dialogueStory.ChangeStory(_currentReplyTags[button]);
            }
            else
            {
                Debug.Log( name + ": не найден dialogueStory");
            }
        }

        private void ChangeAnswers(DialogueStory.Story story)
        {
            for (int i = 0; i < _buttonsText.Length; i++)
            {
                if (_buttons[i] != null)
                {
                    if (story.Answers.Length <= i)
                    {
                        _buttonsText[i].text = null;
                        _buttons[i].interactable = false;
                        continue;
                    }

                    _buttonsText[i].text = story.Answers[i].Text;
                    _currentReplyTags[i] = story.Answers[i].ResponseText;
                    _buttons[i].interactable = true;
                }
                else
                {
                    Debug.Log(name + ": количество кнопок не соотносится с количеством добавленных");
                }
            }
        }
    }
}
