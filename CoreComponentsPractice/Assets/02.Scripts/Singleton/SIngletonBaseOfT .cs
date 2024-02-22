using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection; // 코드 사용중 메타 데이터에 접근할수 있는 기능을 가진 친구 
using UnityEngine;

namespace DiceGame.Singleton
{ // 모든 클래스는 : object가 생략되어 있는것이다 
    public class SIngletonBase<T>  where T : SIngletonBase<T>
    {
        public static T instance
        {
            get
            {
                if (_instance == null) 
                {
                   // ConstructorInfo constructorInfo = typeof(T).GetConstructor(new Type[] { });
                   // _instance = (T)constructorInfo.Invoke(new object[]{ });
                   // 위의 두줄이 아래 한줄이다.
                    Activator.CreateInstance(typeof(T)); // 하지만 이렇게 사용하면 생성자를 못쓰는 모노비해이비어는 못쓴다 
                }
                return _instance;
            }
        }

        private static T _instance;
    }

}
