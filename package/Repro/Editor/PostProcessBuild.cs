using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using Repro.XCodeEditor;

namespace Repro {

	public abstract class PostProcessBuild {

		[PostProcessBuildAttribute(100000)]
		public static void OnPostprocessBuild (BuildTarget target, string pathToBuiltProject) {
#if UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6
            if (target == BuildTarget.iPhone) {
#else
            if (target == BuildTarget.iOS) {
#endif
				try {
					PostProcessBuildForiOS (pathToBuiltProject);
				}
				catch (Exception e) {
					Debug.LogWarning ("PostProcessBuildForiOS: " + e.Message);
				}
			}
			else if (target == BuildTarget.Android) {
			}
		}

		private static void PostProcessBuildForiOS (string pathToBuiltProject) {

#if UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6
			CopySDK (pathToBuiltProject);
			XCProject project = new XCProject (pathToBuiltProject);

			PBXGroup frameworkGroup = project.GetGroup ("Repro.embeddedframework", null, project.GetGroup ("Frameworks"));
			project.AddFile (
					Path.Combine (project.projectRootPath, "Frameworks/Repro.embeddedframework/Repro.framework"),
					frameworkGroup);

			PBXGroup resourceGroup = project.GetGroup ("Resources", null, frameworkGroup);
			project.AddFile (
					Path.Combine (project.projectRootPath, "Frameworks/Repro.embeddedframework/Resources/ReproSDKResources.bundle"),
					resourceGroup);

			PBXGroup libGroup = project.GetGroup ("Libraries");
			project.AddFile (
					Path.Combine (project.projectRootPath, "Libraries/ReproBridge.h"),
					libGroup);
			project.AddFile (
					Path.Combine (project.projectRootPath, "Libraries/ReproBridge.mm"),
					libGroup);

			project.AddFrameworkSearchPaths ("$(PROJECT_DIR)/Frameworks/Repro.embeddedframework"); 
#else
			XCProject project = new XCProject (pathToBuiltProject);
			project.AddFrameworkSearchPaths ("$(PROJECT_DIR)/Frameworks/Repro/Plugins/iOS/Repro.embeddedframework");
#endif
			
			AddSystemFramework (project, "AVFoundation.framework");
			AddSystemFramework (project, "CoreMedia.framework");
			AddSystemFramework (project, "SystemConfiguration.framework");

			project.Save ();
		}
			
		private static void CopySDK (string pathToBuiltProject) {
			System.IO.Directory.CreateDirectory (Path.Combine (pathToBuiltProject, "Frameworks"));
			System.IO.Directory.CreateDirectory (Path.Combine (pathToBuiltProject, "Libraries"));

			FileUtil.ReplaceDirectory (
					Path.Combine (Application.dataPath, "Repro/Plugins/iOS/Repro.embeddedframework"),
					Path.Combine (pathToBuiltProject, "Frameworks/Repro.embeddedframework"));

			FileUtil.ReplaceFile (
					Path.Combine (Application.dataPath, "Repro/Plugins/iOS/ReproBridge.h"),
					Path.Combine (pathToBuiltProject, "Libraries/ReproBridge.h"));

			FileUtil.ReplaceFile (
					Path.Combine (Application.dataPath, "Repro/Plugins/iOS/ReproBridge.mm"),
					Path.Combine (pathToBuiltProject, "Libraries/ReproBridge.mm"));
		}
			
		private static void AddSystemFramework (XCProject project, string frameworkName) {
			project.AddFile (
					System.IO.Path.Combine ("System/Library/Frameworks", frameworkName),
					project.GetGroup ("Frameworks"),
					"SDKROOT");
		}

	}
}
