using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [Header("Dependencies")]
    public DialogueUI dialogueUI;

    [Header("Action events")]
    public UnityEvent onConversationStarted;
    public UnityEvent onConversationEnded;

    private Queue<Sentence> sentences;

    void Start()
    {
        sentences = new Queue<Sentence>();
    }

    public void StartConversation(ConversationSO conversation)
    {
        if (sentences.Count != 0)
        {
            return;
        }

        foreach (var sentence in conversation.sentences)
        {
            sentences.Enqueue(sentence);
        }

        dialogueUI.StartConversation(
            leftCharacterName: conversation.leftCharacter.fullname,
            leftCharacterPortrait: conversation.leftCharacter.portrait,
            rightCharacterName: conversation.rightCharacter.fullname,
            rightCharacterPortrait: conversation.rightCharacter.portrait
            );

        if (onConversationStarted != null)
        {
            onConversationStarted.Invoke();
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if (dialogueUI.IsSentenceInProcess())
        {
            dialogueUI.FinishDisplayingSentence();
            return;
        }

        if (sentences.Count == 0)
        {
            EndConversation();
            return;
        }

        Sentence sentence = sentences.Dequeue();

        dialogueUI.DisplaySentence(
            characterName: sentence.character.fullname,
            sentenceText: sentence.text
            );
    }

    public void EndConversation()
    {
        dialogueUI.EndConversation();
        if (onConversationEnded != null)
        {
            onConversationEnded.Invoke();
        }
    }
}
