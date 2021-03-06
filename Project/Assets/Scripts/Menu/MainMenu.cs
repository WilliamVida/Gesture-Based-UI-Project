using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;
using TMPro;

// From https://www.youtube.com/watch?v=zc8ac_qUXQY&ab_channel=Brackeys.
public class MainMenu : MonoBehaviour
{

    // Declare variables.
    private GrammarRecognizer gr;
    private string spokenPhrase = "";
    public TextMeshProUGUI spokenPhraseText;
    public GameObject mainMenuUI;
    public GameObject instructionsMenuUI;
    public GameObject backMenuUI;

    // Initialise.
    void Start()
    {
        spokenPhraseText.text = "Spoken Phrase:";
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "MainMenuGrammar.xml"), ConfidenceLevel.Low);
        Debug.Log("Grammar loaded!");
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        if (gr.IsRunning) Debug.Log("Main menu grammar recogniser is running.");
    }

    // Check if a phrase is recognised.
    private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder message = new StringBuilder();
        Debug.Log("Recognised a phrase.");
        SemanticMeaning[] meanings = args.semanticMeanings;

        // Use foreach to get all the meanings.
        foreach (SemanticMeaning meaning in meanings)
        {
            string valueString = meaning.values[0].Trim();
            message.Append("Value: " + valueString + " ");
            spokenPhrase = valueString;
        }

        Debug.Log(message);
        spokenPhraseText.text = "Spoken Phrase: " + spokenPhrase;
        PhraseRecogniser();
    }

    // Switch statement for the spoken phrase.
    private void PhraseRecogniser()
    {
        switch (spokenPhrase)
        {
            case "start":
            case "start a game":
            case "start the game":
            case "click the start button":
            case "play":
            case "play a game":
            case "play the game":
            case "click play":
            case "click the play button":
                PlayGame();
                break;
            case "instructions":
            case "go to instructions":
            case "go to the instructions menu":
            case "click the instructions button":
                InstructionsButton();
                break;
            case "back":
            case "go back":
            case "back to the main menu":
            case "click the back button":
                BackButton();
                break;
            case "quit":
            case "quit the game":
            case "click the quit button":
            case "click quit":
                QuitButton();
                break;
        }
    }

    // When the application quits.
    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Stop();
        }
    }

    // Method to play the game.
    public void PlayGame()
    {
        gr.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Method to enter the instructions menu.
    public void InstructionsButton()
    {
        mainMenuUI.SetActive(false);
        instructionsMenuUI.SetActive(true);
    }

    // Method to go back to the main menu from the instructions menu.
    public void BackButton()
    {
        mainMenuUI.SetActive(true);
        instructionsMenuUI.SetActive(false);
    }

    // Method to quit the game.
    public void QuitButton()
    {
        Debug.Log("Quitting the game.");
        Application.Quit();
    }

}
