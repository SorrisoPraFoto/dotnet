namespace Program
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Newtonsoft.Json;

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

        public void searchTextos(string raiz){
            IEnumerable<string> allFilesInAllFolders = Directory.EnumerateFiles(raiz, "*.txt", SearchOption.AllDirectories);

            foreach (var file in allFilesInAllFolders){
                Console.WriteLine(file);
            }
        }

        public IEnumerable<string> findFiles(string raiz){
            IEnumerable<string> listOfDirectories = Directory.EnumerateFiles(raiz);
            return listOfDirectories;
        }
    }

    class SalesData
    {
        public double Total { get; set; }
    }

    class Program
    {
        static double CalculateSalesTotal(IEnumerable<string> salesFiles)
        {
            double salesTotal = 0;

            foreach(var file in salesFiles){
                string salesJson = File.ReadAllText(file);
                SalesData data = JsonConvert.DeserializeObject<SalesData>(salesJson); // Converte do JSON pra string
                salesTotal += data.Total;
            }

            return salesTotal;
        }
        static void Main(string[] args)
        {
            Diretorios gerenciador = new Diretorios();
            var currentDirectory = Directory.GetCurrentDirectory();
            var storesDirectory = Path.Combine(currentDirectory, "stores");

            var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
            Directory.CreateDirectory(salesTotalDir);

            var salesFiles = gerenciador.findFiles(storesDirectory);

            var salesTotal = CalculateSalesTotal(salesFiles);

            File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);
        }
    }
}