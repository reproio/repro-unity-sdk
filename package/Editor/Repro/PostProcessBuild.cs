using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using Repro.XCodeEditor;

namespace Repro {

	public abstract class PostProcessBuild {

		[PostProcessBuildAttribute(100)]
		public static void OnPostprocessBuild (BuildTarget target, string pathToBuiltProject) {
#if UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6
            if (target == BuildTarget.iPhone) {
#else
            if (target == BuildTarget.iOS) {
#endif
				PostProcessBuildForiOS (pathToBuiltProject);
			}
			else if (target == BuildTarget.Android) {
			}
		}

		private static void PostProcessBuildForiOS (string pathToBuiltProject) {

			XCProject project = new XCProject (pathToBuiltProject);

#if UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6
			CopySDK (project);

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
			project.AddFrameworkSearchPaths ("$(PROJECT_DIR)/Frameworks/Plugins/iOS/Repro.embeddedframework");
#endif
			
			project.AddOtherLDFlags ("-ObjC");
			AddSystemFramework (project, "AVFoundation.framework");
			AddSystemFramework (project, "CoreMedia.framework");
			AddSystemFramework (project, "SystemConfiguration.framework");

			project.Save ();
		}
			
		private static void CopySDK (XCProject project) {
			System.IO.Directory.CreateDirectory (Path.Combine (project.projectRootPath, "Frameworks"));
			FileUtil.CopyFileOrDirectory (
					Path.Combine (Application.dataPath, "Plugins/iOS/Repro.embeddedframework"),
					Path.Combine (project.projectRootPath, "Frameworks/Repro.embeddedframework"));
		}
			
		private static void AddSystemFramework (XCProject project, string frameworkName) {
			project.AddFile (
					System.IO.Path.Combine ("System/Library/Frameworks", frameworkName),
					project.GetGroup ("Frameworks"),
					"SDKROOT");
		}

	}
}
