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

    void Update()
    {

    }

    private void PhraseRecogniser()
    {
        GameObject weaponHolder = GameObject.Find("Weapon Holder");
        WeaponSwitching weaponSwitching = weaponHolder.GetComponent<WeaponSwitching>();
        Weapon weapon = weaponHolder.GetComponentInChildren<Weapon>();

        switch (spokenPhrase)
        {
            case "pause":
            case "pause the game":
                break;
            case "jump":
                break;
            case "weapon one":
            case "main weapon":
            case "fireball":
            case "primary weapon":
            case "assault rifle":
            case "rifle":
                weaponSwitching.selectedWeapon = 0;
                // To avoid an issue.
                weapon.canFire = true;
                weaponSwitching.SelectWeapon();
                break;
            case "weapon two":
            case "secondary weapon":
            case "purple pearl":
            case "pistol":
                weaponSwitching.selectedWeapon = 1;
                // To avoid an issue.
                weapon.canFire = true;
                weaponSwitching.SelectWeapon();
                break;
            case "reload":
            case "reload now":
            case "reload the weapon":
            case "reload the gun":
                Debug.Log("reload voice");
                StartCoroutine(weapon.Reload());
                break;
            // case "power up":
            //     Debug.Log("power up voice");
            //     break;
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
            spokenPhraseText.text = "Spoken Phrase: " + valueString;
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
