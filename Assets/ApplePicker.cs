using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for reloading the scene

public class ApplePicker : MonoBehaviour {
    [Header("Inscribed")]
    public GameObject       basketPrefab;
    public int              numBaskets     = 3;
    public float            basketBottomY  = -14f;
    public float            basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start () {
        basketList = new List<GameObject>();
        for (int i=0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i );
            tBasketGO.transform.position = pos;
            basketList.Add( tBasketGO );
        }
    }

    public void AppleMissed() {
        // 1. Destroy all of the falling apples currently on screen
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach ( GameObject tempGO in appleArray ) {
            Destroy( tempGO );
        }

        // 2. Destroy one of the Baskets (from top to bottom)
        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt( basketIndex );
        Destroy( basketGO );

        // 3. If there are no Baskets left, restart the game
        if ( basketList.Count == 0 ) {
            SceneManager.LoadScene( "_Scene_0" );
        }
    }
}