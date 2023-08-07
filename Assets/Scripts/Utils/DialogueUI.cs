using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("Configuration")]
    public float textSpeed;

    [Header("Dependencies")]
    public GameObject ui;

    public GameObject leftCharacter;
    public GameObject rightCharacter;

    public TextMeshProUGUI leftCharacterName;
    public Image leftCharacterPortrait;

    public TextMeshProUGUI rightCharacterName;
    public Image rightCharacterPortrait;

    public TextMeshProUGUI dialogueBox;

    private string currentSentence;

    public void StartConversation(
        string leftCharacterName,
        Sprite leftCharacterPortrait,
        string rightCharacterName,
        Sprite rightCharacterPortrait)
    {
        // Resetting the UI
        CleanUI();

        // Setting portraits and names
        this.leftCharacterName.text = leftCharacterName;
        this.leftCharacterPortrait.sprite = leftCharacterPortrait;
        this.rightCharacterName.text = rightCharacterName;
        this.rightCharacterPortrait.sprite = rightCharacterPortrait;

        dialogueBox.text = "";

        // Hiding Actors
        ToggleLeftCharacter(false);
        ToggleRightCharacter(false);
    }

    public void DisplaySentence(string characterName, string sentenceText)
    {
        if (characterName == leftCharacterName.text)
        {
            ToggleLeftCharacter(true);
            ToggleRightCharacter(false);
        }
        else
        {
            ToggleLeftCharacter(false);
            ToggleRightCharacter(true);
        }

        currentSentence = sentenceText;
        StartCoroutine(TypeCurrentSentence());
    }

    public void EndConversation()
    {
        CleanUI();
    }

    public bool IsSentenceInProcess()
    {
        return currentSentence != null;
    }

    public void FinishDisplayingSentence()
    {
        StopAllCoroutines();
        dialogueBox.text = currentSentence;
        currentSentence = null;
    }

    private IEnumerator TypeCurrentSentence()
    {
        dialogueBox.text = "";
        foreach (char letter in currentSentence.ToCharArray())
        {
            dialogueBox.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        dialogueBox.text = currentSentence;
        currentSentence = null;
    }

    private void CleanUI()
    {
        leftCharacterName.text = "";
        leftCharacterPortrait.sprite = null;
        rightCharacterName.text = "";
        rightCharacterPortrait.sprite = null;
        dialogueBox.text = "";
    }

    private void ToggleLeftCharacter(bool status)
    {
        leftCharacter.SetActive(status);
    }

    private void ToggleRightCharacter(bool status)
    {
        rightCharacter.SetActive(status);
    }

}
