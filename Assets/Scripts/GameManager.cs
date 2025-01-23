using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public Button[] buttons;
    //public TMP_Text[] buttonTexts;
    public Image[] buttonImages; // Array to hold image components
    public Sprite xSprite; // Assign X sprite in the Inspector
    public Sprite oSprite; // Assign O sprite in the Inspector
    private string currentPlayer;
    private int moveCount;

    //Game end container
    public GameObject gameEndContainer;
    public Button restartButton, exitButton;
    public TMP_Text winnerText;

    // player name
    public InputField player1InputField; // Assign Player 1 Input Field in the Inspector
    public InputField player2InputField; // Assign Player 2 Input Field in the Inspector
    public Text player1NameText; // Assign Player 1 Name Text in the Inspector
    public Text player2NameText; // Assign Player 2 Name Text in the Inspector

    void Start()
    {

        currentPlayer = "X";
        moveCount = 0;
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => ButtonClicked(button));
        }
    }

    void UpdatePlayerNames()
    {
        player1NameText.text = player1InputField.text;
        player2NameText.text = player2InputField.text;
    }

    void ButtonClicked(Button button)
    {
        int index = System.Array.IndexOf(buttons, button);
        if (buttonImages[index].sprite == null)
        {
            buttonImages[index].sprite = (currentPlayer == "X") ? xSprite : oSprite;
            moveCount++;
            if (CheckWin())
            {
                string winnerName = currentPlayer == "X" ? player1InputField.text : player2InputField.text;
                Debug.Log(winnerName + " Wins!");
                //ResetGame();
                gameEndContainer.SetActive(true);
                winnerText.text = winnerName + " Wins!";
            }
            else if (moveCount >= 9)
            {
                Debug.Log("It's a Draw!");
                //ResetGame();
                gameEndContainer.SetActive(true);
                winnerText.text = "It's a Draw!";
            }
            else
            {
                currentPlayer = (currentPlayer == "X") ? "O" : "X";
            }
        }
    }

    bool CheckWin()
    {
        // Check rows, columns and diagonals for a win
        return (CheckCombination(0, 1, 2) || CheckCombination(3, 4, 5) || CheckCombination(6, 7, 8) ||
                   CheckCombination(0, 3, 6) || CheckCombination(1, 4, 7) || CheckCombination(2, 5, 8) ||
                   CheckCombination(0, 4, 8) || CheckCombination(2, 4, 6));
    }

    bool CheckCombination(int a, int b, int c)
    {
        return buttonImages[a].sprite == buttonImages[b].sprite &&
              buttonImages[a].sprite == buttonImages[c].sprite &&
              buttonImages[a].sprite != null; // Ensure it's not null
    }

    public void RestartGame()
    {
        foreach (Image img in buttonImages)
        {
            img.sprite = null; // Clear the sprite
        }
        //gameEndContainer.SetActive(false);
        currentPlayer = "X";
        moveCount = 0;
        
    }

   public void disableEndGameContainer()
    {
        gameEndContainer.SetActive(false);
    }

    // Call this method when the input fields are changed
    public void OnInputFieldChanged()
    {
        UpdatePlayerNames();
    }

    //void QuitGame()
    // {
    //     Application.Quit();
    // }
}
