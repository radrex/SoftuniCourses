namespace P02_GraphicEditor_After
{
    using System;

    public class GraphicEditor
    {
        //---------------- Constructors -----------------
        public GraphicEditor()
        {

        }

        //------------------ Methods --------------------
        public void DrawShape(IShape shape)
        {
            Type classType = shape.GetType();
            Shape instance = Activator.CreateInstance(classType) as Shape;

            Console.WriteLine(instance.DrawShape());
        }
    }
}
