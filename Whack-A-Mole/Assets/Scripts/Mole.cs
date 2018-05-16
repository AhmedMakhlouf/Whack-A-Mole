using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mole : MonoBehaviour
{

    public MoleData data;

    public UnityAction<Mole> OnMoleDied;

    private bool _alive = false;
    private GameObject _gameObject;

    private void Awake()
    {
        _gameObject = gameObject;
    }

    public void Respawn()
    {
        _gameObject.SetActive(true);
        StartCoroutine("Timer");
    }

    public void Despawn()
    {
        if (_gameObject.activeSelf == false)
            return;

        OnMoleDied(this);
        _gameObject.SetActive(false);
    }

    public void MoleClicked()
    {
        StopCoroutine("Timer");
        Despawn();
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(data.timeOnScreen);
        Despawn();
    }
}
