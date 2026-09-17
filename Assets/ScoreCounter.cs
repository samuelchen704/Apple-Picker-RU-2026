using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class ScoreCounter : MonoBehaviour {
    public int score;

    private string GetDebuggerDisplay() => ToString();
}