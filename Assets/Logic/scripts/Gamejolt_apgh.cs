using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gamejolt_apgh : MonoBehaviour
{

    public void sigingamejolt()
    {
        GameJolt.UI.GameJoltUI.Instance.ShowSignIn();

        GameJolt.UI.GameJoltUI.Instance.ShowSignIn(
        (bool signInSuccess) =>
        {

        },
        (bool userFetchedSuccess) =>
        {

        }
                                                  );
    }
    private void Update()
    {
        var isSignedIn = GameJolt.API.GameJoltAPI.Instance.CurrentUser != null;
        if (isSignedIn)
        {
            Globalprefs.signedgamejolt = true;
        }

    }
}
