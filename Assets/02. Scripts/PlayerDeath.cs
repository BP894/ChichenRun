using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public UIManager uiManager;

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.GetComponent<BoxCollider>() != null)
        {
            Destroy(gameObject);

            uiManager.gameOverUIController.PrimarySetting(true);
            uiManager.gameOverUIController.SetScore();
        }
    }
}
