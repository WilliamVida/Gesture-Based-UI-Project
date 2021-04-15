using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;

public class GrammarController : MonoBehaviour
{

    private GrammarRecognizer gr;
    private string spokenPhrase = "";
    public TextMeshProUGUI spokenPhraseText;

    void Start()
    {
        spokenPhraseText.text = "Spoken Phrase:";
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "GameGrammar.xml"), ConfidenceLevel.Low);
        Debug.Log("Grammar loaded!");
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        if (gr.IsRunning) Debug.Log("Recogniser running.");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PhraseRecogniser()
    {
        Weapon weapon = gameObject.GetComponent<Weapon>();

        switch (spokenPhrase)
        {
            case "jump":
                Debug.Log("switch jump");
                break;
        }
    }

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
            spokenPhraseText.text = "Spoken word(s): " + valueString;
            spokenPhrase = valueString;
        }

        Debug.Log(message);
        PhraseRecogniser();
    }

    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Stop();
        }
    }

}
