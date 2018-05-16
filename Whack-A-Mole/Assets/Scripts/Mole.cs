using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mole : MonoBehaviour
{
    public MoleVisuals visuals;

    public UnityAction<Mole, bool> OnMoleDied;

    [HideInInspector]
    public MoleData data;
    private bool _alive = false;
    private GameObject _gameObject;

    private void Awake()
    {
        _gameObject = gameObject;
    }

    public void Respawn(Vector2 pos, MoleData d)
    {
        data = d;

        _gameObject.GetComponent<RectTransform>().localPosition = pos;
        _gameObject.SetActive(true);
        StartCoroutine("Timer");

        visuals.Respawn(data);
    }

    public void Despawn()
    {
        if (_gameObject.activeSelf == false)
            return;

        //OnMoleDied(this, true);
        _gameObject.SetActive(false);
    }

    public void MoleClicked()
    {
        StopCoroutine("Timer");
        OnMoleDied(this, true);
        Despawn();
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(data.timeOnScreen);
        OnMoleDied(this, false);
        Despawn();
    }
}
