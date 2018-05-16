using UnityEngine;

[CreateAssetMenu]
public class MoleData : ScriptableObject
{
    [Range(0.4f, 1.2f)]
    public float size;

    public int points;

    public float timeOnScreen;

    public Color color;	
}
