https://www.khanacademy.org/computing/computer-science/algorithms/intro-to-algorithms/v/what-are-algorithms

1.
Укажите строчки, в которых произойдут ошибки компиляции:

    interface IA
    {
      int M1 { get; }
      int M2 { set; }
      int M3 { get; set; }
      int M4();
    }

    class A : IA
    {
      int IA.M1 { get { return 0; } }
      public int M2 { set { } }
      public int M3 { get { return 0; } set { } }
      public int M4() { return 0; }
    }

    class Program
    {
      public static void Main()
      {
        A a = new A();
        var m1 = a.M1;   // #1
        a.M2 = 0;        // #2
        var m3 = a.M3;   // #3
        var m4 = a.M4(); // #4
      }
    }
Ваш ответ:
  #1
  https://msdn.microsoft.com/ru-ru/library/aa288461(v=vs.71).aspx
  Explicit Interface Implementation. For compilation: var m1 = ((IA) a).M1;

2.
Укажите ограничения, которые достаточно добавить к методу M для его корректной компиляции:

    public static T M() //where T ...
    {
      return new T();
    }
Ваш ответ:
  - where T: struct
  - where T: IEnumerable, new()
  - where T: class
  - where T: new(), IEnumerable

  Учесть что нет реализации не одного из приведенных примеров, вопрос не понятен.
  https://msdn.microsoft.com/ru-ru/library/d5x73970.aspx


3.
Укажите операции в которых List асимптотически быстрее или равен LinkedList (амортизационную O(1) считать равной O(1))
Ваш ответ:
  Взятие по элемента индексу
  Вставка или удаление элемента в конце, последовательная итерация по одному элементу

   Глава 2 Дональда Кнута "Искусство Программирования"
4.

Выберите верные утверждения о ref/out:
Ваш ответ:
  Переменная, передаваемая в качестве параметра, помеченного ref, должна быть инициализирована
 

https://msdn.microsoft.com/ru-ru/library/14akc2c7.aspx
https://msdn.microsoft.com/ru-ru/library/t3c3bfhx.aspx

5.

Какие механизмы условной компиляции предусмотрены в C#?
Ваш ответ:
  http://lektsiopedia.org/lek2-7461.html

