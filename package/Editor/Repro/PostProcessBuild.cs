using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using Repro.XCodeEditor;

namespace Repro {

	public abstract class PostProcessBuild {

		[PostProcessBuildAttribute(100)]
		public static void OnPostprocessBuild (BuildTarget target, string pathToBuiltProject) {
            if (target == BuildTarget.iOS) {
				PostProcessBuildForiOS (pathToBuiltProject);
			}
			else if (target == BuildTarget.Android) {
			}
		}

		private static void PostProcessBuildForiOS (string pathToBuiltProject) {

			XCProject project = new XCProject (pathToBuiltProject);

#if UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6
			PBXGroup libGroup = project.GetGroup ("Library");
			project.AddFile (project.projectRootPath + "/Library/ReproBridge.h", libGroup);
			project.AddFile (project.projectRootPath + "/Library/ReproBridge.mm", libGroup);
#else
			project.AddFrameworkSearchPaths ("$(PROJECT_DIR)/Frameworks/Plugins/iOS/Repro.embeddedframework");
#endif

			project.AddOtherLDFlags ("-ObjC");
			AddSystemFramework (project, "AVFoundation.framework");
			AddSystemFramework (project, "CoreMedia.framework");
			AddSystemFramework (project, "SystemConfiguration.framework");

			project.Save ();
		}

		private static void AddSystemFramework (XCProject project, string frameworkName) {
			string path = System.IO.Path.Combine ("System/Library/Frameworks", frameworkName);
			PBXGroup grp = project.GetGroup ("Frameworks");
			project.AddFile (path, grp, "SDKROOT");
		}
	}
}
