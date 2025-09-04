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

    public Transform bowlSpawnPoint;


    private void SpawnBowl(GameObject bowlPrefab)
    {
        Instantiate(bowlPrefab, bowlSpawnPoint.position, bowlSpawnPoint.rotation);
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
}
