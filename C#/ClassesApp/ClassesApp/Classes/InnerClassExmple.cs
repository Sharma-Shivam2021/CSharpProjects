namespace ClassesApp.Classes;

public class InnerClassExample
{
    private string outerField = "Outer Field";

    public class InnerClass
    {
        private InnerClassExample outer;

        public InnerClass(InnerClassExample outer)
        {
            this.outer = outer;
        }

        public void DisplayOuterField()
        {
            Console.WriteLine(outer.outerField);
        }
    }
}

