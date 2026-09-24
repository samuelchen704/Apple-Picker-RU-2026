using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    void Start()
    {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO == null)
        {
            return;
        }
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple") || collidedWith.CompareTag("Gold Apple"))
        {
            Apple appleScript = collidedWith.GetComponent<Apple>();
            int pts = appleScript != null ? appleScript.points : 100;
            Destroy( collidedWith );

            if (scoreCounter == null)
            {
                return;
            }
            // Increase the score and check for a new high score
            scoreCounter.score += pts;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}