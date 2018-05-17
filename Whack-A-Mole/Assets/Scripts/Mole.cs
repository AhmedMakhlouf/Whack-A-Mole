using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Mole : MonoBehaviour
{
    /// <summary>
    /// Used to animate and scale the mole
    /// </summary>
    public MoleVisuals visuals;


    public UnityAction<Mole, bool> OnMoleDied;

    [HideInInspector]
    public MoleData data;
    
    /// <summary>
    /// Spawn the mole at a given position.
    /// </summary>
    /// <param name="pos"> randon position to spawn at </param>
    /// <param name="d"> data as a scriptable object </param>
    public void Respawn(Vector2 pos, MoleData d)
    {
        data = d;

        gameObject.GetComponent<RectTransform>().localPosition = pos;
        gameObject.SetActive(true);
        StartCoroutine("Timer");

        visuals.Respawn(data);
    }


    /// <summary>
    /// Despawn the mole.
    /// </summary>
    public void Despawn()
    {
        if (gameObject.activeSelf == false)
            return;

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Called when the mole is clicked.
    /// </summary>
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
