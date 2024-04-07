using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurManager : MonoBehaviour
{
    public GameObject player;
   
    public void createPlayer()
    {
        var newPlayer = Instantiate(player);
        newPlayer.AddComponent<Joueur>();
        Joueur.OnCreate();

        Debug.Log("nombre de joueur : " + Joueur.nbConnectedPlayers);
    }
}
