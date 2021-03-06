using System.Collections.Generic;
using System.Linq;
using System;

namespace SecretaryApp
{
    public class TestsRunner
    {
        private decimal _eulerConst; 
        private int _numberOfApplicants;
        public List<Test> Tests { get; } = new List<Test>();
        public TestsRunner(int numberOfTests, int numberOfApplicants, decimal eulerConst)
        {
            _eulerConst = eulerConst;
            _numberOfApplicants = numberOfApplicants;
            for (var test = 0; test < numberOfTests; test++)
            {
                Tests.Add(new Test(numberOfApplicants));
            }
        }

        public void Run()
        {
            var countOfBestSelections = 0;
            var winnerPositions = new List<int>();
            foreach (var test in Tests)
            {
                var winner = GetTheWinner(test);

                if (winner != null)
                {
                    var highestRating = test.Applicants.Max(x => x.Rating);
                    Console.WriteLine($"Winner: Intern {winner.Order} Rating: {winner.Rating} Max: {highestRating}");
                    if (winner.Rating == highestRating) countOfBestSelections++;
                    winnerPositions.Add(winner.Order);
                }
                else 
                {
                    Console.WriteLine("There was no winner that round.");
                }
            }  
            PrintFinalComments(countOfBestSelections, winnerPositions);
        }

        private void PrintFinalComments(int countOfBestSelections, List<int> winnerPositions)
        {
            var optimalCandidatePercent = (decimal) countOfBestSelections/Tests.Count;
            Console.WriteLine($"There were {NumberOfUnluckyApplicants()} unlucky interns per test.");
            Console.WriteLine($"The ideal intern was selected in {optimalCandidatePercent*100}% of the tests {countOfBestSelections}/{Tests.Count}.");
            var averageWinnerPosition = winnerPositions.Average();
            var applicantCount = Tests.First().Applicants.Count;
            var percentUntilWinner = (averageWinnerPosition / (double) applicantCount)*100;
            Console.WriteLine($"The avg position of the winner was {averageWinnerPosition} out of {applicantCount} applicants ({percentUntilWinner.ToString("#.##")}%)");
        }

        private Applicant GetTheWinner(Test test)
        {
            var unluckyApplicants = test.Applicants.Where(x => x.Order <= NumberOfUnluckyApplicants());
                var bestRatingOfPreSelection = unluckyApplicants.Max(x => x.Rating);
                var potentialWinners = test.Applicants.Except(unluckyApplicants);
                return potentialWinners.OrderBy(x => x.Order)
                                .FirstOrDefault(x => x.Rating >= bestRatingOfPreSelection);
        }
        private int NumberOfUnluckyApplicants()
        {
            var numberOfUnluckyApplicants = _numberOfApplicants * _eulerConst;            
            return (int) numberOfUnluckyApplicants;
        }
    }
}