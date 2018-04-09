namespace Random.Generators
{
    public  class RandomGenerators
    {

        private static int RandomNumberEven(int min, int max)
        {
            System.Random random = new System.Random();
            int ans = random.Next(min, max);
            if (ans % 2 == 0) return ans;
            else
            {
                if (ans + 1 <= max)
                    return ans + 1;
                else if (ans - 1 >= min)
                    return ans - 1;
                else return 0;
            }
        }

        private static int RandomNumberOdd(int min, int max)
        {
            System.Random random = new System.Random();
            int ans = random.Next(min, max);
            if (ans % 2 == 1) return ans;
            else
            {
                if (ans + 1 <= max)
                    return ans + 1;
                else if (ans - 1 >= min)
                    return ans - 1;
                else return 0;
            }
        }


    }
}
