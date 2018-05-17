using UnityEngine;
using UnityEngine.UI;

public class MoleVisuals : MonoBehaviour
{

    public RectTransform scale;
    public Image front;
    public Image back;

    public RectTransform movingImage;
    public RectTransform target;
        
    private bool animating;
    private float step;

    void Update ()
    {
        if (!animating)
            return;

        movingImage.localPosition = Vector2.MoveTowards(movingImage.localPosition, target.localPosition, step);

        if(Vector2.Distance(movingImage.localPosition, target.localPosition) < 0.05f)
        {
            movingImage.localPosition = target.localPosition;
            animating = false;
        }

    }

    public void Respawn(MoleData data)
    {
        scale.localScale = new Vector2(data.size, data.size);

        front.color = data.color;
        back.color = data.color;

        movingImage.localPosition = Vector2.zero;
        step = (Vector2.Distance(movingImage.localPosition, target.localPosition) / data.timeOnScreen) * Time.deltaTime;

        animating = true;
    }
}
