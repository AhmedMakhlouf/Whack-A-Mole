using UnityEngine;

[CreateAssetMenu]
public class MoleData : ScriptableObject
{
    [Range(0.4f, 2.4f)]
    public float size;

    public int points;

    public float timeOnScreen;

    public Color color;	
}
