using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private Text levelText;

    public void ShowText()
    {
        levelText.text = "Демо версия, только слон";
    }
}
