using System;
namespace lab1_Filatov
{
    public class Stack
    {
        public uint Size { get; set; } 
        public int [] array;
        public static ulong N_op = 0;
        private bool isEmpty() // проверка на то, что стек пуст
            //3
        {
            return (Size == 0); //3
        }

        private bool CheckPos(uint pos) //проверка наличия заданной позиции
            //3
        {
            return (pos > Size); //3      
        }

        private bool StackOverflow() //проверка, что стек заполнен
            //4
        {
            return (Size == array.Length); //4
        }

        public void Clear (uint pos) //очистка стека до заданной позиции
            //5+4N
        {
            N_op += 5;
            if (CheckPos(pos)) //3
                Console.WriteLine("Номер позиции больше, чем количество элементов в стеке");
            else for (uint i = Size; i > pos; --i) //2+4N
            {
                array[--Size] = default; //4
                N_op += 4;
            }
            
        }

        public void Push(int item) //добавление элемента
        //4+5=9
        {
            if (StackOverflow()) //4
                Console.WriteLine("Стек переполнен");
            else
            {
                array[Size] = item; //2
                ++Size;  //3 
            }
        }

        public void Push(int[] a) //добавление массива элементов
        //5+9N
        {
            N_op += 5;
            if (StackOverflow()) //4
                Console.WriteLine("Стек переполнен");
            else
            {
                foreach (int item in a) //1+9N
                {
                    N_op += 9;
                    Push(item); //9 }
                }
                    
            }
        }

        public int Pop() //удаление и получение значения верхнего элемента
            //3+2+4+2+1=12
        {
            if (isEmpty()) //3
            {
                Console.WriteLine("Стек пуст");
                throw new Exception("В стеке нет элементов"); //2
            }
            else
            {
                int item = array[--Size]; //1+3=4
                array[Size] = default; //2
                return item; //1
            }

        }

        public int Peek() //получение верхнего значения без его удаления
        { //3+2+3=8
            if (isEmpty()) //3
            {
                Console.WriteLine("Стек пуст");
                throw new Exception ("В стеке нет элементов"); //2
            }
                
            else return array[Size - 1]; //1+2
        }

        public void Print() //вывод стека
            //6+N
        {
            if (isEmpty()) //3
                Console.WriteLine("Стек пуст");
            else //3+N
            {
                for (uint i = Size; i > 0; --i)
                { //2+N
                    Console.WriteLine($" {i,2}) {array[i - 1]}"); //1
                    N_op += 1;
                }
                Console.WriteLine($"Размер стека равен {Size,3}"); //1
            }
        }

        public Stack() //конструктор по умолчанию
            //1+300=301
        {
            Size = 0;
            array = new int[300u];
        }

        public Stack(uint num) //конструктор, задающий кол-во элементов
            //1+N
        {
            Size = 0;
            array = new int[num];
        }

        public Stack(Stack stack) //конструктор для копирования стека
            //4+2N
        {
            array = new int[stack.array.Length]; //1+1+N
            stack.array.CopyTo(array, 0); //N
            Size = stack.Size; //2
            
        }

        private int this[uint index] //пеерегрузка оператора []
        {
            get //3+(5+2N)+(2+13N)+1=10+15N
            {
                N_op += 10;
                CheckPos(index); //3
                Stack copy = new Stack (this); //5+2N
                N_op += 2*(ulong)copy.array.Length;
                int result = 0; //1
                for (uint i = copy.Size; i >= index; --i) //1+1+13N
                {
                    N_op += 13;
                    result = copy.Pop(); //1+12
                }
                return result; //1
            }
            set //3+3+(2+N)+(1+21N)+12+9+(1+21N)=31+43N
            {
                N_op += 31;
                CheckPos(index); //3
                uint count=Size-index; //3
                Stack copy = new Stack(count); //2+N
                N_op+=(ulong)copy.array.Length;
                for (int i=0;i<count; ++i) //1+21N
                {
                    N_op += 21;
                    copy.Push(Pop()); //12+9
                }
                    
                Pop(); //12
                Push(value); //9
                for (uint i = 0; i < count; ++i) //1+21N
                  {
                    N_op += 21;
                    Push(copy.Pop()); //9+12
                  }
            }
        }

        public void BubbleSort () // сортировка пузырьком
        {
            int swap;
            for (uint i = 1; i < Size; ++i) //1+(2+(106+146N)N)N=1+2N+106N^2+146N^3
            {
                N_op += 1;
                for (uint j = i+1; j <= Size; ++j)//2+(106+146N)N
                {
                    N_op += 2;
                    if (this [i] > this [j]) //2*(10+15N)+1+(1+10+15N)+(1+(10+15N)+(31+43N))+(1+(31+43N))=20+30N+1+11+15N+11+15N+31+43N+1+31+43N=106+146N
                    {
                        N_op += 3;
                        swap = this[j]; //1+(10+15N)
                        this[j] = this[i]; //1+(10+15N)+(31+43N)
                        this [i] = swap; //1+(31+43N)
                    }
                }
            }
        }

    }
}
