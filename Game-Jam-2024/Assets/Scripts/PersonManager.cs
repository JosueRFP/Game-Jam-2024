using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PersonManager : MonoBehaviour
{
    public static PersonManager Instance;

    [Header("Componentes de Texto")]
    public TMP_Text dialogueName,dialogueSetence;
    public SpriteRenderer dialogueSprite;


    [Header("Lista dos Casos/Pessoas")]
    public List<PersonBehaviour> personCases = new List<PersonBehaviour>();
    PersonBehaviour activeCase;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        chooseNewCase();
    }

    public void chooseNewCase() 
    {
        Debug.Log("Caso novo");
        if (personCases.Count <= 0) 
        {
            //acabar jogo
            Debug.Log("GameEnd");
        }
        activeCase = personCases[Random.Range(0, personCases.Count - 1)];
        personCases.Remove(activeCase);

        dialogueName.text = activeCase.name;
        dialogueSetence.text = activeCase.setence;
        dialogueSprite.sprite = activeCase.personFace;



    }
}
