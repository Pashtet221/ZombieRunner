using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    [SerializeField] private List<Character> _characters = new List<Character>();

    public IList<Character> Characters => _characters;

}
