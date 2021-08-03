using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public static Level Current => _current;
    private static Level _current;
    public void SetAsCurrent()
    {
        _current = this;
    }

    [SerializeField] private new Camera camera;
    [SerializeField] private float delayStart = 1;
    [SerializeField] private Connector connectorPrefab;
    [SerializeField] private GameObject mask;
    [SerializeField] private List<Transform> fieldPoint = new List<Transform>();
    [SerializeField] private List<Tile> allTiles = new List<Tile>();
    [SerializeField] private List<Tile> removeTiles = new List<Tile>();
    [SerializeField] private AudioSource animalVoice;
    [SerializeField] private GameObject ui;
    [SerializeField] private UnityEvent winEffect;    
    private Tile currentTile = null;
    bool startGame;
    private void Awake()
    {
        SetAsCurrent();
    }

    private void Start()
    {
        Invoke(nameof(SetFieldPosition), delayStart);
    }
    public void CreateConnector(Tile tile)
    {
        allTiles.Add(tile);
        Connector tileConnector =  Instantiate(connectorPrefab, tile.transform.position, Quaternion.identity, tile.transform);
        Connector maskConnector = Instantiate(connectorPrefab, tile.transform.position, Quaternion.identity, transform);
        tileConnector.SetDefaultConnector(maskConnector);        
    }
    private void SetFieldPosition()
    {
        startGame = true;
        for (int i = 0; i < allTiles.Count; i++)
        {
            int randomPointIndex = Random.Range(0, fieldPoint.Count);
            allTiles[i].SetAnchorPosition(fieldPoint[randomPointIndex].position);
            fieldPoint.RemoveAt(randomPointIndex);
        }
    }
    public void SetCurrentTile(Tile tile)
    {
        currentTile = tile;
    }

    public void NotUse(Tile tile)
    {
        if (startGame)
        {
            allTiles.Remove(tile);
            removeTiles.Add(tile);
            CheckGame();
        }
        
    }

    private void CheckGame()
    {
        if (allTiles.Count <= 0)
        {
            winEffect.Invoke();
            Debug.Log("WIN");
        }
    }
    public void GameOver()
    {
        mask.SetActive(true);
        for (int i = 0; i < removeTiles.Count; i++)
        {
            removeTiles[i].DisableTile();
        }
        Animate.Current.ScaleAnimal(mask, animalVoice);
        ui.SetActive(true);
        
    }

    private void Update()
    {
        if (startGame)
        {
            if (currentTile != null && allTiles.Count > 0)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 5f);
                Vector3 point = ray.GetPoint(1f);
                currentTile.SetPosition(point);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (allTiles.Contains(currentTile))
                {
                    currentTile.BackToAnchor();
                }
                currentTile = null;

            }
        }
        else
        {
            return;
        }
        
    }   
    
}
