using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bartok : MonoBehaviour { 
    static public Bartok S;
     
    [Header("Set in Inspector")] 
    public TextAsset deckXML; 
    public TextAsset layoutXML; 
    public Vector3 layoutCenter = Vector3.zero;
     
    [Header("Set Dynamically")] 
    public Deck deck; 
    public List<CardBartok> drawPile; 
    public List<CardBartok> discardPile;
    private BartokLayout layout;
    private Transform layoutAnchor;

    void Awake() { 
        S = this; 
    }
     
    void Start() { 
        deck = GetComponent<Deck>();            // Get the Deck 
        deck.InitDeck(deckXML.text);            // Pass DeckXML to it 
        Deck.Shuffle(ref deck.cards);           // This shuffles the deck 
        layout = GetComponent<BartokLayout>();  // Get the Layout
        layout.ReadLayout(layoutXML.text);      // Pass LayoutXML to it
        drawPile = UpgradeCardsList(deck.cards);
    }

    List<CardBartok> UpgradeCardsList(List<Card> lCD) { 
        List<CardBartok> lCB = new List<CardBartok>(); 
        foreach (Card tCD in lCD) { 
            lCB.Add(tCD as CardBartok); 
        } 
        return (lCB); 
    }
}
