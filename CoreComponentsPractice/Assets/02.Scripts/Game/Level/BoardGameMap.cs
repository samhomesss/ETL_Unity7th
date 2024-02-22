using System;
using System.Collections.Generic;

namespace DiceGame.Level
{
    public static class BoardGameMap
    {
        public static List<Node> nodes = new List<Node>();


        public static void Register(Node node)
        {
            nodes.Add(node);
            nodes.Sort();
        }


        // 연습용 
        // IEnumerable -> 반복가능한 GetEnumerator 
        // 책 -> IEnumerable : 처음부터 반복 순회 할수 있는 
        // 책을 읽기 위해서는 -> IEnumerator 가 필요함 (해석할수 있는 친구)
        // 해석할수 있는 친구를 소개 해달라 -> GetEnumerator() : 라는 함수 이용 해서 소개
        // Current 현재 장 
        // foreach -> IEnumerable의 객체를 순회해주는것
        // 핸드폰 사진 참고 

        public static void Practice()
        {
            // nodes = new List<NormalNode>(); // 공변성이 적용되지 않는 상태
            IEnumerable<NormalNode> normalNodes =  new List<NormalNode>();
            IEnumerable<Node> baseNodes = new List<Node>();

            baseNodes = normalNodes; // IEnumerable을 통해서 암시적으로 캐스팅이 되고  이게 공변성 // Node가 상위 개념이라 가능함
            baseNodes = new List<NormalNode>();

            // List<Node> nodes2 = new List<NormalNode>(); // 이거는 불가능 제네릭 타입에서 기반타입으로 참조가 바로 불가능 하기에 추상화(IEnumerable)을 통해서 가능하게 만들수 잇다.
            IEnumerable<Node> nodes2 = new List<NormalNode>();

            IDummy<A> dummy = new C<A>();
            IDummy<B> dumm2 = new C<B>();
            dummy = dumm2;

            stringAction = objectAction; // 기반 타입의 ObjectAction이 stringAction에게 들어가는 현상 -> 반 공변성



            stringAction += DoSomething2; // 위의 경우 stringAction 이 string만 받아올수 있기에 DoSomeThing2의 경우 object 타입이기에 string을 받을수 잇고(모든 형식은 object형식을 받을수 있기에)
            stringAction.Invoke("Carl");

            //objectAction += DoSomething; // 밑의 경우 objectAction 이 object타입 이기에  상수, 정수 , 문자 다 받아올수 있는데 DoSomething 은 상수를 받을수 없고 문자열만 받을수 있기에 불가능 하다.
            //objectAction.Invoke(123123);

            string name = "sam";
            object obj = name;
            obj = 1; // 참조타입 값 타입 참고 하고 또한 obj는 값 타입은 안받아줌 
            // obj = 1 의 경우에는 힙 영역에 새로운 객체를 만드는데 
            // 값형식을 오브젝트형식으로 변환하는 프로세스 -> Boxing 
            // 오브젝트 형식을 값 형식으로 변환하는 프로세스 -> UnBoxing
            //type of(int)라는 참조 걕체를 만들고 그 뒤에 1을 넣어서 참조타입을 만드는것 
            //boxing을 할때 힙 영역에 typeof를 사용해서 정의를 넣어줌
            //int a = obj;  //이렇게 는 사용하지 못함 주소를 넘겨주는건지 UnBoxing을 하는것인지 모르기에 아래의 방식으로 적어야함 (boxing은 암시적 , UnBoxing은 명시적)
            int a = (int)obj; // (int)라고 자료형을 적어주기에 UnBoxing은 명시적  obj = 1 이라고 자료형을 적지 않아도 그 자료형으로 들어가기에 암시적
                              //A a = new B();
            C<int> cint = new C<int>();
            // 이상태로 선언하고 컴파일을 하면 
            // 그때야  public class CofInt : IDummyOfT가 생김

            // 제네릭 타입은 컴파일시 그 형식(자료형)이 결정됨
            MyMath<int> mathObj = new MyMath<int>();
            //mathObj.Sum(1, 2);
        }
                                       
       static Action<string> stringAction; // C#의 모든 기반 타입은 Object다
                                           // Boxing UnBoxing
       static Action<Object> objectAction;


        public static void DoSomething(string node) { }

        public static void DoSomething2(object obj) { }

        public class A { }
        public class B : A { }
        public class C<T> : IDummy<T> {}
        public interface IDummy<out T> {} // 인터페이스에 붙어 있는 out이라는 키워드 때문에 인터페이스의 기반 참조가 가능하게 됨
                                          // 만약 그냥 입력 파라매터 T 라고 하게 되면 A 와 B의 크기와 형식이 달라질 수 있는데 이러면 암시적 캐스팅이 되지 않는다.
                                          // out : 출력 전용 매개 변수, 할당된 변수에 값을 줘야 함, 값 초기화 필요 없음
                                          // 입력형식이 Generic이면 반공변성이고 출력형식이 Genenric이면 공변성이다
                                          
                                          // 대리자가 대표적인 반공변성의 예시 Action 열면 in T라고 적혀 있음 (제네릭 IN)
        
        public class MyMath <T> 
        {
          //  public T Sum(T a, T b) => a + b; // 다중라인 선택 alt + shift
          //  public T Sub(T a, T b) => a - b;
        }

    }
}
