using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Mole[] moles;
    public MoleData[] moleData;

    public float spawnTimer;

    public Score score;
    public Timer timer;
    public GameUI ui;
    public RandomLocation location;

    private int _currentMolesOnScreen;
    private int _points;
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
    
    private void MoleDied(Mole mole, bool clicked)
    {
        location.FreeLocation(mole);
        _disabledMoles.Add(mole);
        _currentMolesOnScreen--;

        if (clicked)
        {
            _points += mole.data.points;
            score.UpdateScore(_points);
        }

        SpawnImmediate();
    }

    public void NewGame()
    {
        ui.NewGame();
        score.NewGame();
        location.NewGame();
        _disabledMoles.Clear();

        foreach (Mole m in moles)
        {
            m.Despawn();
            _disabledMoles.Add(m);
        }

        _points = 0;
        _currentMolesOnScreen = 0;

        StartCoroutine("SpawnMoles");
        SpawnImmediate();
        timer.Restart();
    }

    private void GameOver()
    {
        StopCoroutine("SpawnMoles");
        ui.GameOver();
        score.GameOver(_points);
    }

    IEnumerator SpawnMoles()
    {
        while(true)
        {
            if(_currentMolesOnScreen < 7 && _disabledMoles.Count > 0)
            {
                _disabledMoles[0].Respawn(location.FindLocation(_disabledMoles[0]), RandomMole());
                _disabledMoles.RemoveAt(0);
                _currentMolesOnScreen++;
            }

            yield return _wait;
        }
    }

    private void SpawnImmediate()
    {
        while (_currentMolesOnScreen < 5 && _disabledMoles.Count > 0)
        {
            _disabledMoles[0].Respawn(location.FindLocation(_disabledMoles[0]), RandomMole());
            _disabledMoles.RemoveAt(0);
            _currentMolesOnScreen++;
        }
    }

    private MoleData RandomMole()
    {
        return moleData[Random.Range(0, 3)];
    }
}
