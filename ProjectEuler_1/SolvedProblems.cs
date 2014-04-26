using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;
using System.Collections;

namespace ProjectEuler_1
{
    class Solved
    {
        public static void Problem1()
        {
            int n = 1000;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                bool div3 = (i % 3 == 0);
                bool div5 = (i % 5 == 0);

                if (div3 && div5)
                {
                    Console.WriteLine("Both: " + i.ToString());
                    sum += i;
                }
                else if (div3)
                {
                    Console.WriteLine("By 3: " + i.ToString());
                    sum += i;
                }
                else if (div5)
                {
                    Console.WriteLine("By 5: " + i.ToString());
                    sum += i;
                }
            }
            Console.WriteLine("Sum: " + sum.ToString());
        }
        public static void Problem2()
        {
            long sum = 0;
            int term = 0;
            int result;

            while (true)
            {
                result = CachedFibonacci.Calculate(term++);
                if (result > 4000000)
                    break;
                if ((result & 1) == 0) //Is even
                    sum += (long)result;

                Console.WriteLine(result.ToString());
            }

            Console.WriteLine("Sum: " + sum.ToString());
        }
        public static void Problem3()
        {
            long number = 600851475143;// 13195;
            int currentLargest = -1;

            int toCheck = (int)Math.Ceiling(Math.Sqrt(number));
            for (int i = 1; i < toCheck; i += 2)
            {
                long remainder = number % i;

                if (remainder == 0 && Util.IsPrime__slow(i))
                {
                    Console.WriteLine("Prime divisor: " + i.ToString());
                    currentLargest = i;
                }
            }
        }
        public static void Problem4()
        {
            int largestProd = 0;

            for (int A = 99; A < 999; A++)
            {
                for (int B = 99; B < 999; B++)
                {
                    int prod = A * B;
                    if (Util.IsPalindrome(prod.ToString()))
                    {
                        Console.WriteLine(prod.ToString());
                        if (prod > largestProd)
                            largestProd = prod;
                    }
                }
            }
            Console.WriteLine("Largest: " + largestProd.ToString());
        }
        internal static void Problem5()
        {

            List<int> allDivisors = new List<int>();
            int max = 20;
            long multiple = 1;
            //for (int i = max; i > 1; i-- )
            for (int i = 1; i<= max; i++)
            {
                List<int> divisors = Util.PrimeFactorization(i);
                foreach (int ad in allDivisors)
                    divisors.Remove(ad); //Remove pre-existing copies

                foreach (int d in divisors)
                        allDivisors.Add(d); //Then add new ones.

            }

            allDivisors.Sort();
            allDivisors.Reverse();


            foreach (int d in allDivisors)
            {
                multiple *= d;

                bool alldivisible = true;
                for (int i = 1; i <= max; i++)
                {
                    if (multiple % i != 0)
                    {
                        alldivisible = false;
                        break;
                    }
                }
                if (alldivisible)
                    break;
            }

            Console.WriteLine("Smallest possible number that is evenly divisible: " + multiple.ToString());
            Console.WriteLine("Prime factorization of this number: ");
            foreach (int i in Util.PrimeFactorization(multiple))
                Console.WriteLine(i.ToString());
        }

        internal static void Problem6()
        {
            long sumofsq = 0;
            long sqofsum = 0;

            for (int i = 1; i <= 100; i++)
            {
                sumofsq += i * i;
                sqofsum += i;
            }
            sqofsum = sqofsum * sqofsum;

            long result = sqofsum - sumofsq;

            Console.WriteLine("Difference: " + result.ToString());
        }

        internal static void Problem7()
        {
            int prime = 0;
            for (int i = 1; i < int.MaxValue && prime < 10001; i++)
            {
                if (Util.IsPrime__slow(i))
                {
                    prime++;

                    Console.WriteLine(String.Format("{0,5}: {1} is prime", prime, i));

                }
            }
        }

        internal static void Problem8()
        {
            string input = "73167176531330624919225119674426574742355349194934" +
                            "96983520312774506326239578318016984801869478851843" +
                            "85861560789112949495459501737958331952853208805511" +
                            "12540698747158523863050715693290963295227443043557" +
                            "66896648950445244523161731856403098711121722383113" +
                            "62229893423380308135336276614282806444486645238749" +
                            "30358907296290491560440772390713810515859307960866" +
                            "70172427121883998797908792274921901699720888093776" +
                            "65727333001053367881220235421809751254540594752243" +
                            "52584907711670556013604839586446706324415722155397" +
                            "53697817977846174064955149290862569321978468622482" +
                            "83972241375657056057490261407972968652414535100474" +
                            "82166370484403199890008895243450658541227588666881" +
                            "16427171479924442928230863465674813919123162824586" +
                            "17866458359124566529476545682848912883142607690042" +
                            "24219022671055626321111109370544217506941658960408" +
                            "07198403850962455444362981230987879927244284909188" +
                            "84580156166097919133875499200524063689912560717606" +
                            "05886116467109405077541002256983155200055935729725" +
                            "71636269561882670428252483600823257530420752963450";

            int[] values = new int[input.Length];

            int multiplied = 1;
            int largest = 0;

            for (int i = 0; i < input.Length; i++)
            {
                values[i] = int.Parse(input.Substring(i, 1));
            }


            for (int i = 0; i < values.Length - 5; i++)
            {
                multiplied = 1;
                for (int j = i; j < i + 5; j++)
                {
                    multiplied *= values[j];
                }
                if (multiplied > largest)
                    largest = multiplied;

            }
            Console.WriteLine("Largest: " + largest.ToString());
        }

        internal static void Problem9()
        {
            for (int a = 0; a < 1000; a++)
            {
                for (int b = 0; b < 1000; b++)
                {
                    int c = 1000 - a - b;
                    int ls = a * a + b * b;
                    int rs = c * c;

                    if (ls == rs)
                        Console.WriteLine(String.Format("Found: A{0} B{1} C{2}; ABC{3}", a, b, c, a * b * c));
                }
            }
        }

        internal static void Problem10()
        {
            PrimesSieve ps = new PrimesSieve(2000010);
            long sum = 0;
            for (int i = 1; i < 2000001; i++)
            {
                if (ps.IsPrime(i))
                {
                    sum += i;
                    Console.WriteLine(String.Format("{0,15}: {1,7} is prime", sum, i));
                    

                }
            }
            Console.WriteLine("");
            Console.WriteLine(String.Format("Sum: {0}", sum));
        }

