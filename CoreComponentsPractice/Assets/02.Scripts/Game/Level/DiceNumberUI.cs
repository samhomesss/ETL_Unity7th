using DiceGame.Game;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A라고 하는 타입이 있고  B라는 타입이 잇는데 B는 A를 상속받은거 
/// Generic 타입 T가 있을때 T<A>라는 객체를 만들었을때 T<A> a = new T<B>가 가능한것을 공변성이라고 한다. 
/// 위의 상황이 반대 된것을 반공변성이라고 한다.
/// </summary>
public class DiceNumberUI : MonoBehaviour
{
    TMP_Text _dicenumberText;

    private void Start()
    { 
        _dicenumberText = GetComponent<TMP_Text>();
        DicePlayManager.instance.diceNumber = 5;
        _dicenumberText.text = DicePlayManager.instance.diceNumber.ToString();
        DicePlayManager.instance.onDiceNumberChanged += (diceNumber) => _dicenumberText.text = diceNumber.ToString();
    }

}
