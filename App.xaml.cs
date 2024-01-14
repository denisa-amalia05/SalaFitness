using System;
using SalaFitness.Data;
using System.IO;

namespace SalaFitness
{
    public partial class App : Application
    {
        static FitnessDatabase database;

        public static FitnessDatabase Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SalaFitness.db");
                    database = new FitnessDatabase(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
