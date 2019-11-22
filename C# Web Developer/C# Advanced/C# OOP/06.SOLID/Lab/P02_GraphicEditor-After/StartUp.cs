namespace P02_GraphicEditor_After
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IShape shape = new Rectangle();
            GraphicEditor ge = new GraphicEditor();
            ge.DrawShape(shape);
        }
    }
}
