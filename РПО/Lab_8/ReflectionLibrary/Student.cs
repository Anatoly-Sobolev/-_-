namespace ReflectionLibrary
{
    public class Student
    {
        public string PublicField;
        protected int ProtectedField;
        private double PrivateField;

        public string PublicProperty
        {
            get { return PublicField; }
            set { PublicField = value; }
        }

        protected int ProtectedProperty
        {
            get { return ProtectedField; }
            set { ProtectedField = value; }
        }

        private double PrivateProperty
        {
            get { return PrivateField; }
            set { PrivateField = value; }
        }

        public Student()
        {
            PublicField = "Анатолий";
            ProtectedField = 19;
            PrivateField = 4.5;
        }

        public Student(string publicField, int protectedField, double privateField)
        {
            PublicField = publicField;
            ProtectedField = protectedField;
            PrivateField = privateField;
        }

        public string GetPublicInfo()
        {
            return "PublicField = " + PublicField;
        }

        protected string GetProtectedInfo()
        {
            return "ProtectedField = " + ProtectedField;
        }

        private string GetPrivateInfo()
        {
            return "PrivateField = " + PrivateField;
        }
    }
}
