using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Mole[] moles;
    public float spawnTimer;

    public Score score;
    public Timer timer;

    private int _currentMolesOnScreen;
    private int _score;
    private List<Mole> _disabledMoles = new List<Mole>();
    private WaitForSeconds _wait;

    private void Awake()
    {
        foreach(Mole m in moles)
        {
            m.OnMoleDied += MoleDied;
        }

        timer.OnTimeOut += GameOver;
        _wait = new WaitForSeconds(spawnTimer);
    }

    private void Start()
    {
        NewGame();
    }

    private void MoleDied(Mole mole)
    {
        _disabledMoles.Add(mole);
        _currentMolesOnScreen--;

        SpawnImmediate();
    }

    private void NewGame()
    {
        foreach (Mole m in moles)
        {
            m.Despawn();
            _disabledMoles.Add(m);
        }

        _currentMolesOnScreen = 0;
        StartCoroutine("SpawnMoles");
        timer.Restart();
    }

    private void GameOver()
    {

    }

    IEnumerator SpawnMoles()
    {
        while(true)
        {
            if(_currentMolesOnScreen < 7 && _disabledMoles.Count > 0)
            {
                _disabledMoles[0].Respawn();
                _disabledMoles.RemoveAt(0);
                _currentMolesOnScreen++;
            }

            yield return _wait;
        }
    }

    private void SpawnImmediate()
    {
        if (_currentMolesOnScreen < 5 && _disabledMoles.Count > 0)
        {
            _disabledMoles[0].Respawn();
            _disabledMoles.RemoveAt(0);
            _currentMolesOnScreen++;
        }
    }
}