        internal static void Problem11()
        {
            string[] gridInput = new string[] { 
                "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08",
                "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00",
                "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65",
                "52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91",
                "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80",
                "24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50",
                "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70",
                "67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21",
                "24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72",
                "21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95",
                "78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92",
                "16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57",
                "86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58",
                "19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40",
                "04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66",
                "88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69",
                "04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36",
                "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16",
                "20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54",
                "01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48"
            };

            int[,] grid = new int[20, 20];
            int[,] counts = new int[20, 20];
            int col = 0;
            foreach (string line in gridInput)
            {
                int row = 0; 
                string[] parts = line.Split(new char[] { ' ' });
                foreach (string colPart in parts)
                {
                    grid[col, row] = int.Parse(colPart);
                    row++;
                }
                col++;
            }

            int maxVal = 0;

            for (int c = 0; c < 20; c++)
            {
                for (int r = 0; r < 20; r++)
                {
                    Console.Write(String.Format("{0,3} ", grid[c, r]));
                }
                Console.WriteLine("");
            }

            //Vertical
            for (int c = 0; c < 20; c++)
            {
                for (int r = 0; r <= 20 - 4; r++)
                {
                    int mult = 1;
                    for (int rx = r; rx < r + 4; rx++)
                    {
                        counts[c, rx]++;
                        mult *= grid[c, rx];
                    }
                    if (mult > maxVal)
                        maxVal = mult;
                }
            }

            Console.WriteLine("Vert:");
            for (int c = 0; c < 20; c++)
            {
                for (int r = 0; r < 20; r++)
                {
                    Console.Write(String.Format("{0,3} ", counts[c, r]));
                }
                Console.WriteLine("");
            }


            //Horizontal
            for (int r = 0; r < 20; r++) 
            {
                for (int c = 0; c <= 20 - 4; c++)
                {
                    int mult = 1;
                    for (int cx = c; cx < c + 4; cx++)
                    {
                        counts[cx, r]++;
                        mult *= grid[cx, r];
                    }
                    if (mult > maxVal)
                        maxVal = mult;
                }
            }

            Console.WriteLine("Horiz:");
            for (int c = 0; c < 20; c++)
            {
                for (int r = 0; r < 20; r++)
                {
                    Console.Write(String.Format("{0,3} ", counts[c, r]));
                }
                Console.WriteLine("");
            }

            //Forward slash
            for (int rc = 2; rc < 20 + 20 - 4; rc++)
            {
                int initialOffset = Math.Max(0, rc - 19);
                for (int offset = initialOffset; offset <= (rc - 3) - initialOffset ; offset++)
                {
                    int mult = 1;
                    for (int rcx = 0; rcx < 4; rcx++)
                    {
                        counts[rcx + offset, rc - rcx - offset]++;
                        mult *= grid[rcx + offset, rc - rcx - offset];
                    }
                    if (mult > maxVal)
                        maxVal = mult;
                }
            }

            Console.WriteLine("FW:");
            for (int c = 0; c < 20; c++)
            {
                for (int r = 0; r < 20; r++)
                {
                    Console.Write(String.Format("{0,3} ", counts[c, r]));
                }
                Console.WriteLine("");
            }

            //Backwards slash
            for (int rc = 2; rc < 20 + 20 - 4; rc++)
            {
                int initialOffset = Math.Max(0, rc - 19);
                for (int offset = initialOffset; offset <= (rc - 3) - initialOffset; offset++)
                {
                    int mult = 1;
                    for (int rcx = 0; rcx < 4; rcx++)
                    {
                        counts[rcx + offset, 19 - (rc - rcx - offset)]++;
                        mult *= grid[rcx + offset, 19 - (rc - rcx - offset)];
                    }
                    if (mult > maxVal)
                        maxVal = mult;
                }
            }

            Console.WriteLine("BW:");
            for (int c = 0; c < 20; c++)
            {
                for (int r = 0; r < 20; r++)
                {
                    Console.Write(String.Format("{0,3} ", counts[c, r]));
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Max 4: " + maxVal.ToString());
        }

        internal static void Problem12()
        {
            int desiredFactors = 500;
            for (int i = 0; i < int.MaxValue; i++)
            {
                long tri = Util.TriangleNumber(i);

                List<long> factors = Util.Divisors(tri);
                if (factors.Count > desiredFactors || i % 1000 == 0)
                {
                    Console.Write(String.Format("#{0} Triangle number is {1} and has {2} factors: ", i, tri, factors.Count));
                    //foreach(int factor in factors)
                    //    Console.Write(String.Format("{0}x", factor));
                    Console.WriteLine("");
                }

                if (factors.Count > desiredFactors)
                    break;

            }
            Console.WriteLine("Finished");
        }

        internal static void Problem13()
        {
#region input
            double[] input = new double[100] { 
                37107287533902102798797998220837590246510135740250d,
                46376937677490009712648124896970078050417018260538d,
                74324986199524741059474233309513058123726617309629d,
                91942213363574161572522430563301811072406154908250d,
                23067588207539346171171980310421047513778063246676d,
                89261670696623633820136378418383684178734361726757d,
                28112879812849979408065481931592621691275889832738d,
                44274228917432520321923589422876796487670272189318d,
                47451445736001306439091167216856844588711603153276d,
                70386486105843025439939619828917593665686757934951d,
                62176457141856560629502157223196586755079324193331d,
                64906352462741904929101432445813822663347944758178d,
                92575867718337217661963751590579239728245598838407d,
                58203565325359399008402633568948830189458628227828d,
                80181199384826282014278194139940567587151170094390d,
                35398664372827112653829987240784473053190104293586d,
                86515506006295864861532075273371959191420517255829d,
                71693888707715466499115593487603532921714970056938d,
                54370070576826684624621495650076471787294438377604d,
                53282654108756828443191190634694037855217779295145d,
                36123272525000296071075082563815656710885258350721d,
                45876576172410976447339110607218265236877223636045d,
                17423706905851860660448207621209813287860733969412d,
                81142660418086830619328460811191061556940512689692d,
                51934325451728388641918047049293215058642563049483d,
                62467221648435076201727918039944693004732956340691d,
                15732444386908125794514089057706229429197107928209d,
                55037687525678773091862540744969844508330393682126d,
                18336384825330154686196124348767681297534375946515d,
                80386287592878490201521685554828717201219257766954d,
                78182833757993103614740356856449095527097864797581d,
                16726320100436897842553539920931837441497806860984d,
                48403098129077791799088218795327364475675590848030d,
                87086987551392711854517078544161852424320693150332d,
                59959406895756536782107074926966537676326235447210d,
                69793950679652694742597709739166693763042633987085d,
                41052684708299085211399427365734116182760315001271d,
                65378607361501080857009149939512557028198746004375d,
                35829035317434717326932123578154982629742552737307d,
                94953759765105305946966067683156574377167401875275d,
                88902802571733229619176668713819931811048770190271d,
                25267680276078003013678680992525463401061632866526d,
                36270218540497705585629946580636237993140746255962d,
                24074486908231174977792365466257246923322810917141d,
                91430288197103288597806669760892938638285025333403d,
                34413065578016127815921815005561868836468420090470d,
                23053081172816430487623791969842487255036638784583d,
                11487696932154902810424020138335124462181441773470d,
                63783299490636259666498587618221225225512486764533d,
                67720186971698544312419572409913959008952310058822d,
                95548255300263520781532296796249481641953868218774d,
                76085327132285723110424803456124867697064507995236d,
                37774242535411291684276865538926205024910326572967d,
                23701913275725675285653248258265463092207058596522d,
                29798860272258331913126375147341994889534765745501d,
                18495701454879288984856827726077713721403798879715d,
                38298203783031473527721580348144513491373226651381d,
                34829543829199918180278916522431027392251122869539d,
                40957953066405232632538044100059654939159879593635d,
                29746152185502371307642255121183693803580388584903d,
                41698116222072977186158236678424689157993532961922d,
                62467957194401269043877107275048102390895523597457d,
                23189706772547915061505504953922979530901129967519d,
                86188088225875314529584099251203829009407770775672d,
                11306739708304724483816533873502340845647058077308d,
                82959174767140363198008187129011875491310547126581d,
                97623331044818386269515456334926366572897563400500d,
                42846280183517070527831839425882145521227251250327d,
                55121603546981200581762165212827652751691296897789d,
                32238195734329339946437501907836945765883352399886d,
                75506164965184775180738168837861091527357929701337d,
                62177842752192623401942399639168044983993173312731d,
                32924185707147349566916674687634660915035914677504d,
                99518671430235219628894890102423325116913619626622d,
                73267460800591547471830798392868535206946944540724d,
                76841822524674417161514036427982273348055556214818d,
                97142617910342598647204516893989422179826088076852d,
                87783646182799346313767754307809363333018982642090d,
                10848802521674670883215120185883543223812876952786d,
                71329612474782464538636993009049310363619763878039d,
                62184073572399794223406235393808339651327408011116d,
                66627891981488087797941876876144230030984490851411d,
                60661826293682836764744779239180335110989069790714d,
                85786944089552990653640447425576083659976645795096d,
                66024396409905389607120198219976047599490197230297d,
                64913982680032973156037120041377903785566085089252d,
                16730939319872750275468906903707539413042652315011d,
                94809377245048795150954100921645863754710598436791d,
                78639167021187492431995700641917969777599028300699d,
                15368713711936614952811305876380278410754449733078d,
                40789923115535562561142322423255033685442488917353d,
                44889911501440648020369068063960672322193204149535d,
                41503128880339536053299340368006977710650566631954d,
                81234880673210146739058568557934581403627822703280d,
                82616570773948327592232845941706525094512325230608d,
                22918802058777319719839450180888072429661980811197d,
                77158542502016545090413245809786882778948721859617d,
                72107838435069186155435662884062257473692284509516d,
                20849603980134001723930671666823555245252804609722d,
                53503534226472524250874054075591789781264330331690d
            };
#endregion

            List<double> sorted = input.ToList();
            sorted.Sort();
            double result = 0;
            foreach (double d in sorted)
            {
                result += d;
            }
            Console.WriteLine("{0}", result);
        }

        internal static void Problem14()
        {
            CachedCollatzLengths ccl = new CachedCollatzLengths();

            int longest = 0;
            long starting = -1;

            for (long i = 1; i < 1000000; i++)
            {
                int len = ccl.CollatzLength(i);
                if (len > longest)
                {
                    longest = len;
                    starting = i;
                }
            }

            Console.WriteLine("longest collatz: " + longest.ToString() + " starts at " + starting.ToString());
        }

        internal static void Problem15()
        {
            int size = 21;
            long?[,] grid = new long?[size, size];
            Array.Clear(grid, 0, size * size);

            ComputeRoutes(size, grid, 0, 0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(String.Format("{0,12} ", grid[i, j]));
                }
                Console.WriteLine("");
            }
        }

        private static void ComputeRoutes(int size, long?[,] grid, int x, int y)
        {
            long xsum = 0;
            bool xAvail = false;
            bool yAvail = false;
            long ysum = 0;

            if (x < size - 1)
            {
                if (!grid[x, y].HasValue)
                    ComputeRoutes(size, grid, x + 1, y);

                xsum += grid[x+1, y].Value;
                xAvail = true;
            }

            if (y < size - 1)
            {
                if (!grid[x, y].HasValue)
                    ComputeRoutes(size, grid, x, y + 1);

                ysum += grid[x, y + 1].Value;
                yAvail = true;
            }
            else
            {
            }

            long sum = xsum + ysum;
            if (xAvail && yAvail)
            {
                //sum += 2;
            }
            else if (xAvail || yAvail)
            {
                //sum += 1;
            }
            else
            {
                sum = 1;
            }
            grid[x, y] = sum;

            //if (grid[x, y].HasValue)
            //{
            //    grid[x, y] += sum;
            //}
            //else
            //{
            //    grid[x, y] = sum;
            //}

            
        }

        internal static void Problem16()
        {
            BigInteger bi = new System.Numerics.BigInteger();

            bi = 1;
            bi = bi << 1000;
            BigInteger sum = 0;

            while (bi > 0)
            {
                BigInteger rem;
                bi = BigInteger.DivRem(bi, (BigInteger)10, out rem);
                sum += rem;
            }
            Console.WriteLine("Sum: " + sum.ToString());
        }

        internal static void Problem17()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 1000; i++)
            {
                string ith = Util.Spell(i);
                //Console.WriteLine(ith);
                sb.Append(ith);
                sb.Append(" ");

                //if (i % 100 == 0)
                //    Console.ReadKey();
            }
            //Console.WriteLine(sb.ToString());
            Console.WriteLine(sb.ToString().Replace(" ", "").Length);
        }

        internal static void Problem18()
        {
            string[] lines = File.ReadAllLines("../../P67.txt");

            int depth = lines.Length;
            int[,] array = new int[lines.Length, lines.Length];
            int[,] sums = new int[lines.Length, lines.Length];

            int linenum = 0;
            foreach (string line in lines)
            {
                int partnum = 0;
                string[] parts = line.Split(new char[] { ' ' });
                foreach (string part in parts)
                {
                    int num = int.Parse(part);
                    array[partnum, linenum] = num;
                    //Console.Write(array[partnum, linenum].ToString() + " ");
                    //Console.WriteLine(linenum.ToString() + " " + partnum.ToString());
                    partnum++;
                }
                linenum++;
            }


           


            for (int line = 0; line < depth; line++)
            {

                if (line == 0)
                {
                    sums[0, line] = array[0, line];
                }
                else
                {

                    for (int col = 0; col <= line; col++)
                    {
                        int largestval = 0;

                        int colA = col - 1;
                        int colB = col;

                        if (colA >= 0)
                            if (sums[colA, line - 1] > largestval)
                                largestval = sums[colA, line - 1];
                        if (colB <= line - 1)
                            if (sums[colB, line - 1] > largestval)
                                largestval = sums[colB, line - 1];

                        sums[col, line] = array[col, line] + largestval;
                    }
                }

            }


            for (int line = 0; line < depth; line++)
            {
                for (int col = 0; col <= line; col++)
                {
                    Console.Write(String.Format("{0,4} ", array[col, line]));
                }
                Console.WriteLine("");
            }

            for (int line = 0; line < depth; line++)
            {
                for (int col = 0; col <= line; col++)
                {
                    Console.Write(String.Format("{0,4} ", sums[col, line]));
                }
                Console.WriteLine("");
            }


            int largest = 0;
            for (int col = 0; col < depth; col++)
            {
                if (sums[col, depth - 1] > largest)
                    largest = sums[col, depth - 1];
            }
            Console.WriteLine("Largest: " + largest.ToString());
            
        }

        internal static void Problem19()
        {
            int day = 0;
            int year = 1901;
            int numSundays = 0;

            //Day zero is a Monday.
            //Sundays happen on Day % 7 == 0
            while (true)
            {
                bool leapYear = (year % 4) == 0;
                if((year % 100) == 0)
                    leapYear = false;
                if((year % 400) == 0)
                    leapYear = true;

                if ((day % 7) == 0)
                    numSundays++;
                day += 31; //Jan

                if ((day % 7) == 0)
                    numSundays++;
                if (leapYear)
                    day += 29; //Feb
                else
                    day += 28; //Feb

                if ((day % 7) == 0)
                    numSundays++;
                day += 31; //March

                if ((day % 7) == 0)
                    numSundays++;
                day += 30; //April

                if ((day % 7) == 0)
                    numSundays++;
                day += 31; //May

                if ((day % 7) == 0)
                    numSundays++;
                day += 30; //June

                if ((day % 7) == 0)
                    numSundays++;
                day += 31; //July

                if ((day % 7) == 0)
                    numSundays++;
                day += 31; //Aug

                if ((day % 7) == 0)
                    numSundays++;
                day += 30; //Sept

                if ((day % 7) == 0)
                    numSundays++;
                day += 31; //Oct

                if ((day % 7) == 0)
                    numSundays++;
                day += 30; //November

                if ((day % 7) == 0)
                    numSundays++;
                day += 31; //Dec

                if (year == 2000)
                    break;

                year++;
            }

            
            for (int i = 0; i < day; i++)
            {
                
            }

            Console.WriteLine("Days: " + day.ToString());
            Console.WriteLine("Sundays: " + numSundays.ToString());
        }

        internal static void Problem20()
        {

            BigInteger bi = new System.Numerics.BigInteger();

            bi = 1;
            for (int i = 1; i <= 100; i++)
                bi *= i;


            BigInteger sum = 0;
            while (bi > 0)
            {
                BigInteger rem;
                bi = BigInteger.DivRem(bi, (BigInteger)10, out rem);
                sum += rem;
            }
            Console.WriteLine("Sum: " + sum.ToString());
        }

        internal static void Problem21()
        {
            int count = 10000;
            int[] sumOfDivisors = new int[count];

            for (int i = 0; i < count; i++)
            {
                int sum = 0;
                //Console.Write(i.ToString() + ": ");
                foreach (int div in Util.ProperDivisors(i))
                {
                    sum += div;
                    //Console.Write(div.ToString() + " ");
                }
                sumOfDivisors[i] = sum;
                //Console.WriteLine("");
            }

            List<int> HalfOfAmicable = new List<int>();
            for (int i = 0; i < count; i++)
            {
                if (HalfOfAmicable.Contains(i))
                    continue;

                int potentialOtherHalf = sumOfDivisors[i];
                if (potentialOtherHalf >= 0 && potentialOtherHalf < count)
                {
                    if (sumOfDivisors[potentialOtherHalf] == i && potentialOtherHalf != i)
                    {
                        HalfOfAmicable.Add(potentialOtherHalf);
                        Console.WriteLine(String.Format("{0} -> {1}", i, sumOfDivisors[i]));
                        Console.WriteLine(String.Format("{0} -> {1}", potentialOtherHalf, sumOfDivisors[potentialOtherHalf]));
                        Console.WriteLine("");
                    }
                }
            }

            int sumOfAmbicables = 0;
            foreach(int i in HalfOfAmicable)
            {
                sumOfAmbicables += i;
                sumOfAmbicables += sumOfDivisors[i];
            }

            Console.WriteLine("Sum: " + sumOfAmbicables.ToString());

        }

        internal static void Problem22()
        {
            string allnames = File.ReadAllText("../../P22.txt");
            allnames = allnames.Replace("\"", "");
            string[] names = allnames.Split(new char[] { ',' });
            List<string> namesSorted = names.ToList();

            namesSorted.Sort();

            int position = 1;
            int totalScore = 0;

            foreach (string name in namesSorted)
            {
                int value = 0;
                foreach (char c in name)
                {
                    value += c - 'A' + 1;
                }

                Console.WriteLine(String.Format("{0,10}: {1,5} * {2,5} = {3,5}", name, position, value, position * value));
                totalScore += position * value;

                position++;
            }

            Console.WriteLine("Total score: " + totalScore.ToString());
        }

        internal static void Problem23()
        {
            HashSet<int> abundants = new HashSet<int>();
            for (int i = 0; i < 28123; i++)
            {
                int sod = 0;
                foreach (int div in Util.ProperDivisors(i))
                {
                    sod += div;
                }
                if (sod > i)
                {
                    //Console.WriteLine("{0} -> {1}", i, sod);
                    abundants.Add(i);
                }

            }

            long SumOfCantBeWrittenAsSumOfTwoAbundants = 0;
            for (int i = 0; i < 28123; i++)
            {
                bool canBeWrittenAsSumOfTwoAbundants = false;
                foreach (int ab1 in abundants)
                {
                    if (ab1 > i)
                        break;

                    int ab2 = i - ab1;
                    if (abundants.Contains(ab2))
                    {
                        Console.WriteLine("{0,5} = {1,5} + {2,5}", i, ab1, ab2);
                        canBeWrittenAsSumOfTwoAbundants = true;
                        break;
                    }
                }

                if(!canBeWrittenAsSumOfTwoAbundants)
                    SumOfCantBeWrittenAsSumOfTwoAbundants += i;

            }
            Console.WriteLine("Sum: " + SumOfCantBeWrittenAsSumOfTwoAbundants.ToString());

        }

        internal static void Problem24()
        {
            int idx = 0;
            List<int> input = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9});
            foreach (List<int> subsetPermuted in Util.Permute(input))
            {
                idx++;

                if (idx > 999995)
                {
                    Console.Write(idx.ToString() + ": ");

                    foreach (int i in subsetPermuted)
                        Console.Write(i.ToString() + " ");
                    Console.WriteLine("");
                }

                if (idx > 1000000)
                    break;
            }
            Console.WriteLine("Done!");
        }

        internal static void Problem25()
        {
            int term = 2;
            BigInteger n;
            BigInteger nm1 = 1;
            BigInteger nm2 = 1;
            BigInteger target = 1;
            for (int i = 1; i < 1000; i++)
                target *= 10;
            while(true)
            {
                n = nm1 + nm2;
                nm2 = nm1;
                nm1 = n;
                term++;

                if (n > target)
                    break;
            }
            Console.WriteLine(term.ToString());
            Console.WriteLine(n.ToString());
        }

        internal static void Problem26_FailedButInteresting()
        {
            //Failed to produce correct answer, because a double doesn't have enough mantissa!
            int largestCount2 = 0;
            int intOfLargestCount2 = -1;

            for (int digitsToTest = 10; digitsToTest < 30; digitsToTest++)
            {

                int largestCount = 0;
                int intOfLargestCount = -1;

                for (int i = 2; i < 1000; i++)
                {
                    double d = 1 / (double)i;
                    List<int> decimals = new List<int>();
                    for (int dig = 0; dig < digitsToTest; dig++)
                    {
                        d *= 10;
                        int digit = (int)d;
                        d -= digit;
                        decimals.Add(digit);
                    }

                    decimals.Reverse();
                    while (decimals[0] == 0)
                        decimals.RemoveAt(0);

                    if (i == 3)
                    {
                    }
                    //decimals.Reverse();

                    int largestCountThisNumber = 0;
                    for (int repeatLength = 1; repeatLength < decimals.Count; repeatLength++)
                    {
                        //int countThisRepeatLength = 0;

                        for (int dig = 0; dig < decimals.Count; dig++)
                        {
                            if (decimals[dig % repeatLength] != decimals[dig])
                                break;
                            else
                            {
                                if (dig >= 10 && dig >= 2 * repeatLength)
                                {
                                    if (largestCountThisNumber == 0 || (repeatLength % largestCountThisNumber) != 0)
                                    {
                                        largestCountThisNumber = repeatLength;
                                        double fra = 1 / (double)i;
                                        //Console.WriteLine("{0}  ({1,20}) has repeat length {2}", i, fra.ToString("R"), repeatLength);
                                        break;
                                    }
                                }
                            }

                        }
                        // if (largestCountThisNumber > 0)
                        //    break;
                        //if(countThisRepeatLength > 1)
                        //largestCountThisNumber = repeatLength;
                    }

                    if (largestCountThisNumber > largestCount)
                    {
                        largestCount = largestCountThisNumber;
                        intOfLargestCount = i;
                    }


                }

                double fr = 1 / (double)intOfLargestCount;
                Console.WriteLine("{0}  ({1,20}) has repeat length {2}", intOfLargestCount, fr.ToString("R"), largestCount);

                if (largestCount > largestCount2)
                {
                    largestCount2 = largestCount;
                    intOfLargestCount2 = intOfLargestCount;
                }

            }

            double fr2 = 1 / (double)intOfLargestCount2;
            Console.WriteLine("Longest {0}  ({1,20}) has repeat length {2}", intOfLargestCount2, fr2.ToString("R"), largestCount2);
        }

        internal static void Problem26()
        {
            int longestRepeating = 0;
            int longestRepeatingCount = 0;
            //Long division: 1 is dividend, i is the divisor. Long divide until we repeat steps
            for (int i = 1; i < 1000; i++)
            {
                if (i % 100 == 0)
                    Console.ReadKey();

                List<int> dividedSteps = new List<int>();

                int repeatedLength = 0;
                int dividend = 1;
                int divisor = i;
                StringBuilder quotient = new StringBuilder("");
                while (true)
                {
                    if (dividend == 0)
                    {
                        //quotient.Insert(1, '.');
                        //Console.WriteLine("n/a: {0}", quotient.ToString());
                        break;
                    }
                    

                    if (dividedSteps.Contains(dividend))
                    {
                        repeatedLength = dividedSteps.Count - dividedSteps.IndexOf(dividend);
                        

                        if (repeatedLength > longestRepeatingCount)
                        {
                            longestRepeatingCount = repeatedLength;
                            longestRepeating = i;
                        }


                        //add the repeated digits once, so we can look at them :)
                        int currentLen = dividedSteps.Count;
                        for (int idx = dividedSteps.IndexOf(dividend); idx < currentLen; idx++)
                            quotient.Append(quotient[idx]);

                        quotient.Insert(1, '.');//Insert the decimal place

                        double fr = 1 / (double)i;
                        Console.WriteLine("1/{0} = {1}", i, fr.ToString("R"));

                        Console.WriteLine("{0}: {1}", repeatedLength, quotient.ToString());
                        Console.WriteLine("");
                        break;
                    }
                    dividedSteps.Add(dividend);

                    int rem;
                    int quot = Math.DivRem(dividend, divisor, out rem);
                    quotient.Append((char)(quot + '0'));

                    dividend = dividend - (quot * divisor);

                    dividend *= 10;
                }

            }
            Console.WriteLine("1/{0} has the longest repetition: {1} digits", longestRepeating, longestRepeatingCount);
        }

        internal static void Problem27()
        {
            PrimesSieve primes = new PrimesSieve(3000000);

            int prodOfLargest = -1;
            long largestPrimeLength = 0;

            for (int a = -1000; a <= 1000; a++)
            {
                for (int b = -1000; b <= 1000; b++)
                {
                    long primeLength = 0;
                    for (long n = 0; n < 5000; n++)
                    {
                        long res = n * n + a * n + b;
                        if ((int)res <= 0)
                        {
                            break;
                        }
                        if (!primes.IsPrime((int)res))
                        {
                            primeLength = n - 1;
                            break;
                        }
                    }

                    if (primeLength > largestPrimeLength)
                    {
                        largestPrimeLength = primeLength;
                        prodOfLargest = a * b;
                        Console.WriteLine("n^2 + {1}xn + {2} makes primes from 0 to {0}", primeLength, a, b);
                    }

                }
            }
            Console.WriteLine("Largest prod is {0}", prodOfLargest);
        }

        internal static void Problem28()
        {
            List<List<int>> spiralSquares = new List<List<int>>();

            int current = 1;
            int n = 1001; //For an nxn grid
            for(int i = 1; i <= n; i+= 2)
            {
                List<int> square = new List<int>();

                int num = (i == 1) ? 1 : 4 * (i - 1);
                for (int idx = 0; idx < num; idx++)
                {
                    square.Add(current++);
                }
                //1: ?   //1
                //3: 4x2 //2-9
                //5: 4x4 //10-25
                //7: 4x6
               
                spiralSquares.Add(square);
            }

            int sumOfDiagonals = 0;
            foreach (List<int> square in spiralSquares)
            {
                int count = square.Count;
                if (count == 1)
                {
                    sumOfDiagonals += square[0];
                }
                else
                {
                    Console.Write("Diagonals of square with count {0}: ", count);
                    count = count / 4;
                    for(int i=square.Count - 1; i>0; i-= count)
                    {
                        Console.Write("{0}, ", square[i]);
                        sumOfDiagonals += square[i];
                    }
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("Sum of diagonals is {0}", sumOfDiagonals);
        }

        internal static void Problem29()
        {
            List<List<int>> pairs = new List<List<int>>();
            int count = 0;

            int max = 100;
            for (int a = 2; a <= max; a++)
            {
                for (int b = 2; b <= max; b++)
                {
                    int finalA = a;
                    int finalB = b;

                    int largestRoot = 1;
                    for (int root = 1; root < 10; root++)
                    {
                        double newA = Math.Pow(a, 1 / (double)root);

                        int roundedNewA = (int)Math.Round(newA);

                        if (Math.Abs(newA - roundedNewA) < 1e-5)
                        {
                            largestRoot = root;
                            finalA = roundedNewA;
                            finalB = b * root;
                        }
                    }

                    bool found = false;
                    foreach (List<int> pair in pairs)
                    {
                        if (pair[0] == finalA && pair[1] == finalB)
                        {
                            Console.WriteLine("I think that {0}^{1} == {2}^{3}", pair[0], pair[1], a, b);
                            found = true; 
                            break;
                        }
                    }


                    if (!found)
                    {
                        count++;
                        pairs.Add(new List<int>() { finalA, finalB });
                    }
                }
            }

            //if (pairs.Count < 1000)
            //{
            //    SortedSet<long> ss = new SortedSet<long>();
            //    foreach (List<int> pair in pairs)
            //    {
            //        long res = (long)Math.Pow(pair[0], pair[1]);
            //        if (ss.Contains(res))
            //        {
            //            count--;
            //        }
            //        else
            //        {
            //            ss.Add(res);
            //        }
            //    }

            //    foreach (long s in ss)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
            Console.WriteLine("Unique powers: " + count.ToString());
        }

        internal static void Problem30()
        {
            int power = 5;
            int[] powers = new int[10];
            for (int dig = 0; dig < 10; dig++)
            {
                powers[dig] = (int)Math.Pow(dig, power);
                Console.WriteLine("{0}^{1} = {2}", dig, power, powers[dig]);
            }

            Console.WriteLine("");

            int sumOfNumbers = 0;
            for (int i = 2; i < int.MaxValue; i++)
            {
                if (i % 10000 == 0)
                    Console.Write(".");

                int sumOfDigits = 0;
                string rep = i.ToString();
                foreach (char c in rep)
                {
                    sumOfDigits += powers[c - '0'];
                }

                if (sumOfDigits == i)
                {
                    Console.WriteLine("{0} can be written as sum of {1}th power of its digits", sumOfDigits, power);

                    sumOfNumbers += i;
                }

                int numDig = rep.Length;
                int maxSum = powers[9] * numDig;
                if (i > maxSum)
                {
                    Console.WriteLine("Stopped at {0}", i);
                    break;
                }
            }
            Console.WriteLine("Sum of above numbers: {0}", sumOfNumbers);
        }

        internal static void Problem31()
        {
            List<int> penceCoins = new List<int>() { 1, 2, 5, 10, 20, 50, 100, 200 };
            int pence = 200;

            penceCoins.Sort();
            penceCoins.Reverse();

            foreach (List<int> change in Util.ChangePossibilities(pence, penceCoins, new List<int>()))
            {
                foreach (int coin in change)
                {
                    Console.Write("{0}p ", coin);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Count: {0}", Util.ChangePossibilities(pence, penceCoins, new List<int>()).Count());
        }

        internal static void Problem32()
        {
            //April 23, 2014
            HashSet<int> pandigitalProducts = new HashSet<int>();
            HashSet<char> digits = new HashSet<char>() { '9', '8', '7', '6', '5', '4', '3', '2', '1' };

            for (int lenA = 1; lenA < 5; lenA++)
            {
                for (int lenB = lenA; lenB < 5; lenB++)
                {
                    int lenProd = 9 - lenA - lenB;

                    int prodMax = (int)Math.Pow(10, lenProd);
                    int prodMin = (int)(prodMax * 0.12);

                    int maxProd = (int)(Math.Pow(10, lenA) * Math.Pow(10, lenB));
                    int minProd = (int)(Math.Pow(10, lenA) * Math.Pow(10, lenB) * 0.13 * 0.20);

                    Console.WriteLine("{4}x{5}={6}: [{0}, {1}]; [{2}, {3}]", prodMin, prodMax, minProd, maxProd, lenA, lenB, lenProd);


                    int min = Math.Max(prodMin, minProd);
                    int max = Math.Min(prodMax, maxProd);

                    for (int prod = min; prod < max; prod++)
                    {
                        bool productContainsRepeats = false;
                        HashSet<char> digits2 = new HashSet<char>(digits);
                        foreach (char c in prod.ToString())
                        {
                            if (digits2.Contains(c))
                                digits2.Remove(c);
                            else
                                productContainsRepeats = true;
                        }

                        if (productContainsRepeats)
                            continue;

                        List<long> divisors = Util.ProperDivisors(prod);

                        foreach (long divisor in divisors)
                        {
                            int len = divisor.ToString().Length;
                            if (len == lenA || len == lenB)
                            {
                                HashSet<char> digits3 = new HashSet<char>(digits2);
                                bool failed = false;

                                long matingDivisor = prod / divisor;
                                int matingLen = matingDivisor.ToString().Length;

                                if ((len == lenA && matingLen == lenB) || 
                                    (len == lenB && matingLen == lenA))
                                {
                                    foreach (char c in divisor.ToString())
                                    {
                                        if (digits3.Contains(c))
                                            digits3.Remove(c);
                                        else
                                        {
                                            failed = true;
                                            break;
                                        }
                                    }

                                    foreach (char c in matingDivisor.ToString())
                                    {
                                        if (digits3.Contains(c))
                                            digits3.Remove(c);
                                        else
                                        {
                                            failed = true;
                                            break;
                                        }
                                    }

                                    if (failed)
                                        continue;
                                    else
                                    {
                                        Console.WriteLine("{0,4} x {1,4} = {2,4} is 1-9 pandigital", divisor, matingDivisor, prod);
                                        pandigitalProducts.Add(prod);
                                    }
                                    
                                }
                            }
                        }
                    }
                    
                    
                    


                }
            }

            int sumOfPandigitalProducts = 0;
            foreach (int i in pandigitalProducts)
                sumOfPandigitalProducts += i;

            Console.WriteLine(sumOfPandigitalProducts);

              
        }

        internal static void Problem33()
        {
            //April 23, 2014
            for (int den = 2; den < 100; den++)
            {
                if (den % 10 == 0)
                    continue;

                int L = den % 10;
                int H = den / 10;

                if (L == H)
                    continue;

                if (den == 98)
                {
                }

                int num;
                //Assume L is cancelled
                //num / den == H / NL if num * NL == H * den
                for (int NL = 0; NL < 10; NL++)
                {
                    num = H * 10 + NL;
                    if (num * L == NL * den && num < den && num * L > 0)
                    {
                //        Console.WriteLine("Curious - {0}/{1} == {2}/{3}", num, den, NL, H);
                    }

                    num = NL * 10 + H;
                    if (num * L == NL * den && num < den && num * L > 0)
                    {
                        Console.WriteLine("Curious - {0}/{1} == {2}/{3}", num, den, NL, L);
                    }
                }

                //Assume H is cancelled
                //num / den == L / NL if num * NL == L * den
                for (int NL = 0; NL < 10; NL++)
                {
                    num = L * 10 + NL;
                    if (num * H == NL * den && num < den && num * H > 0)
                    {
                        Console.WriteLine("Curious - {0}/{1} == {2}/{3}", num, den, NL, L);
                    }

                    num = NL * 10 + L;
                    if (num * H == NL * den && num < den && num * H > 0)
                    {
                        Console.WriteLine("Curious - {0}/{1} == {2}/{3}", num, den, NL, L);
                    }
                }

                //for (int num = 1; num < den; num++)
                //{
                //    string n = num.ToString();
                //}


                
            }

            int num2 = 16 * 26 * 19 * 49;
            int den2 = 64 * 65 * 95 * 98;
            List<int> divnum = Util.PrimeFactorization(num2);
            List<int> divden = Util.PrimeFactorization(den2);

            Console.WriteLine("{0}/{1}", num2, den2);

            List<int> div = new List<int>();
            foreach (int l in divnum)
                if (divden.Contains(l))
                    div.Add(l);

            foreach (long d in div)
            {
                num2 /= (int)d;
                den2 /= (int)d;
            }
            Console.WriteLine("{0}/{1}", num2, den2);
        }

        internal static void Problem34()
        {
            //April 23, 2014
            CachedFactorial cf = new CachedFactorial();

            for (int i = 3; i < 100000; i++)
            {
                long sum = 0;
                foreach (char c in i.ToString())
                {
                    int digit = c - '0';
                    sum += cf.Factorial(digit);
                }

                if (i == sum)
                {
                    Console.WriteLine(i);
                }
            }
        }

        internal static void Problem35()
        {
            //April 23, 2014
            HashSet<int> circularPrimes = new HashSet<int>();

            int max = 1000000;
            PrimesSieve ps = new PrimesSieve(max);
            for (int i = 1; i < max; i += (i<3?1:2))
            {
                if (!ps.IsPrime(i))
                    continue;

                if (circularPrimes.Contains(i))
                    continue;

                bool circularPrime = true;

                HashSet<int> allTested = new HashSet<int>() { i };

                string rotated = i.ToString();
                for (int rot = 1; rot < i.ToString().Length; rot++)
                {
                    rotated = rotated.Substring(1) + rotated[0];

                    int rotatedInt = int.Parse(rotated);
                    allTested.Add(rotatedInt);

                    if (!ps.IsPrime(rotatedInt))
                    {
                        circularPrime = false;
                        break;
                    }
                }

                if (circularPrime)
                    foreach (int cpr in allTested)
                        circularPrimes.Add(cpr);
            }

            foreach (int cpr in circularPrimes)
                Console.Write("{0}, ", cpr);

            Console.WriteLine("");
            Console.WriteLine(circularPrimes.Count);
        }

        internal static void Problem36()
        {
            //April 23, 2014
            int sum = 0;
            for(int i=1; i<1000000; i++)
            {
                if (Util.IsPalindrome(i.ToString()))
                {
                    string bin = Convert.ToString(i, 2);
                    if (Util.IsPalindrome(bin))
                    {
                        Console.WriteLine(i);
                        sum += i;
                    }
                }
            }

            Console.WriteLine("Sum: {0}", sum);
        }

        internal static void Problem37()
        {
            //April 24, 2014
            int max = 1000000;
            int sum = 0;
            PrimesSieve ps = new PrimesSieve(max);

            for (int x = 8; x < max; x++)
            {
                if (ps.IsPrime(x))
                {
                    bool failed = false;
                    string s = x.ToString();
                    for (int i = 1; i < s.Length; i++)
                    {
                        string lower = s.Substring(0, s.Length - i);
                        string upper = s.Substring(i);


                        int l = int.Parse(lower);
                        int u = int.Parse(upper);

                        if (!ps.IsPrime(l) || !ps.IsPrime(u))
                        {
                            failed = true;
                            break;
                        }
                    }

                    if (!failed)
                    {
                        Console.WriteLine("{0} is a truncatable prime", x);
                        sum += x;
                    }
                }
            }

            Console.WriteLine("Sum: {0}", sum);
        }

        internal static void Problem38()
        {
            //April 24, 2014
            HashSet<char> digits = new HashSet<char>() { '9', '8', '7', '6', '5', '4', '3', '2', '1' };

            StringBuilder result = new StringBuilder();
            for (int integer = 1; integer < 987654321 / 2; integer++)
            {
                for (int n = 2; n < 10; n++)
                {
                    result.Clear();
                    for (int i = 1; i <= n; i++)
                    {
                        result.Append(i * integer);
                    }
                    int result2;

                    if (int.TryParse(result.ToString(), out result2))
                    {
                        //int result2 = int.Parse(result.ToString());

                        if (result2 > 900000000 && result2 <= 987654321)
                        {
                            

                            HashSet<char> digits2 = new HashSet<char>(digits);
                            foreach (char c in result2.ToString())
                            {
                                digits2.Remove(c);
                            }

                            if (digits2.Count == 0)
                            {
                                Console.WriteLine("{0}x[1..{1}] = {2}", integer, n, result);
                            }
                        }
                    }
                }
            }
        }

        internal static void Problem39()
        {
            //April 24, 2014. Solution is slower than I'd like...
            int maxSolutions = 0;
            int bestP = -1;

            for (int p = 3; p <= 1000; p++)
            {
                int nSolutions = 0;

                for (int h = 1; h < p / 2; h++)
                {
                    for (int a = 1; a < p - h; a++)
                    {
                        int b = p - h - a;
                        int hypsq = (int) Math.Pow(h, 2);
                        int asqpbsq = (int)(Math.Pow(a, 2) + Math.Pow(b, 2));

                        if (hypsq == asqpbsq)
                        {
                            //Valid triangle
                            nSolutions++;
                        }
                    }
                }

                if (nSolutions > maxSolutions)
                {
                    Console.WriteLine("{0}, {1}", maxSolutions, p);
                    maxSolutions = nSolutions;
                    bestP = p;
                }
            }

            Console.WriteLine("Number of solutions  ({0}) is maximized at perimeter = {1}", maxSolutions, bestP);
        }

        internal static void Problem40()
        {
            //April 24, 2014
            long integer = 1;
            long decimalPlace = 0;

            long decimalToCheck = 1;
            List<int> decimals = new List<int>();

            while (true)
            {
                string rep = integer.ToString();
                int digits = rep.Length;

                if (decimalPlace + digits >= decimalToCheck)
                {
                    string digit = rep.Substring((int)(decimalToCheck - decimalPlace - 1), 1);
                    decimals.Add(int.Parse(digit));
                    Console.WriteLine(digit);
                    decimalToCheck *= 10;
                }

                decimalPlace += digits;
                integer++;

                if (decimalToCheck > 1000000)
                    break;
            }

            int prod = 1;
            foreach (int i in decimals)
                prod *= i;
            Console.WriteLine("Product: {0}", prod);
        }

        internal static void Problem41()
        {
            //April 25, 2014
            List<int> digits = new List<int>();

            int maxPrime = -1;

            for (int d = 1; d < 9; d++)
            {
                digits.Add(d);


                foreach (List<int> toTest in Util.Permute(digits))
                {
                    int number = 0;
                    foreach (int i in toTest)
                        number = number * 10 + i;

                    //Console.WriteLine(number);

                    if (Util.IsPrime__slow(number))
                    {
                        Console.WriteLine("[1..{1}] pandigital prime: {0}", number, d);
                        if (number > maxPrime)
                            maxPrime = number;
                    }
                }
            }
            Console.WriteLine("Largest pandigital prime: {0}", maxPrime);

        }

        internal static void Problem42()
        {
            //April 25, 2014
            string wordsFile = File.ReadAllText("../../P42.txt");
            string[] words = wordsFile.Split(new char[] { '\"', ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> wordValues = new List<int>();
            int largest = 0;
            foreach (string word in words)
            {
                int wordVal = 0;
                foreach (char c in word)
                    wordVal += c - 'A' + 1;
                wordValues.Add(wordVal);

                if (wordVal > largest)
                    largest = wordVal;
            }

            int n = 1;
            int count = 0;
            while (true)
            {
                int tn = n * (n + 1) / 2;
                n++;
                while (wordValues.Contains(tn))
                {
                    wordValues.Remove(tn);
                    count++;
                }

                if (tn > largest)
                    break;
            }

            Console.WriteLine("There are {0} triangle numbers", count);

        }

        internal static void Problem43()
        {
            //April 25, 2014
            List<int> digits = new List<int>();

            for (int d = 0; d <= 9; d++)
                digits.Add(d);

            long sum = 0;
            foreach (List<int> toTest in Util.Permute(digits))
            {
                long number = 0;
                foreach (int i in toTest)
                    number = number * 10 + i;

                string numberStr = String.Format("{0:0000000000}", number);
                bool notDivisible = false;
                int[] prime = new int[] { 2, 3, 5, 7, 11, 13, 17 };

                for (int i = 0; i < 7; i++)
                {
                    string substr = numberStr.Substring(i + 1, 3);
                    int subnum = int.Parse(substr);

                    if (subnum % prime[i] != 0)
                        notDivisible = true;
                }
                if(!notDivisible)
                {
                    Console.WriteLine("{0} is substring divisible by primes", number);
                    sum += number;
                }

            }
            Console.WriteLine("Sum: {0}", sum);
        }

        internal static void Problem44()
        {
            //April 25, 2014.
            //This problem exceeds the 1 minute mark :( Takes 3 or 4 to get the answer.
            CachedFunction<int, int> cf = new CachedFunction<int, int>(a => a * (3 * a - 1) / 2);

            int D = int.MaxValue;

            for (int i = 1; i < 1000000; i++)
            {
                if (i % 100 == 0)
                    Console.Write(".");

                int Pi = cf.Calculate(i);
                for (int j = 1; j < i; j++)
                {
                    int Pj = cf.Calculate(j);

                    if (Pj > D)
                        break;

                    if (Pj > Pi)
                        break;


                    int Plower = Pi - Pj;

                    bool contains = false;
                    for (int idx = 1; idx < i; idx++ )
                    {

                        int y = cf.Calculate(idx);
                        if (Plower == y)
                            contains = true;

                        if (y > Plower)
                            break;
                    }

                    if (contains)
                    {
                        contains = false;

                        int Psum = Pi + Plower;
                        for (int idx = i; ; idx++)
                        {

                            int y = cf.Calculate(idx);
                            if (Psum == y)
                                contains = true;

                            if (y > Psum)
                                break;
                        }

                        if (contains)
                        {
                            if (Pj < D)
                            {
                                D = Pj;
                                Console.WriteLine("Next smallest D: {0} at pentagonals {1}, {2}", D, Plower, Pi);
                            }

                        }
                    }
                }
                //Console.WriteLine("P{0} = {1}", i, cf.Calculate(i));



            }



        }

        internal static void Problem45()
        {
            //April 25, 2014
            CachedFunction<long, long> Triangle = new CachedFunction<long, long>(a => a * (a + 1) / 2);
            CachedFunction<long, long> Pentagonal = new CachedFunction<long, long>(a => a * (3 * a - 1) / 2);
            CachedFunction<long, long> Hexagonal = new CachedFunction<long, long>(a => a * (2 * a - 1));

            long hexIdx = 140;
            long penIdx = 160;
            long triIdx = 280;

            int count = 0;
            int countReq = 2;
            while (count < countReq)
            {
                long Hi = Hexagonal.Calculate(hexIdx++);

                while (count < countReq)
                {
                    long Pi = Pentagonal.Calculate(penIdx++);
                    if (Pi > Hi)
                        break;

                    if (Hi == Pi)
                    {
                        while (count < countReq)
                        {
                            long Ti = Triangle.Calculate(triIdx++);

                            if (Ti > Hi)
                                break;

                            if (Ti == Hi)
                            {
                                Console.WriteLine("H{0} == P{1} == T{2} == {3}", hexIdx, penIdx, triIdx, Hi);
                                count++;
                            }
                        }
                    }
                }

            }
        }

        internal static void Problem46()
        {
            //April 25, 2014
            PrimesSieve ps = new PrimesSieve(1000000);
            for (int i = 5; i < 1000000; i+=2)
            {
                if (!ps.IsPrime(i))
                {
                    bool possible = false;
                    for (int j = 1; j < i; j++)
                    {
                        if (!ps.IsPrime(j))
                            continue;

                        int rem = i - j;
                        if (rem % 2 == 0)
                        {
                            rem /= 2;
                            int sqrrt = (int)Math.Sqrt(rem);
                            if (rem == sqrrt * sqrrt)
                            {
                                possible = true;
                                break;
                            }
                        }
                    }

                    if (!possible)
                    {
                        Console.WriteLine("Cannot write {0} as the sum of a prime and twice a square", i);
                        break;
                    }
                }
            }
        }

        internal static void Problem47()
        {
            //April 25, 2014. Probably juuust under the 1 minute mark.
            int numDistinctFactorsRequired = 2;
            int number = 4;
            int consecutive = 0;

            while(numDistinctFactorsRequired <= 4)
            {
                IEnumerable<int> factors = Util.PrimeFactorization(number++).Distinct();

                if (factors.Count() == numDistinctFactorsRequired)
                {
                    consecutive++;
                }
                else
                {
                    consecutive = 0;
                }

                if (consecutive == numDistinctFactorsRequired)
                {
                    Console.WriteLine("{0} numbers with {0} distinct factors:", numDistinctFactorsRequired);
                    for(int i=number - numDistinctFactorsRequired; i<number; i++)
                        Console.Write("{0}, ", i);
                    Console.WriteLine("");

                    numDistinctFactorsRequired++;
                }
            }
        }

        internal static void Problem48()
        {
            //April 26, 2014
            ulong sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                ulong val = 1;
                for (int j = 0; j < i; j++)
                {
                    val *= (ulong)i;
                    val = val % 10000000000;
                }

                sum += val;
                sum = sum % 10000000000;
            }

            Console.WriteLine("Last ten digits: {0:0000000000}", sum % 10000000000);
        }

        internal static void Problem49()
        {
            //April 26, 2014
            PrimesSieve ps = new PrimesSieve(9999);
            for (int start = 123; start < 9876; start++)
            {
                if (!ps.IsPrime(start))
                    continue;

                bool seq = false;
                for (int increase = 100; increase < (9876 - start) / 2; increase++)
                {
                    int a = start;
                    int b = start + increase;
                    int c = start + increase + increase;

                    if (!ps.IsPrime(b) || !ps.IsPrime(c))
                    {
                        continue;
                    }

                    List<char> chars = new List<char>();

                    string A = a.ToString("0000");
                    foreach (char ch in A)
                        chars.Add(ch);

                    List<char> Bs = new List<char>(chars);
                    string B = b.ToString("0000");
                    foreach (char ch in B)
                        if (Bs.Contains(ch))
                            Bs.Remove(ch);

                    if (Bs.Count != 0)
                        continue;

                    List<char> Cs = new List<char>(chars);
                    string C = c.ToString("0000");
                    foreach (char ch in C)
                        if (Cs.Contains(ch))
                            Cs.Remove(ch);

                    if (Cs.Count != 0)
                        continue;

                    Console.WriteLine("{0}, {1}, {2}", a, b, c);
                }
            }
        }

        internal static void Problem50()
        {
            //April 26, 2014
            PrimesSieve ps = new PrimesSieve(1000000);
            int largestConsecutive = -1;
            int maxConsecutive = 0;

            foreach (int primeStart in ps.Primes())
            {
                int numConsecutive = 0;
                int sum = 0;
                for (int i = primeStart; i<1000000 ; i++)
                {
                    if(!ps.IsPrime(i))
                        continue;

                    sum += i;
                    numConsecutive++;

                    if (sum >= 1000000)
                        break;

                    if (ps.IsPrime(sum) && numConsecutive > maxConsecutive)
                    {
                        maxConsecutive = numConsecutive;
                        largestConsecutive = sum;
                    }
                }
            }

            Console.WriteLine("Added {0} primes to get {1}", maxConsecutive, largestConsecutive);
        }

        internal static void Problem51()
        {
            //April 26, 2014
            //Not really happy with this solution, it's super slow. Several minutes to get the right answer.
            PrimesSieve ps = new PrimesSieve(1000000);
            bool found = false;

            //foreach (int primeStart in ps.Primes())
            for (int primeStart = 100000; primeStart < 1000000; primeStart++)
            {
                if (found)
                    break;

                int digits = primeStart.ToString().Length;

                List<int> toSubstitute = new List<int>();
                for (int i = 0; i < digits; i++)
                    toSubstitute.Add(i);

                //toSubstitute.Reverse();

                List<int> alreadyDone = new List<int>();
                for (int nReplace = 0; nReplace < digits; nReplace++)
                {
                    //Console.WriteLine("");
                    //Console.WriteLine("Replacing {0}", nReplace);

                    
                    foreach (List<int> toSubstPerm in Util.Permute(toSubstitute))
                    {
                        //Console.WriteLine("-");
                        int repr = 0;
                        for (int j = 0; j < toSubstPerm.Count; j++)
                        {
                            repr *= 10;
                            if (toSubstPerm[j] <= nReplace)
                                repr += 1;
                        }
                        if (alreadyDone.Contains(repr))
                            continue;
                        alreadyDone.Add(repr);

                        //Console.WriteLine("{0:00000}", repr);
                        //if (repr.ToString().Length == digits)
                        //    continue;

                        List<string> pr = new List<string>();
                        int primeReplacements = 0;
                        int newVal2 = -1;

                        //Console.WriteLine("");
                        for (int i = 0; i < 10; i++)
                        {
                            string val = primeStart.ToString();
                            string newVal = "";
                            for (int j = 0; j < toSubstPerm.Count; j++ )
                            {
                                if (toSubstPerm[j] <= nReplace)
                                    newVal += i.ToString();
                                else
                                    newVal += val[j];
                            }
                            newVal2 = int.Parse(newVal);

                            if (ps.IsPrime(newVal2))
                            {
                                primeReplacements++;
                                pr.Add(newVal);
                                //Console.WriteLine(newVal);
                            }
                        }

                        if (primeReplacements > 7)
                        {
                            //Console.WriteLine("{2}: {0}, {1}", primeStart, newVal2, repr);
                            Console.Write("{0} ({1}, {2}, {3}): ", primeReplacements, nReplace, repr, primeStart);
                            foreach(string s in pr)
                                Console.Write("{0}, ", s);
                            Console.WriteLine("");
                        }
                        if (primeReplacements == 8)
                        {
                            if(int.Parse(pr[0]) > 100000)
                                found = true;
                        }
                    }
                }
                //for (int nReplace = 1; nReplace < digits; nReplace++)
                //{
                //    toSubstitute.Remove(0);
                //    toSubstitute.Add(1);
                //    List<List<int>> alreadyDone = new List<List<int>>();
                //    foreach (List<int> toSubstPerm in Util.Permute(toSubstitute))
                //    {
                //        if (alreadyDone.Contains(toSubstPerm))
                //            continue;
                //        alreadyDone.Add(toSubstPerm);
                //    }
                //}
            }
        }

        internal static void Problem52()
        {
            //April 26, 2014
            for (int i = 1; i < 1000000; i++)
            {
                string dig = i.ToString();
                List<char> chars = new List<char>();
                foreach (char c in dig)
                    chars.Add(c);

                bool failed = false;
                for (int mult = 2; mult < 7; mult++)
                {
                    string digm = (i * mult).ToString();

                    List<char> chars2 = new List<char>(chars);
                    foreach (char c in digm)
                        if(chars2.Contains(c))
                            chars2.Remove(c);

                    if (chars2.Count != 0)
                    {
                        failed = true;
                        break;
                    }

                }

                if (!failed)
                {
                    for (int mult = 1; mult < 7; mult++)
                        Console.WriteLine(i * mult);
                    break;
                }
            }
        }

        internal static void Problem53()
        {
            throw new NotImplementedException();
        }
    }//end of class

    class CachedFunction<T1, T2> where T1 : IComparable where T2 : IComparable
    {
        Dictionary<T1, T2> cache = new Dictionary<T1, T2>();

        Func<T1, T2> functionToCache;

        public CachedFunction(Func<T1, T2> _functionToCache)
        {
            functionToCache = _functionToCache;
        }

        public T2 Calculate(T1 x)
        {
            if (cache.ContainsKey(x))
                return cache[x];
            else
            {
                T2 valueAtX = functionToCache(x);

                if(cache.Count < 10000000)
                    cache.Add(x, valueAtX);
                return valueAtX;
            }
        }

    }

    class CachedFactorial
    {
        Dictionary<int, long> factorials = new Dictionary<int, long>();

        public CachedFactorial()
        {
            factorials.Add(0, 1);
            factorials.Add(1, 1);
            factorials.Add(2, 2);
        }

        public long Factorial(int x)
        {
            if (x < 0)
                throw new ArgumentOutOfRangeException();

            if (factorials.ContainsKey(x))
                return factorials[x];
            else
            {
                long factorialOfX = x * Factorial(x - 1);
                factorials.Add(x, factorialOfX);
                return factorialOfX;
            }
        }
    }
    class CachedCollatzLengths
    {
        Dictionary<long, int> CollatzLengths = new Dictionary<long, int>();
        public CachedCollatzLengths()
        {
            CollatzLengths.Add(1, 0);

            
        }

        public int CollatzLength(long start)
        {
            if (CollatzLengths.ContainsKey(start))
                return CollatzLengths[start];
            else
            {
                long next = NextCollatz(start);
                int length = CollatzLength(next) + 1;
                CollatzLengths.Add(start, length);
                return length;
            }
        }

        public static long NextCollatz(long input)
        {
            if((input & 1) == 1)
            {
                return input * 3 + 1;
            }
            else
            {
                return input / 2;
            }
        }
    }

    class PrimesSieve
    {
        bool[] notPrime;
        public PrimesSieve(int n)
        {

            notPrime = new bool[n];
            

            notPrime[0] = true;
            notPrime[1] = true;
            for (int i = 0; i < n; i++)
            {
                if (notPrime[i])
                    continue;

                int mult = 2;
                while(mult * i < n) 
                {
                    notPrime[mult * i] = true;
                    mult++;
                } 

            }
        }

        public IEnumerable<int> Primes()
        {
            for (int i = 1; i < notPrime.Length; i++)
            {
                if (!notPrime[i])
                    yield return i;
            }
        }

        public bool IsPrime(int idx)
        {
            if (idx >= notPrime.Length)
                throw new ArgumentOutOfRangeException(idx.ToString());
            return !notPrime[idx];
        }
    }

    //Problem 2
    class CachedFibonacci
    {
        private static Dictionary<int, int> cache = new Dictionary<int, int>();

        public static int Calculate(int term)
        {
            if (term == 0)
                return 1;
            else if (term == 1)
                return 2;
            else if (cache.ContainsKey(term))
                return cache[term];
            else
            {
                int result = Calculate(term - 2) + Calculate(term - 1);
                cache.Add(term, result);
                return result;
            }


        }
    }

    class Util
    {

        public static IEnumerable<List<int>> ChangePossibilities(int changeToGive, List<int> coinSizes, List<int> currentChange)
        {
            if (changeToGive == 0)
            {
                yield return currentChange;
            }
            else
            {
                List<int> remainingSizes = new List<int>(coinSizes);

                foreach (int coin in coinSizes)
                {
                    if (changeToGive >= coin)
                    {
                        changeToGive -= coin;
                        currentChange.Add(coin);
                        foreach (List<int> possibility in ChangePossibilities(changeToGive, remainingSizes, currentChange))
                            yield return possibility;

                        currentChange.Remove(coin);
                        changeToGive += coin;
                    }

                    remainingSizes.Remove(coin);
                }
            }
        }

      

        /// <summary>
        /// Call foreach on this to receive all permutations of the input.
        /// If toPermute is sorted, the results are in lexicographic order
        /// </summary>
        /// <param name="toPermute"></param>
        /// <returns></returns>
        public static IEnumerable<List<int>> Permute(List<int> toPermute)
        {
            if (toPermute.Count == 1)
                yield return toPermute;
            else
            {

                foreach (int i in toPermute)
                {
                    List<int> subset = new List<int>(toPermute);
                    subset.Remove(i);

                    foreach (List<int> subsetPermuted in Permute(subset))
                    {
                        subsetPermuted.Insert(0, i);
                        yield return subsetPermuted;
                    }
                }
            }
        }

        /// <summary>
        /// Note: returns incorrect values of zero, and numbers > 1000
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string Spell(int num)
        {

            if (num == 19)
                return "nineteen";
            if (num == 18)
                return "eighteen";
            if (num == 17)
                return "seventeen";
            if (num == 16)
                return "sixteen";
            if (num == 15)
                return "fifteen";
            if (num == 14)
                return "fourteen";
            if (num == 13)
                return "thirteen";
            if (num == 12)
                return "twelve";
            if (num == 11)
                return "eleven";
            if (num == 10)
                return "ten";
            if (num == 9)
                return "nine";
            if (num == 8)
                return "eight";
            if (num == 7)
                return "seven";
            if (num == 6)
                return "six";
            if (num == 5)
                return "five";
            if (num == 4)
                return "four";
            if (num == 3)
                return "three";
            if (num == 2)
                return "two";
            if (num == 1)
                return "one";
            if (num == 0)
                return "";

            if (num < 30)
                return "twenty " + Spell(num % 10);
            if (num < 40)
                return "thirty " + Spell(num % 10);
            if (num < 50)
                return "forty " + Spell(num % 10);
            if (num < 60)
                return "fifty " + Spell(num % 10);
            if (num < 70)
                return "sixty " + Spell(num % 10);
            if (num < 80)
                return "seventy " + Spell(num % 10);
            if (num < 90)
                return "eighty " + Spell(num % 10);
            if (num < 100)
                return "ninety " + Spell(num % 10);

            if (num == 1000)
                return "one thousand";

            int hundreds = num / 100;
            if (num == hundreds * 100)
                return (Spell(hundreds) + " hundred");
            else
                return (Spell(hundreds) + " hundred and " + Spell(num - hundreds * 100));
        }
        
        /// <summary>
        /// Returns sum of natural numbers up to and including this number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static long TriangleNumber(long number)
        {
            return number * (number + 1) / 2;
        }
        public static bool IsPrime__slow(long number)
        {
            if (number == 1)
                return false;
            for (long i = 2; i < number; i++)
                if (number % i == 0)
                    return false;
            return true;
        }
        public static bool IsPalindrome(string toCheck)
        {
            int end = toCheck.Length - 1;
            int middle = toCheck.Length / 2; //Rounded down
            for (int i = 0; i < middle; i++)
            {
                if (toCheck[i] != toCheck[end - i])
                    return false;
            }
            return true;
        }
        public static List<int> PrimeFactorization(long number)
        {

            List<int> divisors = new List<int>();

            //int toCheck = (int)Math.Ceiling(Math.Sqrt(number));
            for (int i = 2; i <= number; )
            {
                if (number % i == 0)
                {
                    number /= i;
                    divisors.Add(i);
                }
                else
                {
                    i++;
                }
            }

            return divisors;
        }
        public static List<long> Divisors(long number)
        {

            List<long> divisors = new List<long>();

            long toCheck = (long)Math.Ceiling(Math.Sqrt(number));
            for (int i = 1; i <= toCheck; i++)
            {
                long remainder = number % i;

                if (remainder == 0)
                {
                    divisors.Add(i);
                    long matchingDivisor = number / i;
                    if(matchingDivisor != i)
                        divisors.Add(matchingDivisor);

                    if (matchingDivisor <= toCheck)
                        toCheck = matchingDivisor - 1;
                }
            }
            
            //divisors.Add(number);

            return divisors;
        }

        public static List<long> ProperDivisors(long number)
        {

            List<long> divisors = new List<long>();

            long toCheck = (long)Math.Ceiling(Math.Sqrt(number));
            for (int i = 1; i <= toCheck; i++)
            {
                long remainder = number % i;

                if (remainder == 0)
                {
                    divisors.Add(i);
                    long matchingDivisor = number / i;
                    if (matchingDivisor != i && matchingDivisor != number)
                        divisors.Add(matchingDivisor);

                    if (matchingDivisor <= toCheck)
                        toCheck = matchingDivisor - 1;
                }
            }

            //divisors.Add(number);

            return divisors;
        }

    }
}