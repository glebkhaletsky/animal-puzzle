using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEffect : MonoBehaviour
{   
    [SerializeField] private List<GameObject> balloons = new List<GameObject>();
    [SerializeField] private int numberBallons;    

    private void OnEnable()
    {
        StartCoroutine(CreateBalloons());
    }
    IEnumerator CreateBalloons()
    {
        if (numberBallons >= 0)
        {
            yield return new WaitForSeconds(1f);
            int randomIndex = Random.Range(0, balloons.Count);
            GameObject balloon = Instantiate(balloons[randomIndex], new Vector2(Random.Range(-6, 6), -5), Quaternion.identity);
            Animate.Current.BalloonUp(balloon);
            StartCoroutine(CreateBalloons());
        }
        else
        {
            StopCoroutine(CreateBalloons());
            Level.Current.GameOver();
        }
        numberBallons--;
    }
}
