using System;
using System.Collections.Generic;
using OPD_konstantinov;

int[,] values = {};
var sort = new BubbleSort();
string matrix = "";
int length1 = 0;
int length2 = 0;

Console.WriteLine("-----------------------");
Console.WriteLine("h - help---------------");
Console.WriteLine("i - input: 1 2 3, 1 2 3");
Console.WriteLine("s - sort---------------");
Console.WriteLine("--- q - minimum--------");
Console.WriteLine("--- w - maximum--------");
Console.WriteLine("--- e - summary--------");
Console.WriteLine("------- a - ask--------");
Console.WriteLine("------- d - desk-------");
Console.WriteLine("-----------------------");

while (true) {
    switch (char.ToLower(Console.ReadKey(true).KeyChar)) {
        case 'h':
            Console.WriteLine("-----------------------");
            Console.WriteLine("h - help---------------");
            Console.WriteLine("i - input: 1 2 3, 1 2 3");
            Console.WriteLine("s - sort---------------");
            Console.WriteLine("--- q - minimum--------");
            Console.WriteLine("--- w - maximum--------");
            Console.WriteLine("--- e - summary--------");
            Console.WriteLine("------- a - ask--------");
            Console.WriteLine("------- d - desk-------");
            Console.WriteLine("-----------------------");
            break;
        case 'i':
            Console.WriteLine("length1");
            Int32.TryParse(Console.ReadLine(), out length1);
            Console.WriteLine("length2");
            Int32.TryParse(Console.ReadLine(), out length2);
            values = new int[length1, length2];
            Console.WriteLine("matrix");
            matrix = Console.ReadLine();

            string[] tempMatrix = matrix.Split(", ");
            for (int i = 0; i < length1; i++) {
                string[] temp = tempMatrix[i].Split(' ');
                for (int j = 0; j < length2; j++) { 
                    values[i, j] = int.Parse(temp[j]);
                }
            }
            break;
        case 's':
            switch (char.ToLower(Console.ReadKey(true).KeyChar)) {
                case 'q':
                    switch (char.ToLower(Console.ReadKey(true).KeyChar)) {
                        case 'a':
                            sort.Sort(ref values, BubbleSort.MinimumRowElementSort, BubbleSort.Ask);
                            break;
                        case 'd':
                            sort.Sort(ref values, BubbleSort.MinimumRowElementSort, BubbleSort.Desc);
                            break;
                    }
                    break;
                case 'w':
                    switch (char.ToLower(Console.ReadKey(true).KeyChar))
                    {
                        case 'a':
                            sort.Sort(ref values, BubbleSort.MaximumRowElementSort, BubbleSort.Ask);
                            break;
                        case 'd':
                            sort.Sort(ref values, BubbleSort.MaximumRowElementSort, BubbleSort.Desc);
                            break;
                    }
                    break;
                case 'e':
                    switch (char.ToLower(Console.ReadKey(true).KeyChar))
                    {
                        case 'a':
                            sort.Sort(ref values, BubbleSort.SummaryRowSort, BubbleSort.Ask);
                            break;
                        case 'd':
                            sort.Sort(ref values, BubbleSort.SummaryRowSort, BubbleSort.Desc);
                            break;
                    }
                    break;
            }
            break;
    }
    Console.WriteLine("-----------------------");
    for (int i = 0; i < length1; i++)
    {
        for (int j = 0; j < length2; j++)
        {
            Console.Write("{0} ", values[i, j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine("-----------------------");
}

var timer = new CountDown();

var subscriberA = new Subscriber(timer, "Субскрубер А");
var subscriberB = new Subscriber(timer, "Субскрубер Б");
var subscriberC = new Subscriber(timer, "Субскрубер Ц");

timer.Skip(1000, "вот вам событие");
timer.Skip(1000, "вот вам второе событие");
subscriberA.Ubsubscribe();
timer.Skip(2000, "вот вам третье событие");
subscriberB.Ubsubscribe();
timer.Skip(1000, "вот вам четвертое событие");
subscriberC.Ubsubscribe();
timer.Skip(1000, "вот вам пятое событие");