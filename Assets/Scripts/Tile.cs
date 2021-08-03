using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Vector2 anchorPoint;
    private Connector connector;
    bool movable = true;
    private void Start()
    {
        Level.Current.CreateConnector(this);
        connector = GetComponentInChildren<Connector>();
    }
    private void OnMouseDown()
    {
        Level.Current.SetCurrentTile(this);
    }
    public void SetAnchorPosition(Vector3 point)
    {
        anchorPoint = point;
        BackToAnchor();
        //transform.position = anchorPoint;
    } 

    public void SetPosition(Vector2 position)
    {
        if (!connector.CheckDefaulConnector())
        {
            transform.position = position;
        }
        else
        {
            transform.position = connector.DefaultConnector.transform.position;
            Animate.Current.InPlace(this);
            Level.Current.NotUse(this);
            movable = false;
        }

    }
    public void BackToAnchor()
    {
        if (movable)
        {
            Animate.Current.GoToFieldPosition(this, anchorPoint);            
        }            
    }

    public void DisableTile()
    {
        gameObject.SetActive(false);
    }


}
