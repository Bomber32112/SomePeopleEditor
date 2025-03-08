namespace SomePeopleEditor.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        int groupNumber;
        public int GroupNumber
        {
            get => groupNumber;
            set
            {
                groupNumber = value;
                foreach (var item in DataBase.DB.Groups)
                {
                    if (item.Number == GroupNumber)
                    {
                        if (!item.Students.Contains(this))
                            item.Students.Add(this);
                        return;
                    }
                }
            }
        }
    }
}