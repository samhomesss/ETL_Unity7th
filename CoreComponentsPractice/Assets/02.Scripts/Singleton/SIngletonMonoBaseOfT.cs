using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection; // 코드 사용중 메타 데이터에 접근할수 있는 기능을 가진 친구 
using UnityEngine;

namespace DiceGame.Singleton
{ // 모든 클래스는 : object가 생략되어 있는것이다 
    public class SIngletonMonoBase<T> : MonoBehaviour 
        where T : SIngletonMonoBase<T>
    {
        public static T instance
        {
            get
            {
                if (_instance == null) 
                {
                   _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }
                return _instance;
            }
        }

        private static T _instance;
    }

}
