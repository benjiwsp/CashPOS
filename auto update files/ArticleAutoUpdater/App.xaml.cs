using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Microsoft.Shell;

namespace ArticleAutoUpdater
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application, ISingleInstanceApp
	{
		private const string Unique = "C13432B2-A436-4EEE-AFE2-E762C87094B1";

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			new MainWindow().Show();
		}

		[STAThread]
		public static void Main()
		{
			if (SingleInstance<App>.InitializeAsFirstInstance(Unique))
			{
				var application = new App();

				application.InitializeComponent();
				application.Run();

				// Allow single instance code to perform cleanup operations
				SingleInstance<App>.Cleanup();
			}
			else
			{
				MessageBox.Show("There is another instance of the application running.");
			}
		}

		#region ISingleInstanceApp Members

		bool Microsoft.Shell.ISingleInstanceApp.SignalExternalCommandLineArgs(IList<string> args)
		{
			// We don't have any command line args for this app!
			return true;
		}

		#endregion
	}
}
