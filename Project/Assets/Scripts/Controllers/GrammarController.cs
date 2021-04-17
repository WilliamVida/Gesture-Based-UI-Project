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

    // Declare variables.
    private GrammarRecognizer gr;
    private string spokenPhrase = "";
    public TextMeshProUGUI spokenPhraseText;
    public PauseMenu pauseMenu;
    public PlayerController playerController;
    public GameObject pauseMenuUI;

    // Initialise.
    void Start()
    {
        spokenPhraseText.text = "Spoken Phrase:";
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "GameGrammar.xml"), ConfidenceLevel.Low);
        Debug.Log("Grammar loaded!");
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        if (gr.IsRunning) Debug.Log("Game grammar recogniser is running.");
    }

    void Update()
    {
        if (PauseMenu.gameIsPaused = false && !gr.IsRunning)
        {
            gr.Start();
        }
    }

    // Switch statement for the spoken phrase.
    private void PhraseRecogniser()
    {
        if (!pauseMenuUI.activeInHierarchy)
        {
            GameObject weaponHolder = GameObject.Find("Weapon Holder");
            WeaponSwitching weaponSwitching = weaponHolder.GetComponent<WeaponSwitching>();
            Weapon weapon = weaponHolder.GetComponentInChildren<Weapon>();

            switch (spokenPhrase)
            {
                case "pause":
                case "pause the game":
                    pauseMenu.Pause();
                    break;
                case "weapon one":
                case "main weapon":
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
                    StartCoroutine(weapon.Reload());
                    break;
                case "more ammo":
                case "more ammo power up":
                case "more ammunition":
                case "more ammunition power up":
                case "extra ammo":
                case "extra ammunition":
                case "extra ammo power up":
                case "extra ammunition power up":
                case "get more ammo":
                case "get more ammunition":
                case "get the more ammo power up":
                case "get the more ammunition power up":
                case "get extra ammo":
                case "get extra ammunition":
                case "get the extra ammo power up":
                case "get the extra ammunition power up":
                    IncreasedAmmoPowerUp increasedAmmoPowerUp = FindObjectOfType<IncreasedAmmoPowerUp>();
                    if (increasedAmmoPowerUp != null)
                    {
                        if (increasedAmmoPowerUp.isInCamera)
                        {
                            increasedAmmoPowerUp.transform.position = new Vector2(playerController.transform.position.x, playerController.transform.position.y);
                        }
                    }
                    break;
                case "fire rate":
                case "more fire rate":
                case "fire rate power up":
                case "get the fire rate":
                case "use the fire rate power up":
                case "get the fire rate power up":
                    IncreasedFireRatePowerUp increasedFireRatePowerUp = FindObjectOfType<IncreasedFireRatePowerUp>();
                    if (increasedFireRatePowerUp != null)
                    {
                        if (increasedFireRatePowerUp.isInCamera)
                        {
                            increasedFireRatePowerUp.transform.position = new Vector2(playerController.transform.position.x, playerController.transform.position.y);
                        }
                    }
                    break;
                case "more speed":
                case "more speed power up":
                case "get more speed":
                case "use the more speed power up":
                case "get the more speed power up":
                    IncreasedSpeedPowerUp increasedSpeedPowerUp = FindObjectOfType<IncreasedSpeedPowerUp>();
                    if (increasedSpeedPowerUp != null)
                    {
                        if (increasedSpeedPowerUp.isInCamera)
                        {
                            increasedSpeedPowerUp.transform.position = new Vector2(playerController.transform.position.x, playerController.transform.position.y);
                        }
                    }
                    break;
            }
        }
    }

    // When a phrase is recognised.
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
