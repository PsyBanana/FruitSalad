using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 6f; 
    public LayerMask interactLayer;     
    public RoundManager roundManager;   
    public TableInteraction tableInteraction;

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
            
        }
    }


}
