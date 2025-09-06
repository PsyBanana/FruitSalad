using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BowlSelection : MonoBehaviour
{
    public GameObject smallBowlPrefab;
    public GameObject mediumBowlPrefab;
    public GameObject largeBowlPrefab;

    public GameManager gameManager;
    public BowlManager bowlManager;
    public CameraMove cameraMove;
    public FoodManager foodManager;
    public RoundManager roundManager;
    public TableInteraction tableInteraction;

    public Transform bowlSpawnPoint;
    


    private void SpawnBowl(GameObject bowlPrefab)
    {
        Instantiate(bowlPrefab, bowlSpawnPoint.position, bowlSpawnPoint.rotation);
        gameManager.playerHasBowl = true;    // lasam playerul sa interactioneze cu NPC
        bowlManager.bowlUI.SetActive(true);
        //foodManager.SpawnFoods(3, roundManager.activePerksThisRound);
        
    }

    public void SelectSmallBowl()
    {
       
            gameManager.PlayerCoins += 3;
            bowlManager.maxSlots = 3;
            SpawnBowl(smallBowlPrefab);
        gameManager.FoodHasSpawned();   
        gameManager.playerInteraction.activateBowlPanel = false; // setezi valoarea
        gameManager.UpdateBowlPanel();
        bowlManager.UpdateStats();


    }

    public void SelectMediumBowl()
    {
 
            gameManager.PlayerCoins += 1;
            bowlManager.maxSlots = 5;
            SpawnBowl(mediumBowlPrefab);
        gameManager.FoodHasSpawned();
        gameManager.playerInteraction.activateBowlPanel = false; // setezi valoarea
        gameManager.UpdateBowlPanel();
        bowlManager.UpdateStats();

    }

    public void SelectLargeBowl()
    {
        if (gameManager.PlayerCoins >= 1)
        {
            gameManager.PlayerCoins -= 1;
            bowlManager.maxSlots = 7;    
            SpawnBowl(largeBowlPrefab);   // genereaza bol
            gameManager.FoodHasSpawned(); // genereaza mancare si se asigura ca nu apre de mai multe ori.
            gameManager.playerInteraction.activateBowlPanel = false; // setezi valoarea
            gameManager.UpdateBowlPanel(); // Afiseaza/Dezafiseaza meniul de selectare a bolului
            bowlManager.UpdateStats(); // UI modify
        }
        else
        {
            Debug.Log("Not Enough Coins");
            // display a message on the screen;
        }

    }

    public void BowlReady()
    {
        tableInteraction.FocusOnPlayer();// move back to player POV.

        bowlManager.bowlUI.SetActive(false);//Disable UI regarding bowl 
        foodManager.ClearFoods();//Destroy fruits

        //desactivate Player interaction with the table.
        gameManager.foodHasSpawned = false; // ne asiguram ca putem spawna mancarea again.
    }
}
