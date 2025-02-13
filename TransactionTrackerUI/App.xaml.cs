﻿using TransactionTrackerUI.Database;
using TransactionTrackerUI.Views;

namespace TransactionTrackerUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }
        static LoginDatabase database;

        public static LoginDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new LoginDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLiteSample.db"));

                }
                return database;
            }
        }
    }
}
