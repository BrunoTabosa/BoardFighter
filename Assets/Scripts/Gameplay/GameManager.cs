using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterController controllerPrefab;
    public Character[] characterPrefab;
    public BoardManager boardManager;

    CharacterController[] characterControllers;

    public static Action OnMoveComplete; 

    //Tile Select
    public LayerMask layer;

    Camera camera;
    Ray ray;
    RaycastHit hitData;
    GameObject selectedObject;
    //--

    public void Start()
    {
        InitCharacters(1);
        camera = Camera.main;
        OnMoveComplete += OnMoveFinished;
    }

    private void Update()
    {
        HandleInput();
    }

    void InitCharacters(int characters)
    {
        characterControllers = new CharacterController[characters];

        for (int i = 0; i < characters; i++)
        {
            //Setup CharacterInitialPosition

            characterControllers[i] = Instantiate(controllerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            characterControllers[i].Init(characterPrefab[0]);
        }
    }

    void HandleInput()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        
        //Debug.DrawRay(ray.origin, ray.direction * 500, Color.red);

        if (Physics.Raycast(ray, out hitData, 500, layer) && Input.GetMouseButtonDown(0))
        {
            selectedObject = hitData.transform.gameObject;
            //selectedObject.GetComponent<Renderer>().material.color = Color.green;


            var selectedTile = boardManager.GetTileAt((int)selectedObject.transform.position.x, (int)selectedObject.transform.position.z);
            
            characterControllers[0].MoveTo((int)selectedObject.transform.position.x, (int)selectedObject.transform.position.z);
        }
    }

    void OnMoveFinished()
    {
        
    }
}

