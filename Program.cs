namespace Assignment_5._3._2
{
    internal class Program
    {
        static Nullable<int>[]? remainingSteps;
        static void Main(string[] args)
        {
            int[] steps = [-1, 0, 1, 2, 3, 4, 5, 6, 7, 8];
            if (args.Length > 0)
            {
                steps = new int[args.Length];
                for(int i = 0; i < args.Length; i++)
                {
                    steps[i] = int.Parse(args[i]);
                }
            }
            foreach(int step in steps)
            {
                remainingSteps = new Nullable<int>[step + 1];
                Console.WriteLine($"{step} : {NumberOfWays(step)}");
            }
        }

        #region pseudocode
        // Recursive solution that explores two possible steps, 1-step or 2-steps
        // if remaining steps is greater than 0
        //     take 1 step and 2 steps
        // if remaining steps is less than 0
        //     this is not a solution, so do not save or count this state
        // if remaining steps is 0
        //     this is a solution, so save or count this state
        #endregion
        static int? NumberOfWays(int steps)
        {
            if (steps > 1)
            {
                int? oneStepFurther = remainingSteps[steps - 1].HasValue ? remainingSteps[steps - 1] : NumberOfWays(steps - 1);
                int? twoStepFurther = remainingSteps[steps - 2].HasValue ? remainingSteps[steps - 2] : NumberOfWays(steps - 2);

                // store the result before returning the result
                return remainingSteps[steps] = oneStepFurther + twoStepFurther;
            }
            else if (steps == 0 || steps == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
