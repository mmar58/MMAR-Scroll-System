

namespace MMAR.ScrollSystem.Demo
{
    public class AdvancedData : Data
    {
        public int index;
        public string FirstName,LastName;
        public int Age;
        public string Occupation;

        public AdvancedData(int index,string firstName, string lastName, int age, string occupation)
        {
            this.index = index;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Occupation = occupation;
        }
        
    }
}