6.
Чем (из поддерживаемого в C#) может заканчиваться блок case оператора switch?
Ваш ответ:
  break, goto case, return или throw. 
  конец разделов switch, включая последний раздел, должен быть недостижим.
    Пример:
        case 4:
          while (true)
              Console.WriteLine("Endless looping. . . .");
  https://msdn.microsoft.com/ru-ru/library/06tc147t.aspx

7.

Выберите верные утверждения о делегатах:
Ваш ответ:
  +Делегаты являются неизменяемыми
  +Делегат, указывающий на не статический метод класса, содержит ссылку на экземпляр этого класса
  https://habrahabr.ru/post/198694/

8.

Экземпляр значимого типа в качестве параметра метода передаются:
Ваш ответ:
  Всегда по значению
  В зависимости от ref/out
https://msdn.microsoft.com/ru-ru/library/4d43ts61(v=vs.90).aspx

9.
Каким образом можно прекратить обработку исключения в блоке catch (Exception ex) и пробросить исключение дальше по стеку, при этом сохранив стек исключения?
Ваш ответ:
  -throw new Exception(ex);
  +throw;
https://msdn.microsoft.com/ru-ru/library/0yd65esw.aspx

10.
Что выведет на консоль следующий код?

    [StructLayout(LayoutKind.Explicit)]
    struct A
    {
      [FieldOffset(0)]
      public object V1;

      [FieldOffset(0)]
      public int V2;
    }

    public static void Main()
    {
      var a = new A();
      a.V1 = new object();
      Console.WriteLine(a.V2);
    }
Ваш ответ:
  -Адрес объекта object в памяти
  Выводит:
  Additional information: Не удалось загрузить тип "A" из сборки "ConsoleApplication4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", 
  так как он содержит поле объекта со смещением 0, которое неверно выровнено или перекрыто полем, не представляющим объект.
  Непонятная штука. Курить мануал:
  https://msdn.microsoft.com/ru-ru/library/system.runtime.interopservices.fieldoffsetattribute(v=vs.110).aspx

11.
Выберите верные утверждения о методах расширения:
Ваш ответ:
  +Перед первым параметром метода расширения должно быть ключевое слово this;
  -С помощью метода расширения можно переопределить реализацию метода в класса;
  +Метод расширения не может быть реализован для интерфейса;
  -Метод расширения не может быть реализован для структур;
https://msdn.microsoft.com/ru-ru/library/bb383977.aspx

12.
Укажите строчки, при выполнении которых будет выброшено исключение:

    object o = 1;
    double a1 = (double)(int)o;         // #1
    double a2 = (double)o;              // #2
    double a3 = (int)o;                 // #3
    double a4 = (double)(int)(double)o; // #4
Ваш ответ:
  +// #2
  -// #3
  +// #4

13.
Выберите корректные (без ошибок компиляции) способы создания переменной типа float:
Ваш ответ:
  -float a = 0.5; (double) надо было float a = 0.5F;
  float a = 0;
  -var a = 0.5; (Тоже double) надо было var a = 0.5F;
https://msdn.microsoft.com/ru-ru/library/b1e65aza.aspx

14.
Какое условие необходимо выполнить, что бы произвольный класс мог быть использован в цикле foreach?
Ваш ответ:
  -Реализовать метод GetEnumerator() возвращающий объект IEnumerator
  +Реализовать интерфейс System.Collections.IEnumerable

  https://msdn.microsoft.com/ru-ru/library/ttw7t8t6.aspx

15.
Отметьте правильные утверждения, показывающие разницу между методами Object.Equals и Object.ReferenceEquals.
Ваш ответ:
  -Метод ReferenceEquals может быть перегружен
  -Метод Equals является статическим
  +Метод ReferenceEquals может возвращать false, когда Equals возвращает true (реализации корректны)
  +Метод Equals может возвращать false, когда ReferenceEquals возвращает true (реализации корректны)
  +Реализация метода Equals по умолчанию, для ссылочных типов возвращает true, если это один и тот же объект в памяти

 https://msdn.microsoft.com/ru-ru/library/bsc2ak47(v=vs.110).aspx
 https://msdn.microsoft.com/ru-ru/library/system.object.referenceequals(v=vs.110).aspx 

16.
Выберите верные утверждения о функции GetHashCode:
Ваш ответ:
  +Функция GetHashCode необходима для использования объектов в качестве ключа для контейнеров реализующих алгоритм хеш таблицы;
  +При перегрузке функции GetHashCode для корректной работы так же должна быть перегружена функция Equals;
 -Для ссылочных типов функция GetHashCode (если не перегружена) возвращает адресс объекта в памяти;

https://msdn.microsoft.com/ru-ru/library/system.object.gethashcode(v=vs.110).aspx

17.
Какой модификатор доступа позволит использовать метод в пределах текущей сборки?
Ваш ответ:
  -public
  +internal
  -protected
  +protected internal
https://msdn.microsoft.com/ru-ru/library/7c5ka91b.aspx

18.
Отметьте правильные утверждения о конструкции using:
Ваш ответ:
  +В using можно объявить несколько объектов одного типа
  +В using можно передать уже созданный объект
  +В объявлении using можно не создавать переменную
  +В using можно передать любой объект, содержащий публичный метод void Dispose ()
https://msdn.microsoft.com/ru-ru/library/yh598w02.aspx

19.
Что выведет на консоль следующий код?

    public class A<T>
    {
      public static int Count { get; private set; }
      public A() { A<T>.Count++; }
    }
    public static void Main()
    {
      new A<string>();
      new A<string>();
      new A<int>();
      Console.WriteLine(A<int>.Count);
    }
Ваш ответ:
  1, так как в куче два объекта A<string>.Count = 2 и A<int>.Сount = 1;


20.
Выберите верные утверждения о перечислениях (enum).
Ваш ответ:
  +Типы long, ulong, short, sbyte могут быть базовыми типами для перечисления
  -Значение каждого перечислителя в перечислении необходимо задавать вручную
  +Атрибут FlagsAttribute влияет на результат вызова метода ToString();

https://msdn.microsoft.com/ru-ru/library/sbbt4032.aspx
https://msdn.microsoft.com/ru-ru/library/system.flagsattribute.aspx

21.
Какое исключение будет выброшено в результате выполнения следующего кода

object a = 5;
string s = (a as string).ToLower();
Ваш ответ:
  -InvalidCastException

  +'System.NullReferenceException' - оператор as возвращает значение если успешно приведение и null если нет.
https://msdn.microsoft.com/ru-ru/library/cc488006.aspx

22.
Укажите операторы, которые могут быть перегружены в C#:
Ваш ответ:
  << >>
  <= >=
  <<= >>=
  %
https://msdn.microsoft.com/ru-ru/library/5tk49fh2.aspx


23.
Что выведет на консоль следующий код?

    string z = "zz";
    string a = "zzzz";
    string b = "zzzz";
    string c = z + z;
    Console.Write("{0} {1};", a == b, ReferenceEquals(a, b));
    Console.Write("{0} {1};", b == c, ReferenceEquals(b, c));
Ваш ответ:
  +True True; True False;
 https://msdn.microsoft.com/ru-ru/library/system.object.referenceequals(v=vs.110).aspx 


24.
Выберите верные утверждения о событиях:
Ваш ответ:
 -Тип события должен быть EventHandler или EventHandler

https://msdn.microsoft.com/ru-ru/library/awbftdfh.aspx

25.
Выберите верные утверждения о статических конструкторах:
Ваш ответ:
  -Статический конструктор не может быть объявлен у значимых типов
  +Статический конструктор всегда приватный (вообще не принимает модификаторы доступа) 
  -Исключение, выброшенное во время выполнения статического конструктора, нельзя обработать.

https://msdn.microsoft.com/ru-ru/library/k9x6w0hc.aspx

26.
Какое количество строк будет создано при выполнения следующего кода?
var s = "string".ToLower().Remove(1);
Ваш ответ:
  3 - на каждую операцию стоздается новая строка 
https://msdn.microsoft.com/ru-ru/library/system.string(v=vs.110).aspx

27.
Выберите верные утверждения о именованных и необязательных аргументах:
Ваш ответ:
  +Необязательные аргументы должны находиться строго после обязательныx;
  -Необязательные аргументы не могут быть использованы в конструкторах;
 -Необязательные аргументы не могут быть использованы в делегатах;
https://msdn.microsoft.com/ru-ru/library/dd264739.aspx

28.
Отметьте правильные утверждения о финализаторах.
Ваш ответ:
  
  -Объекты с финализатором увеличивают затраты на сборку мусора
https://msdn.microsoft.com/ru-ru/library/system.object.finalize(v=vs.110).aspx

29.
Укажите строчки, в которых произойдут ошибки компиляции:

    IEnumerable<object> a1 = new string[0];
    object[] a2 = new int[0];
    string[] a3 = new object[0];
    Action<string> a4 = new Action<object>(delegate { });
    Action<object> a5 = new Action<string>(delegate { });
Ваш ответ:
  2, 3, 5