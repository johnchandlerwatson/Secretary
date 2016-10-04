using System.Collections.Generic;

namespace SecretaryApp
{
    public class Test
    {
        public List<Applicant> Applicants { get; } = new List<Applicant>();

        public Test(int numberOfApplicants)
        {
            for (var order =0; order < numberOfApplicants; order++)
            {
                var applicant = new Applicant();
                applicant.Order = order;
                Applicants.Add(applicant);
            }
        }
    }
}