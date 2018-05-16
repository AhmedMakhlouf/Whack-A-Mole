using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomLocation : MonoBehaviour
{
    public RectTransform screen;

    private Dictionary<Mole, Vector2> _reservedLocation = new Dictionary<Mole, Vector2>();
    private float _halfWidth;
    private float _halfHeight;

    private void Start()
    {
        _halfWidth = screen.sizeDelta.x / 2;
        _halfHeight = screen.sizeDelta.y / 2;
    }

    public void NewGame()
    {
        _reservedLocation.Clear();
    }

    public Vector2 FindLocation(Mole m)
    {
        Vector2 random = new Vector2
        {
            x = Random.Range(-_halfWidth, _halfWidth),
            y = Random.Range(-_halfHeight, _halfHeight)
        };


        if (CheckOverlap(m, random))
        {
            _reservedLocation.Add(m, random);
            return random;
        }
        else
        {
            return FindLocation(m);
        }
    }

    public void FreeLocation(Mole m)
    {
        _reservedLocation.Remove(m);
    }

    private bool CheckOverlap(Mole m, Vector2 newPos)
    {
        foreach(KeyValuePair<Mole, Vector2> entry in _reservedLocation)
        {
            float minDistance = m.data.size / 2 + entry.Key.data.size / 2 + 20;

            float distance = Vector2.Distance(newPos, entry.Value);

            if (distance < minDistance)
                return false;
        }
        
        return true;
    }
}
