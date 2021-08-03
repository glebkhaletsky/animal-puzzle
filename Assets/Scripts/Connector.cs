using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    [SerializeField] private Connector _defaulConnector;
    public Connector DefaultConnector => _defaulConnector;

    public void SetDefaultConnector(Connector connector)
    {
        _defaulConnector = connector;
    }

    public bool CheckDefaulConnector()
    {
        float distance = Vector2.Distance(transform.position, _defaulConnector.transform.position);
        if (distance <= 0.2f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
