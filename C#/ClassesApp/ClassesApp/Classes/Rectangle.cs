namespace ClassesApp.Classes;

// compiler creates default constructor itself when not specified.
internal class Rectangle
{
    public double Width { get; set; }
    public double Length { get; set; }

    // Computed property
    // read-only property
    public double Area
    {
        get { return Width * Length; }
    }

    // property with only setter is write-only and cannot be read by program
    /*
     public double Color {set;}
     */
}
