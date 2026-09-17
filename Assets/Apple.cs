using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    public int points = 100;

    private void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
            Camera.main?.SendMessage("AppleMissed", SendMessageOptions.DontRequireReceiver);
        }
    }

    private string GetDebuggerDisplay() => ToString();
}