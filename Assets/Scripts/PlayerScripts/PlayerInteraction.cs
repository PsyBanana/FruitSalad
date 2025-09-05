using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public RoundManager roundManager;
    public GameManager gameManager;
    public BowlManager bowlManager;


    public float interactDistance = 6f; 
    public LayerMask interactLayer;     
     
    public TableInteraction tableInteraction;
    public GameObject bowlSizeFilledText;

    public bool isConnectedToPlayer = true;   // pentru a muta camera la player sau masa.
    public bool activateBowlPanel = false;




    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isConnectedToPlayer)
            {
                TryInteract();
            }
        


            else
            {
                tableInteraction.FocusOnPlayer();
                isConnectedToPlayer = true;
                activateBowlPanel = false;
                GameManager.Instance.UpdateBowlPanel();
            }
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red, 1f);

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {

                Debug.Log("You hit" + hit.collider.name);
                if (hit.collider.CompareTag("Table"))
                {
                    Debug.Log("Interacted with table!");
                    roundManager.StartRound(); // pornește runda

                if (isConnectedToPlayer)
                {
                    tableInteraction.FocusOnTable();
                    isConnectedToPlayer = false;
                    activateBowlPanel = true;
                    Debug.Log("camera Moves to Table");

                    GameManager.Instance.UpdateBowlPanel();
                }

            }

            if (hit.collider.CompareTag("NPC"))
            {
                Debug.Log("interact With Player");
                if(gameManager.playerHasBowl)// verifica daca player are bolul la el "Active"
                {

                    roundManager.attemptsLeft -= 1;
                    roundManager.UpdateQuota();

                    gameManager.playerHasBowl = false;
                    bowlManager.filledSlots = 0;
                    bowlManager.UpdateStats();
                }
                // daca Player are bol,  sterge bolul si adauga scor to Quta.
                //reseteaza  size cupat in bol
                // seteaza bollSelected fasle   Astea ar trebui sa fgie in gameManager

                //daca player nu are boll, nu fa nimic.
            }

        }
    }


}
