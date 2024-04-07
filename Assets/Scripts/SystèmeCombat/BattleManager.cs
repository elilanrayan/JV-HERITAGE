using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum ETAT { START,PLAYERTURN,ENEMYTURN,WON,LOST}
public class BattleManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    private static BattleManager instance;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Text dialogueText;

    public static BattleManager GetInstance()
    {
        if (instance == null)
            instance = new BattleManager();
        return instance;
    }


    public ETAT etat;
    void Start()
    {
        etat=ETAT.START;
        StartCoroutine(SetupBattle());
    }

   IEnumerator SetupBattle()
    {
        GameObject playerGO= Instantiate(playerPrefab,playerBattleStation);
        playerUnit=playerGO.GetComponent<Unit>();

        GameObject enemyGO=Instantiate(enemyPrefab,enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text="Un certain "+enemyUnit.name+" s'approche !";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);
        etat = ETAT.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead=enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "L'attaque est effectuée !";


        yield return new WaitForSeconds(2f);
        if (isDead) { etat = ETAT.WON;
            EndBattle();
        }
        else { etat = ETAT.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }


    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.name + " attaque !";

        yield return new WaitForSeconds(1f);

        bool isDead= playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            etat = ETAT.LOST;
            EndBattle();
        }
        else
        {
            etat = ETAT.PLAYERTURN;
            PlayerTurn();
        }

    }
    void EndBattle()
    {
        if(etat==ETAT.WON)
        {
            dialogueText.text = "Tu as gagné !";
;        }
        else if(etat==ETAT.LOST)
        {
            dialogueText.text = "Tu as perdu !";
        }
    }


    void PlayerTurn()
    {
        dialogueText.text = "Choisis une action : ";
    }

    public void OnAttackButton()
    {
        if (etat != ETAT.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

        
    }
    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "+ de vie !";

        yield return new WaitForSeconds(2f);

        etat= ETAT.ENEMYTURN;
        StartCoroutine (EnemyTurn());
    }

    public void OnHealButton()
    {
        if (etat != ETAT.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());


    }
}
