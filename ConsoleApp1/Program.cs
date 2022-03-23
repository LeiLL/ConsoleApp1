   
class FourElements
{
    // Check if the digits follow the correct order
    static bool IsCorrectOrder(long n)
    {
        bool flag = false;

        // to store the previous digit
        long prev = -1;

        while (n != 0)
        {
            if (prev == -1)
            {
                prev = n % 10;
                n = n / 10;
                continue;
            }

            if (prev >= n % 10)
            {
                flag = true;
                prev = n % 10;
                n = n / 10;
                continue;
            }

            flag = false;
            break;
        }

        return flag;
    }
    static void FindFourElements(List<int> primNumber)
    {
        List<List<int>> primeNumbers = new List<List<int>>();
        var n = primNumber.Count;

        // Fix the first element and find other three
        for (int i = 0; i < n - 3; i++)
        {
            // Fix the second element and find other two
            for (int j = i + 1; j < n - 2; j++)
            {               
                // Fix the third element and find the fourth
                for (int k = j + 1; k < n - 1; k++)
                {
                    // Find the fourth
                    for (int l = k + 1; l < n; l++)
                    {
                        var prod = (long)primNumber[i] * (long)primNumber[j] * (long)primNumber[k] * (long)primNumber[l];
                        
                        if (prod.ToString().Length == 12)
                        {
                            if (IsCorrectOrder(prod))
                            {
                                var aGroup = new List<int>() { primNumber[i], primNumber[j], primNumber[k], primNumber[l] };

                                primeNumbers.Add(aGroup);

                                Console.WriteLine(string.Join(", ", aGroup));
                                Console.WriteLine("Product: "+prod);
                            }                          
                        }

                        if (prod.ToString().Length > 12)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
    
    static bool IsPrime(int n)
    {
        //since 0 and 1 is not prime return false.
        if (n == 1 || n == 0) return false;

        for (int i = 2; i*i < n; i++)
        {
            // if the number is divisible by i, then n is not a prime number.
            if (n % i == 0) return false;
        }

        return true;
    }

    public static void Main(String[] args)
    {
        int N = 1000;
        List<int> primNumbers = new List<int>();

        for (int i = 1; i < N; i++)
        {
            //check if current number is prime
            if (IsPrime(i))
            {
                primNumbers.Add(i);
            }
        }

        FindFourElements(primNumbers);
    }
}

