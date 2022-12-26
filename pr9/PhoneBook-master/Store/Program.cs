namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IPhone> book = new List<IPhone>();

            PersonCreator smCreator = new PersonCreator();

            book.Add(smCreator.GeneratePhone("Шинкарев", "+748584782"));
            book.Add(smCreator.GeneratePhone("Ермошкин", "+847223465"));

            IPCreator nbCr= new IPCreator();

            book.Add(nbCr.GeneratePhone("оладушки", "534-534"));

            // основная функциональность (перебор коллекции ) не нарушается при добавлении в нее объектов новых типов
            foreach(IPhone t in book)
            {
                t.call();
                t.getInfo();
                Console.WriteLine();
            }

        }
    }
}