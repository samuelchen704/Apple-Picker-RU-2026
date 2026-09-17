using System.Diagnostics;
using UnityEngine;

public interface IBasket
{
    ScoreCounter ScoreCounter { get; set; }
}

public interface IBasket1
{
    ScoreCounter ScoreCounter { get; set; }
}

public interface IBasket2
{
    ScoreCounter ScoreCounter { get; set; }
}

public interface IBasket3
{
    ScoreCounter ScoreCounter { get; set; }
}

public interface IBasket4
{
    ScoreCounter ScoreCounter { get; set; }
}

[DebuggerDisplay("{"
                 + nameof(DebuggerDisplay
)
                 + "(),nq}")]
public class Basket : MonoBehaviour, IBasket, IBasket1, IBasket2, IBasket3, IBasket4
{
    private ScoreCounter scoreCounter;

    public ScoreCounter ScoreCounter { get => scoreCounter; set => scoreCounter = value; }

    public Basket()
    {
    }

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO == null)
        {
            return;
        }
        ScoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple") || collidedWith.CompareTag("Gold Apple"))
        {
            Apple appleScript = collidedWith.GetComponent<Apple>();
            int pts = (appleScript != null) ? appleScript.points : 100;

            Destroy(collidedWith);

            if (ScoreCounter == null)
            {
                return;
            }
            ScoreCounter.score += pts;
        }
    }

    private string DebuggerDisplay => ToString();
}
