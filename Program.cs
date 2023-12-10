



public static class Program 
{

    public static double RaiseToPow(double x, int power)
    {
        double res;
        int i;
        res = 1.0;
        if (power == 0)
        { return 1; }
        else if (power == 1)
        { return x; }
        else
            for (i = 1; i <= power; i++)
            { res = res * x; }
        return res;
    }
    public static void AlgwWait_unlim()//2.1
    {
        bool check = true;
        int error = 0;//Количество ошибок
        int numpack = 1;//Номер пакета
        int repack = 1;//Номер переотправляемого пакета
        int rptsnd = 0;//Счетчик повторных отправлений
        int result = 0;
        //int lasterrorpack = 0;//Последний ошибочно отправленный пакет
        Console.WriteLine("Алгоритм с ожиданием при бесконечном числе передач");
        //Вероятность ошибки в канале
        double p;
        Console.Write(" \n p = ");
        p = Convert.ToDouble(Console.ReadLine());
        //Задержка получения квитанции
        int tau;
        Console.Write(" \n tau = ");
        tau = Convert.ToInt16(Console.ReadLine());
        Console.Write("t Источник Приемник\n");

        Random prob = new Random();
        for (int i = 1; i < 400; i++)
        {
            if (check)
            { Console.Write($"{i}\t{numpack}\t0\n"); check = false; }
            double straightChannel = prob.NextDouble(); // Для ошибки в прямом канале}

            if (straightChannel < p) 
            {
                for (int j = 0; j < tau; j++)
                {
                    i++;
                    Console.Write($"{i}\t0\t-{numpack}\n");
                }
                i++;
                Console.Write($"{i}\t{numpack}\t0\n");
                if (rptsnd == 0)
                    error++;
                rptsnd++;
                i--;
            }
            else
            {
                for (int j = 0; j < tau; j++)
                {
                    i++;
                    Console.Write($"{i}\t0\t+{numpack}\n");
                }
                i++;
                numpack++;
                Console.Write($"{i}\t{numpack}\t0\n");
                result += rptsnd;
                repack++;
                rptsnd = 0;
                i--;
            }
        }
        Console.WriteLine($"Количество ошибок = {error}");
        Console.WriteLine($"Среднее число повторных передач = {Convert.ToDouble(result) / Convert.ToDouble(error)}");
    }

    public static void AlgwWait_lim()//2.2
    {
        bool check = true;
        int error = 0;//Количество ошибок
        int numpack = 1;//Номер пакета
        int repack = 1;//Номер переотправляемого пакета
        int rptsnd = 0;//Счетчик повторных отправлений
        int result = 0;
        //int lasterrorpack = 0;//Последний ошибочно отправленный пакет
        Console.WriteLine("Алгоритм с ожиданием при бесконечном числе передач");
        //Вероятность ошибки в канале
        double p;
        Console.Write(" \n p = ");
        p = Convert.ToDouble(Console.ReadLine());
        //Задержка получения квитанции
        int tau;
        Console.Write(" \n tau = ");
        tau = Convert.ToInt16(Console.ReadLine());
        //Ограничение количество повторных передач
        int N;
        Console.Write(" \n N = ");
        N = Convert.ToInt16(Console.ReadLine());
        Console.Write("t Источник Приемник\n");

        Random prob = new Random();
        for (int i = 1; i < 400; i++)
        {
            if (check)
            { Console.Write($"{i}\t{numpack}\t0\n"); check = false; }
            double straightChannel = prob.NextDouble(); // Для ошибки в прямом канале}
            if (rptsnd >= N)
            {
                if (straightChannel < p)
                {
                    for (int j = 0; j < tau; j++)
                    {
                        i++;
                        Console.Write($"{i}\t0\t-{numpack}\n");
                    }
                    i++; numpack++;
                    Console.Write($"{i}\t{numpack}\t0\n");
                    i--;
                    result += rptsnd;
                    repack++;
                    rptsnd = 0;
                }
                else
                {
                    for (int j = 0; j < tau; j++)
                    {
                        i++;
                        Console.Write($"{i}\t0\t+{numpack}\n");
                    }
                    i++;
                    numpack++;
                    Console.Write($"{i}\t{numpack}\t0\n");
                    i--;
                    result += rptsnd;
                    repack++;
                    rptsnd = 0;
                }
            }
            else if (straightChannel < p)
            {
                for (int j = 0; j < tau; j++)
                {
                    i++;
                    Console.Write($"{i}\t0\t-{numpack}\n");
                }
                i++;
                Console.Write($"{i}\t{numpack}\t0\n");
                if (rptsnd == 0)
                    error++;
                rptsnd++;
                i--;
            }
            else
            {
                for (int j = 0; j < tau; j++)
                {
                    i++;
                    Console.Write($"{i}\t0\t+{numpack}\n");
                }
                i++;
                numpack++;
                Console.Write($"{i}\t{numpack}\t0\n");
                result += rptsnd;
                repack++;
                rptsnd = 0;
                i--;
            }
        }
        Console.WriteLine($"Количество ошибок = {error}");
        Console.WriteLine($"Среднее число повторных передач = {Convert.ToDouble(result) / Convert.ToDouble(error)}");
    }
   
