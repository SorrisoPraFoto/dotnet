namespace Diretorios
{
    class Diretorios {
        public void printDiretorios(string raiz){
            IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories(raiz);

            foreach (var dir in listOfDirectories) {
                Console.WriteLine(dir);
            }
        }

        public void printArquivos(string raiz){
            IEnumerable<string> listOfDirectories = Directory.EnumerateFiles(raiz);

            foreach (var dir in listOfDirectories) {
                Console.WriteLine(dir);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Diretorios dir = new Diretorios();
            dir.printDiretorios("stores");
        }
    }
}