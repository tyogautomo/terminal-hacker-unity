using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scripts;

public class Hacker : MonoBehaviour {

    int currentLevel;
    ScreenEnum currentScreen = ScreenEnum.MainMenu;
    string currentWord;
    Leveling stage;

    void Start() {
        ShowMainMenu("Yoga");
    }

    void ShowMainMenu(string name) {
        currentScreen = ScreenEnum.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine($"Hello {name}");
        Terminal.WriteLine("What would you like to decode into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1: Wanderer world");
        Terminal.WriteLine("Press 2: Alchemist's beaker");
        Terminal.WriteLine("Press 3: Black Witch crystal ball");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type your selection:");
    }

    void OnUserInput(string input) {
        int parsed;
        bool canInverted = Int32.TryParse(input, out parsed);
        if (input == "menu") {
            ShowMainMenu("Yoga");
        } else if (currentScreen == ScreenEnum.MainMenu) {
            SelectLevel(canInverted, parsed);
        } else if (currentScreen == ScreenEnum.Decoder) {
            checkWord(input);
        }

    }

    void SelectLevel(bool canInverted, int parsed) {
        if (canInverted && (parsed > 0 && parsed < 4)) {
            currentLevel = parsed;
            ShowGameScreen(currentLevel);
        } else {
            Terminal.WriteLine("Wrong input!");
        }
    }

    void ShowGameScreen(int level) {
        currentScreen = ScreenEnum.Decoder;
        Terminal.ClearScreen();
        Leveling currentLevel = new Leveling(level);
        currentLevel.DetermineLevelName(level);
        stage = currentLevel;
        currentWord = currentLevel.words[0];

        Terminal.WriteLine($"Welcome to level {stage.level} ({stage.name})");
        Terminal.WriteLine("Enter your password :");
    }

    void checkWord(string input) {
        if (input == currentWord) {
            Terminal.WriteLine("Bener cong!");
        } else {
            Terminal.WriteLine("Salah awkawk!");
        }
    }
}