    public static void AlgWait_RevCh_unlim()//2.3.1
    {
        int error = 0; // Количество ошибок
        int numpack = 1; // Номер пакета
        //int repack = 0; // Общее количество повторных отправок
        bool check = true;
        int repack = 1;//Номер переотправляемого пакета
        int rptsnd = 0;//Счетчик повторных отправлений
        int result = 0;
        Console.WriteLine("Алгоритм с ожиданием при наличии ошибок в обратном канале");

        double p; //Вероятность ошибки в канале
        Console.Write(" \n p = ");
        p = Convert.ToDouble(Console.ReadLine());

        double p1; //Вероятность ошибки в обратном канале
        Console.Write(" \n p1 = ");
        p1 = Convert.ToDouble(Console.ReadLine());
        int tau;//Задержка получения квитанции
        Console.Write(" \n tau = ");
        tau = Convert.ToInt16(Console.ReadLine());
        /*
        int N; //Ограничение количества повторных передач
        Console.Write(" \n N = ");
        N = Convert.ToInt16(Console.ReadLine());
        */
        Console.Write("t Источник Приемник\n");
        Random prob = new Random();
        Random prob1 = new Random();

        // Console.Write($"{i}\t{numpack + "<-" + x + "- "}0\n");
        // Console.Write($"{i}\t0\t-{numpack}\n");
        // Console.Write($"{i}\t0\t+{numpack}\n");
        // Console.WriteLine($"Количество ошибок = {error}");
        // Console.WriteLine($"Среднее число повторных передач = {Convert.ToDouble(repack) / Convert.ToDouble(error)}");

        for (int i = 1; i < 400; i++)
        {
            // Сначала генерируем произойдет ли ошибка в прямом и обратном каналах.
            // Источник отправляет пакет, если пакет приходит с ошибкой, то на стороне получателя отображается номер пакета с минусом
            // После получения пакета получателем происходит ожидание в тау тиков. Если возникает ошибка в прямом канале, то источник получает отрицательную квитанцию
            // (вне зависимости от того, произошла ошибка в обратном канале или нет). Пакет переотправляется источником. Если ошибки в прямом канале не возникло - смотрим на ошибку
            // в обратном канале. Если она есть - визуально подчёркиваем это и отправляем пакет по новой со стороны отправителя.
            // Есть ограничение на отправку пакетов.
            // Пусть пока что нет ограничений.
            // Если ошибок не было - переходим к следующему пакету.

            if (check)
            { Console.Write($"{i}\t{numpack}\t0\n"); check = false; }
            double straightChannel = prob.NextDouble(); // Для ошибки в прямом канале
            double reverseChannel = prob1.NextDouble(); // Для ошибки в обратном канале

            /*bool errorStraightChannel = false;
            bool errorReverseChannel = false;*/

            if (straightChannel > p && reverseChannel > p1)
            {
                for (int j = 0; j < tau; j++)
                {
                    i++;
                    Console.Write($"{i}\t0\t+{numpack}\n");
                }
                i++;
                numpack++;
                Console.Write($"{i}\t{numpack + "<---"}\t0\n");
                result += rptsnd;
                repack++;
                rptsnd = 0;
                i--;
            }

            else if (straightChannel < p)
            {
                for (int j = 0; j < tau; j++)
                {
                    i++;
                    Console.Write($"{i}\t0\t-{numpack}\n");
                }
                i++;
                Console.Write($"{i}\t{numpack + "<---"}\t0\n");
                
                if (rptsnd == 0)
                    error++;
                rptsnd++;
                i--;
            }

            else 
            {
                for (int j = 0; j < tau; j++)
                {
                    i++;
                    Console.Write($"{i}\t0\t+{numpack}\n");
                }
                i++;
                Console.Write($"{i}\t{numpack + "<-X-"}\t0\n");
                if (rptsnd == 0) error++;
                    rptsnd++;
                i--;
            }
        }
        Console.WriteLine($"Количество ошибок = {error}");
        Console.WriteLine($"Среднее число повторных передач = {Convert.ToDouble(result) / Convert.ToDouble(error)}");

    
    }

