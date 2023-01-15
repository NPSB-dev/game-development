using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class ClickDrink : MonoBehaviour
{
    public DrinkCombinations drinkCombinations;
    public static List<string> currentIngredients = new List<string>();
    public string currentDrinkName;

    public TextMeshProUGUI winText;
    [SerializeField] GameObject winTextObject;
    [SerializeField] GameObject loseTextObject;

    private string nameOfDrink;
    public static bool drinkClicked = false;
    void Start()
    {
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        drinkClicked = false;
        drinkCombinations = GetComponent<DrinkCombinations>();
    }

    void Update()
    {
        if (drinkClicked)
        {
            SceneTransition();
        }
    }

    public void AddToMix()
    {
        if (drinkClicked) { return; }
        currentDrinkName = gameObject.name;
        //Debug.Log(currentDrinkName);
        currentIngredients.Add(currentDrinkName);
    }

    public void CheckDrink()
    {
        if (drinkClicked) { return; }
        drinkClicked = true;
        nameOfDrink = drinkCombinations.CheckIfGoodCombination(currentIngredients);
        if (drinkCombinations.CheckIfGoodCombination(currentIngredients).Length > 0)
        {
            // foreach(var currentIngredient in currentIngredients)
            //     Debug.Log(currentIngredient);
            Win();
        }
        else
        {
             foreach (var currentIngredient in currentIngredients)
                 Debug.Log(currentIngredient);
            Lose();
        }
        currentIngredients.Clear();
    }

    void Win()
    {
        winText.text = nameOfDrink + "\n+15";
        winTextObject.SetActive(true);
        if (Globals.drunkenness <= 85)
            Globals.drunkenness += 15;
        else
            Globals.drunkenness = 100;
        StartCoroutine(ExampleCoroutine());
    }

    void Lose()
    {
        loseTextObject.SetActive(true);
        if (Globals.drunkenness >= 15)
            Globals.drunkenness -= 15;
        else
            Globals.drunkenness = 0;
        StartCoroutine(ExampleCoroutine());
    }

    public void SceneTransition()
    {
        SceneManager.LoadScene("SampleScene");
    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);

    }
}
