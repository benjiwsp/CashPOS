using ApplicationUpdate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ApplicationUpdate.Test
{


	/// <summary>
	///This is a test class for VersionsTest and is intended
	///to contain all VersionsTest Unit Tests
	///</summary>
	[TestClass()]
	public class VersionsTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion

		/// <summary>
		///A test for LocalVersion
		///</summary>
		[TestMethod()]
		public void LocalVersion_BadFile_Test()
		{
			string path = @"C:\BadFolder\BadVersionFile.version";

			Assert.IsFalse(new System.IO.FileInfo(path).Exists, "File should not exist.");

			string expected = null;
			string actual;
			actual = Versions.LocalVersion(path);
			Assert.AreEqual(expected, actual);

			path = @"Z:\ASDcjaksl\fasjldjvalwer";
			actual = Versions.LocalVersion(path);
			Assert.AreEqual(expected, actual, "Bad path failed");

			path = null;
			actual = Versions.LocalVersion(path);
			Assert.AreEqual(expected, actual, "null failed");

			path = "!@\"#411j320vjal;sdkua@!<#>^%*(@#AVEW  VRLQ#";
			actual = Versions.LocalVersion(path);
			Assert.AreEqual(expected, actual, "Illegal characters failed");
		}

		/// <summary>
		///A test for LocalVersion
		///</summary>
		[TestMethod()]
		public void LocalVersion_GoodFile_Test()
		{
			string folderPath = "C:\\VersionsTest";
			string fileName = "app.version";
			string expected = "1.2.3.4";

			string path = Versions.CreateLocalVersionFile(folderPath, fileName, expected);
			Assert.IsTrue(new System.IO.FileInfo(path).Exists, "File should exist now.");

			string actual;
			actual = Versions.LocalVersion(path);
			Assert.AreEqual(expected, actual);

			path = @"C:\Program Files\Microsoft Visual Studio 10.0\Common7\Tools\errlook.exe";
			expected = null;
			actual = Versions.LocalVersion(path);
			Assert.AreEqual(expected, actual, "This is not a good version file!");
		}

		

		/// <summary>
		///A test for ValidateFile
		///</summary>
		[TestMethod()]
		public void ValidateFileTest()
		{
			string[] contentsPass = {
														"0.0.0.0",
														"1.2.3.4",
														"10.2.3.4",
														"10.20.3.4",
														"10.20.30.4",
														"10.20.30.40",
														"10000.20000.300000000.400000000000000",
													};
			bool expected = true;
			bool actual;
			foreach (string contents in contentsPass)
			{
				actual = Versions.ValidateFile(contents);
				Assert.AreEqual(expected, actual, contents);
			}

			string[] contentsFail = {
														"a.0.0.0",
														"0.b.0.0",
														"0.0.c.0",
														"0.0.0.d",
														"1.4",
														"10.2.3.4.87",
														"blah blah",
														"",
														null,
														"!@#^%!*#@($QJVW4.!@$(^T!@#",
													};
			expected = false;
			foreach (string contents in contentsFail)
			{
				actual = Versions.ValidateFile(contents);
				Assert.AreEqual(expected, actual, contents);
			}
		}

		/// <summary>
		///A test for RemoteVersion
		///</summary>
		[TestMethod()]
		public void RemoteVersion_GoodURL_Test()
		{
			string url = "http://localhost/AutoUpdate/app.txt";
			string folderPath = "C:\\VersionsTest";
			string fileName = "app.txt";
			string expected = "11.22.33.44";

			string path = Versions.CreateLocalVersionFile(folderPath, fileName, expected);

			string actual;
			actual = Versions.RemoteVersion(url);
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for RemoteVersion
		///</summary>
		[TestMethod()]
		public void RemoteVersion_BadURL_Test()
		{
			string url = "http://localhost/AutoUpdate/ZZapp.txt";
			string folderPath = "C:\\VersionsTest";
			string fileName = "app.txt";
			string contents = "11.22.33.44";
			string expected = null;
			string path = Versions.CreateLocalVersionFile(folderPath, fileName, contents);

			string actual;
			actual = Versions.RemoteVersion(url);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void CompareVersions_Match_Test()
		{
			string url = "http://localhost/AutoUpdate/app.txt";
			// Create our server-side version file.
			string folderPath = "C:\\VersionsTest";
			string fileName = "app.txt";
			string expected = "1.0.3.121";
			string path = Versions.CreateLocalVersionFile(folderPath, fileName, expected);

			// Create our local version file.
			fileName = "app.version";
			path = Versions.CreateLocalVersionFile(folderPath, fileName, expected);

			string localVersion = Versions.LocalVersion(path);
			string remoteVersion = Versions.RemoteVersion(url);

			Assert.AreEqual(localVersion, remoteVersion, "Versions should match. No update!");
		}

		[TestMethod()]
		public void CompareVersions_NoMatch_Test()
		{
			string url = "http://localhost/AutoUpdate/app.txt";
			// Create our server-side version file.
			string folderPath = "C:\\VersionsTest";
			string fileName = "app.txt";
			string expected = "1.0.3.121";
			string path = Versions.CreateLocalVersionFile(folderPath, fileName, expected);

			// Create our local version file.
			fileName = "app.version";
			expected = "1.0.4.1";
			path = Versions.CreateLocalVersionFile(folderPath, fileName, expected);

			string localVersion = Versions.LocalVersion(path);
			string remoteVersion = Versions.RemoteVersion(url);

			Assert.AreNotEqual(localVersion, remoteVersion, "Versions should not match. We need an update!");
		}


		/// <summary>
		///A test for CreateTargetLocation
		///</summary>
		[TestMethod()]
		public void CreateTargetLocationTest()
		{
			string downloadToPath = "C:\\AutoDownloadTest\\Downloads";
			string version = "6.2.3.0";
			string expected = downloadToPath + "\\" + version;

			// Delete the folder if it exists, and assert that it isn't there.
			if (new System.IO.DirectoryInfo(expected).Exists)
				new System.IO.DirectoryInfo(expected).Delete();
			Assert.IsFalse(new System.IO.DirectoryInfo(expected).Exists, "Before we start, it shouldn't exist.");

			string actual;
			actual = Versions.CreateTargetLocation(downloadToPath, version);
			Assert.AreEqual(expected, actual);
			Assert.IsTrue(new System.IO.DirectoryInfo(expected).Exists, "After we are done, it should exist.");
			System.IO.DirectoryInfo parentDir = new System.IO.DirectoryInfo(expected).Parent;
			new System.IO.DirectoryInfo(expected).Delete(); // Clean it up when we're done
			parentDir.Delete(); // Clean it up when we're done
		}
	}
}