    public static void AlgWait_RevCh_lim()//2.3.2
    {
        int error = 0; // Количество ошибок
        int numpack = 1; // Номер пакета
        //int repack = 0; // Общее количество повторных отправок
        bool check = true;
        int repack = 1;//Номер переотправляемого пакета
        int rptsnd = 0;//Счетчик повторных отправлений
        int result = 0;
        Console.WriteLine("Алгоритм с ожиданием при наличии ошибок в обратном канале");

        double p; //Вероятность ошибки в канале
        Console.Write(" \n p = ");
        p = Convert.ToDouble(Console.ReadLine());

        double p1; //Вероятность ошибки в обратном канале
        Console.Write(" \n p1 = ");
        p1 = Convert.ToDouble(Console.ReadLine());
        int tau;//Задержка получения квитанции
        Console.Write(" \n tau = ");
        tau = Convert.ToInt16(Console.ReadLine());
        //Ограничение количество повторных передач
        int N;
        Console.Write(" \n N = ");
        N = Convert.ToInt16(Console.ReadLine());
        Console.Write("t Источник Приемник\n");
        Random prob = new Random();
        Random prob1 = new Random();
        for (int i = 1; i < 400; i++)
        {
            double straightChannel = prob.NextDouble(); // Для ошибки в прямом канале
            double reverseChannel = prob1.NextDouble(); // Для ошибки в обратном канале
            if (check)
            { Console.Write($"{i}\t{numpack}\t0\n"); check = false; }
            if (rptsnd >= N)
            {
                if (straightChannel < p)
                {
                    for (int j = 0; j < tau; j++)
                    {
                        i++;
                        Console.Write($"{i}\t0\t-{numpack}\n");
                    }
                    numpack++;
                    Console.Write($"{i}\t{numpack+"<---"}\t0\n");
                    result += rptsnd;
                    repack++;
                    rptsnd = 0;
                    i--;
                }
                else
                {
                    if (reverseChannel < p1)
                    {
                        for (int j = 0; j < tau; j++)
                        {
                            i++;
                            Console.Write($"{i}\t0\t+{numpack}\n");
                        }
                        numpack++;
                        Console.Write($"{i}\t{numpack + "<-X-"}\t0\n");
                        result += rptsnd;
                        repack++;
                        rptsnd = 0;
                        i--;
                    }
                    else
                    {
                        for (int j = 0; j < tau; j++)
                        {
                            i++;

                            Console.Write($"{i}\t0\t+{numpack}\n");
                        }
                        i++;
                        numpack++;
                        Console.Write($"{i}\t{numpack + "<---"}\t0\n");
                        result += rptsnd;
                        repack++;
                        rptsnd = 0;
                        i--;
                    }
                }
            }
            
            else if (straightChannel > p && reverseChannel > p1)
            {
                for (int j = 0; j < tau; j++)
                {
                    i++;
                    Console.Write($"{i}\t0\t+{numpack}\n");
                }
                numpack++;
                i++;
                Console.Write($"{i}\t{numpack + "<---"}\t0\n");
                result += rptsnd;
                repack++;
                rptsnd = 0;
                i--;
            }

            else if (straightChannel < p)
            {
                for (int j = 0; j < tau; j++)
                {
                    i++;
                    Console.Write($"{i}\t0\t-{numpack}\n");
                }
                i++;
                Console.Write($"{i}\t{numpack + "<---"}\t0\n");
                if(rptsnd==0)
                    error++;
                rptsnd++;
                i--;
            }

            else
            {
                for (int j = 0; j < tau; j++)
                {
                    i++;
                    Console.Write($"{i}\t0\t+{numpack}\n");
                }
                i++;
                Console.Write($"{i}\t{numpack + "<-X-"}\t0\n");
                if (rptsnd == 0)
                    error++;
                rptsnd++;
                i--;
            }
        }
        Console.WriteLine($"Количество ошибок = {error}");
        Console.WriteLine($"Среднее число повторных передач = {Convert.ToDouble(result) / Convert.ToDouble(error)}");

    
    }
    public static void AlgWait()// 2.4 - Алгоритм с ожиданием
    {
        int error = 0;
        int numpack = 1;
        int timer = 0;
        Console.WriteLine("Алгоритм с возвратом");
        //Вероятность ошибки в канале
        double p;
        Console.Write(" \n p = ");
        p = Convert.ToDouble(Console.ReadLine());
        //Задержка получения квитанции
        int tau;
        Console.Write(" \n tau = ");
        tau = Convert.ToInt16(Console.ReadLine());
        Console.Write("t Источник Приемник\n");

        Random prob = new();
        for ( int i = 1; i < 200; i++)
        {
            double pr = Math.Round(prob.NextDouble(), 2);
            //Обработчик источника 
            if (timer == 0)
            {
                Console.Write($"{i}\t{numpack}\t0\n");
                timer = tau;
            }
            //Обработчик получателя
            else if (pr < p)// Если произошла ошибка в канале
            {
                error++;
                timer = tau;
                for (int j = 0; j < tau; j++)
                {
                    Console.Write($"{i}\t0\t-{numpack}\n");
                    i++;
                    timer--;
                }
                //Не увиличиваем номер пакета
                i--;
            }
            else //Если не произошла ошибка в канале
            {
                timer = tau;
                for (int j = 0; j < tau; j++)//ожидание
                {
                    Console.Write($"{i}\t0\t+{numpack}\n");
                    i++;
                    timer--;
                }
                numpack++;//отправляем следующий пакет
                i--;
            }
        }
        Console.WriteLine($"Количество ошибок = {error}");
        Console.WriteLine($"Коэффициент использования канала = {Convert.ToDouble(error) * Convert.ToDouble(tau+1) / 200}");
    }
    public static void AlgwRet()
    {
        int trans = 0;
        int numpack = 0;
        uint error = 0;
        Console.WriteLine("Алгоритм с возвратом");
        //Вероятность ошибки в канале
        double p;
        Console.Write(" \n p = ");
        p = Convert.ToDouble(Console.ReadLine());
        //Задержка получения квитанции
        int tau;
        Console.Write(" \n tau = ");
        tau = Convert.ToInt16(Console.ReadLine());
        Console.Write("t Источник Приемник\n");

        Random prob = new Random();
        int timer = -1; 

        for (int i = 1;i<300; i++)
        {
            double pr = Math.Round(prob.NextDouble(), 2);
                //При отсутствии ошибок номер пакета отправляемого источником соответствует времени
                if (error == 0)
                    trans = i;
                //При возникновении ошибки счетчик пакетов источника меняется
                else
                    trans++;
                //При отправке первого сообщения получатель ничего не обрабатывает
                if (i==1) 
                {
                    Console.Write($"{i}\t{trans}\t0\n");
                }
                //Источник не осознает, что возникла ошибка на протяжении тау времени
                else if(timer>0)
                {
                    Console.Write($"{i}\t{trans}\t-{numpack+1}\n");
                    timer--;
                }
                //Повторная отсылка не полученного пакета
                else if (timer == 0)
                {
                    trans = numpack;
                    Console.Write($"{i}\t{trans}\t-{numpack+2}\n");
                    timer--;
                }
                //Обычная отправка
                else
                {
                    //Возникновение ошибки 
                    if(pr<p)
                    {
                        Console.Write($"{i}\t{trans}\t-{trans-1}\n");
                        timer = tau - 1;
                        numpack = trans -1;
                        error++;
                    }
                    //отсутствие ошибок (получатель не знает что ему отправили)
                    else
                    {
                        Console.Write($"{i}\t{trans}\t+{trans-1}\n");
                    }
                }
        }
        double result = Convert.ToDouble(100 - error) / 100.00;
        Console.Write("Коэффициент использования канала - ");
        Console.Write(result);
        Console.WriteLine();
    }
    
    static void Main(string[] args)
    {
        //AlgwWait_unlim();
        //AlgwWait_lim();
        //AlgWait_RevCh_unlim();
        //AlgWait_RevCh_lim();
        //AlgWait();
        //AlgwRet();
    }
}