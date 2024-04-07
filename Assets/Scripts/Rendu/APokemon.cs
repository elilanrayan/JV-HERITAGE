using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APokemon : MonoBehaviour 
{
    private AttackManager attackManager;
    public APokemonAttack attack;
    public List<Pokemon> PokemonData = new();

    [Serializable]
    public struct Pokemon
    {

        public string name;
        public int maxLife;
        public int atk;
        public int def;
        public float size;
        public List<Type> faiblesses;
        public List<Type> résistances;
        public int currentLife;
        public List<APokemonAttack> atkList;

        public Pokemon(string name,int maxLife,int atk, int def, float size,List<Type> f,List<Type> r,int currentLife,List<APokemonAttack> atkList)
        {
            this.name = name;
            this.maxLife = maxLife;
            this.atk = atk;
            this.def = def;
            this.size = size;
            this.faiblesses = f;
            this.currentLife= currentLife;
            this.atkList = atkList;
            this.résistances = r;
              
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int MaxLife
        {
            get { return maxLife; }
            set { maxLife = value; }
        }

        public int Atk
        {
            get { return atk; }
            set { atk = value; }
        }

        public int Def
        {
            get { return def; }
                set { def = value; }
        }

        public float Size
        {
            get { return size; }
            set { size = value; }
        }

        public List<Type> Faiblesses
        {
            get { return faiblesses; }
            set {  faiblesses = value; }
        }

        public List<Type> Resistances
        {
            get { return résistances; }
            set { résistances= value; }
        }

        public int CurrentLife
        {
            get { return currentLife; }
            set { currentLife = value; }
        }

        public List<APokemonAttack> AtkList { get { return atkList; } }


      

        public void InitPokemonStats()
        {
            int stats = atk + def + currentLife;
        }

        public void InitPokemonAttacks()
        {
            //AtkList.Add(attack..Dmg); je comptais ajouter à la liste les données des classes fils mais je n'ai pas réussi
            //AtkList.Add(APokemonAttack1.Dmg);

        }

        public void AddPokemonToAttack()
        {
            //AttackManager.attackers.Add(PokemonData); J'ai essayé d'ajouter a la liste attackers un element de type pokemonData
        }

        public void DisplayPokemonData()
        {
            //Debug.Log(Pokemon.name);
        }

        

    }

   
    
}


public class APokemonAttack 
{
    private string nameAttack;
    private int dmg;

    public string NameAttack
    {
        get { return nameAttack; }
        set { nameAttack = value; }
    }

    public int Dmg
    {
        get { return dmg; }
        set { dmg = value; }
    }

    public virtual void GetAttackInfo()
    {
        Debug.Log("Le nom de l'attaque est : " + NameAttack);
        Debug.Log("Il va prendre " + Dmg + " de dégâts");
    }
}


public class APokemonAttack1 : APokemonAttack
{
    public string NameAttack="Surprise";
    public int Dmg=2;

    public override void GetAttackInfo()
    {
        Debug.Log("Le nom de l'attaque est : " + NameAttack);
        Debug.Log("Il va prendre " + Dmg + " de dégâts");
    }

  

}

public class APokemonAttack2 : APokemonAttack
{
    public string NameAttack="Secrète";
    public int Dmg=56;

    public override void GetAttackInfo()
    {
        Debug.Log("Le nom de l'attaque est : " + NameAttack);
        Debug.Log("Il va prendre " + Dmg + " de dégâts");
    }
}

public class APokemonAttack3 : APokemonAttack
{
    public string NameAttack="Nul";
    public int Dmg=0;

    public override void GetAttackInfo()
    {
        Debug.Log("Le nom de l'attaque est : " + NameAttack);
        Debug.Log("Il va prendre " + Dmg + " de dégâts");
    }
}

public class APokemonAttack4 : APokemonAttack
{
    public string NameAttack="Puissance";
    public int Dmg=90;

    public override void GetAttackInfo()
    {
        Debug.Log("Le nom de l'attaque est : " + NameAttack);
        Debug.Log("Il va prendre " + Dmg + " de dégâts");
    }
}


public class AttackManager : MonoBehaviour
{
    private static AttackManager instance;


    public static AttackManager GetInstance()
    {
        if (instance == null)
        {
            instance = new AttackManager();
        }
        return instance;
    }

    public AttackManager Instance { get { return instance; } }

    private List<APokemon> attackers;

    private int round=0;

    IEnumerator InitCombatLobby()
    {
        if (attackers.Count == 2)
        {
           PlayRounds();
        }
        else
        {
            yield return 0.5f;
        }
    }

    void PlayRounds()
    {
        if (attackers.Count == 2)
        {
            round++;
        }
        else
        {
            Debug.Log("Le premier Pokemon a combattu l'autre");
        }
    }
}


public class PokemonDataA : MonoBehaviour
{

    public string nom = "Pikachu";
    public int maxHealth = 100;
    public int currentHealth;
    public int attack;
    public int defense;
    private int _stats;
    public float weight = 3.3f;
    public Type type;


    public Type[] weakness;
    public Type[] strenght;

    public PokemonDataA(string nom, int maxHealth, int currentHealth, int attack, int defense, int stats, float weight, Type type, Type[] weakness, Type[] strenght)
    {
        this.nom = nom;
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        this.attack = attack;
        this.defense = defense;
        _stats = stats;
        this.type = type;
        this.weakness = weakness;
        this.strenght = strenght;
    }

    private void Awake()
    {
        InitCurrentLife();
        InitStatsPoints();
    }
    void Start()
    {
        DisplayAttack();
        DisplayLife();
        DisplayName();
        DisplayType();
        DisplayWeight();
        
    }


    void FixedUpdate()
    {


    }

    void InitCurrentLife()
    {
        currentHealth = maxHealth;
    }

    void InitStatsPoints()
    {
        _stats = currentHealth + attack + defense;
    }



    void TakeDamage(int attack, Type type)
    {
        if (attack > 0 && currentHealth > 0)
        {
            int xpattack = attack;
            foreach (Type w in weakness)
            {
                if (w == type)
                {
                    xpattack = attack * 2;
                    currentHealth -= xpattack;
                    return;

                }

            }
            foreach (Type s in strenght)
            {
                if (s == type)
                {
                    xpattack = attack / 2;
                    currentHealth -= xpattack;
                    return;

                }
            }
            currentHealth -= attack;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }

        }
        else
        {
            Debug.Log("Les dégats sont inférieurs ou égale à O ! ");
        }

    }

    /*private void AttackOpenent(APokemon) 
    {
        TakeDamage();
    }
    */


    void DisplayName()
    {
        Debug.Log("NOM DU POKEMON : " + nom);
    }


    void DisplayLife()
    {
        Debug.Log("VIE " + currentHealth);
    }

    void DisplayAttack()
    {
        Debug.Log("SON ATTAQUE " + attack);
    }
    void DisplayType()
    {
        Debug.Log("SON TYPE EST " + type);
    }
    void DisplayWeight()
    {
        Debug.Log("SON POIDS EST DE " + weight);
    }


    

}

public enum Type
{
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Dark,
    Steel,
    Fairy
}