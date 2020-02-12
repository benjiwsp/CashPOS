using System;
using System.Windows;

namespace ArticleAutoUpdater
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			CompareVersions();
		}

		private void CompareVersions()
		{
			string downloadToPath = "C:\\VersionsTest\\Downloads";
			string localVersion = ApplicationUpdate.Versions.LocalVersion(downloadToPath + "\\version.txt");
			string remoteURL = "http://localhost/AutoUpdate/";
			string remoteVersion = ApplicationUpdate.Versions.RemoteVersion(remoteURL + "updateVersion.txt");
			string remoteFile = remoteURL + remoteVersion + ".zip";

			LocalVersion.Text = localVersion;
			RemoteVersion.Text = remoteVersion;

			if (localVersion != remoteVersion)
			{
				BeginDownload(remoteFile, downloadToPath, remoteVersion, "update.txt");
			}
		}

		private void BeginDownload(string remoteURL, string downloadToPath, string version, string executeTarget)
		{
			string filePath = ApplicationUpdate.Versions.CreateTargetLocation(downloadToPath, version);

			Uri remoteURI = new Uri(remoteURL);
			System.Net.WebClient downloader = new System.Net.WebClient();

			downloader.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(downloader_DownloadFileCompleted);

			downloader.DownloadFileAsync(remoteURI, filePath + ".zip",
				new string[] { version, downloadToPath, executeTarget });
		}


		void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			string[] us = (string[])e.UserState;
			string currentVersion = us[0];
			string downloadToPath = us[1];
			string executeTarget = us[2];

			if (!downloadToPath.EndsWith("\\")) // Give a trailing \ if there isn't one
				downloadToPath += "\\";

			string zipName = downloadToPath + currentVersion + ".zip"; // Download folder + zip file
			string exePath = downloadToPath + currentVersion + "\\" + executeTarget; // Download folder\version\ + executable

			if (new System.IO.FileInfo(zipName).Exists)
			{
				using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(zipName))
				{
					zip.ExtractAll(downloadToPath + currentVersion,
						Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
				}
				if (new System.IO.FileInfo(exePath).Exists)
				{
					ApplicationUpdate.Versions.CreateLocalVersionFile(downloadToPath, "version.txt", currentVersion);
					System.Diagnostics.Process proc = System.Diagnostics.Process.Start(exePath);
				}
				else
				{
					MessageBox.Show("Problem with download. File does not exist.");
				}
			}
			else
			{
				MessageBox.Show("Problem with download. File does not exist.");
			}
		}
	}
}
