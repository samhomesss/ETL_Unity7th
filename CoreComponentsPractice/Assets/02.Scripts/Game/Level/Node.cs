using DiceGame.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceGame.Level
{
    public abstract class Node : MonoBehaviour, INode, IComparable<Node>
    {
        public int nodeIndex => _nodeIndex;

        [SerializeField] private int _nodeIndex;


        private void Awake()
        {
            BoardGameMap.Register(this); // 노드 등록  // 처음 시작하자마자 등록해서 관리 되도록 설정
        }

        public virtual void OnPlayerHere()
        {
            PlayerController.instance.direction = PlayerController.DIRECTION_POSITIVE;
        }

        public virtual void OnDiceRolled(int diceValue)
        {
        }

        public int CompareTo(Node other)
        {
            if (_nodeIndex < other._nodeIndex)
                return -1;
            else if (_nodeIndex > other._nodeIndex)
                return 1;

            return 0;
        }
    }
}
