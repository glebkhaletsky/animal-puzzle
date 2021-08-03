using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animate : MonoBehaviour
{
    public static Animate Current => _current;
    private static Animate _current;
    public void SetAsCurrent()
    {
        _current = this;
    }

    private void Awake()
    {
        SetAsCurrent();
    }

    public void GoToFieldPosition(Tile tile, Vector2 endPosition)
    {
        tile.gameObject.transform.DOMove(endPosition, 0.75f);
    }

    public void InPlace(Tile tile)
    {
        tile.transform.DOScale(Vector3.one * 1.1f, 0.3f).OnComplete(() => tile.transform.DOScale(Vector3.one, 0.3f));
    }

    public void BalloonUp(GameObject ballon)
    {
        ballon.transform.DOMove(new Vector2(transform.position.x, 8), 4f);
    }

    public void ScaleAnimal(GameObject animal, AudioSource animalVoice)
    {
        animalVoice.Play();
        animal.transform.DOScale(Vector3.one * 1.1f, 0.7f).OnComplete(() => 
        animal.transform.DOShakeRotation(1, 10, 3, 19, true)).OnComplete(() => 
        animal.transform.DOScale(Vector3.one, 0.7f));
    }
}
