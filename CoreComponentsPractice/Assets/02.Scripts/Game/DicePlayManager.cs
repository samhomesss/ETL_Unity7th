using DiceGame.UI;
using DiceGame.Character;
using System;
using System.Collections;
using UnityEngine;
using DiceGame.Level;
using DiceGame.Singleton;
namespace DiceGame.Game
{
    // 보통 싱글톤은 스크립터블 오브젝트로 대형 컨테이너를 이용해서 아이템 정보를 저장한다라고하면 -> item의 ScriptableObject들을 참조하기 위한 방식으로 많이 사용한다.
    public class DicePlayManager : SIngletonMonoBase<DicePlayManager>
    {
        public int diceNumber
        {
            get => _diceNumber;
            set
            {
                if (_diceNumber == value)
                    return;

                _diceNumber = value;
                onDiceNumberChanged?.Invoke(_diceNumber);
            }
        }

        private int _diceNumber;
        private bool _isCorouting;
        public event Action<int> onDiceNumberChanged;
        public event Action onRollingDiceStarted;
        public event Action onRollingDiceFinished;


        public void RollADice()
        {
            if (_isCorouting)
                return;

            diceNumber--;

            onRollingDiceStarted?.Invoke();
            int diceValue = UnityEngine.Random.Range(1, 7);
            _isCorouting = true;
            StartCoroutine(C_RollADice(diceValue));
        }

        IEnumerator C_RollADice(int diceValue)
        {
            yield return StartCoroutine(DiceRollingAnimationUI.instance.C_Animation(diceValue));
            BoardGameMap.nodes[PlayerController.instance.nodeIndex].OnDiceRolled(diceValue);
            yield return StartCoroutine(PlayerController.instance.C_Move(diceValue));
            BoardGameMap.nodes[PlayerController.instance.nodeIndex].OnPlayerHere();
            onRollingDiceFinished?.Invoke();
            _isCorouting = false;
        }
    }
}