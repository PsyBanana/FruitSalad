using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInteraction : MonoBehaviour
{

    public Transform tableViewPoint;
    public Transform playerViewPoint;
    public Camera mainCamera;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FocusOnTable()
    {
        StartCoroutine(MoveCamera(mainCamera.transform.position, tableViewPoint.position, tableViewPoint.rotation, 0.8f));
        

        gameManager.SetPlayerControl(false);
    }

    public void FocusOnPlayer()
    {
        StartCoroutine(MoveCamera(mainCamera.transform.position, playerViewPoint.position, playerViewPoint.rotation, 0.8f));
        

        gameManager.SetPlayerControl(true);
    }


    private IEnumerator MoveCamera(Vector3 startPos, Vector3 endPos, Quaternion endRot, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            mainCamera.transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, endRot, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = endPos;
        mainCamera.transform.rotation = endRot;
    }

}
