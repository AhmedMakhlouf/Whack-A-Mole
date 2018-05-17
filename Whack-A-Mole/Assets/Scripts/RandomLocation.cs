using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    public RectTransform screen;

    private Dictionary<Mole, Vector2> reservedLocation = new Dictionary<Mole, Vector2>();

    /// <summary>
    /// half the width of the screen.
    /// </summary>
    private float halfWidth;
    /// <summary>
    /// half the height of the screen.
    /// </summary>
    private float halfHeight;

    private const float MoleRadius = 50.0f;

    private void Start()
    {
        halfWidth = screen.sizeDelta.x / 2;
        halfHeight = screen.sizeDelta.y / 2;
    }

    public void NewGame()
    {
        reservedLocation.Clear();
    }

    public Vector2 FindLocation(Mole m)
    {
        Vector2 random = GetRandom();

        // number of attempt to find a non-overlaping location
        int numOfAttempts = 0;

        // if number of attempts reaches 25, just return an overlaping location this time.
        while (CheckOverlap(m, random) == false && numOfAttempts < 25)
        {
            random = GetRandom();
            numOfAttempts++;
        }

        //Debug.Log(numOfAttempts);
        reservedLocation.Add(m, random);
        return random;        
    }

    private Vector2 GetRandom()
    {
        return new Vector2
        {
            x = Random.Range(-halfWidth, halfWidth),
            y = Random.Range(-halfHeight, halfHeight)
        };
    }

    public void FreeLocation(Mole m)
    {
        reservedLocation.Remove(m);
    }

    private bool CheckOverlap(Mole m, Vector2 newPos)
    {
        foreach(KeyValuePair<Mole, Vector2> entry in reservedLocation)
        {
            float minDistance = (MoleRadius * m.data.size) + (MoleRadius * entry.Key.data.size);

            float distance = Vector2.Distance(newPos, entry.Value);

            if (distance < minDistance)
                return false;
        }
        
        return true;
    }
}
