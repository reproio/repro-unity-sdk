using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using Repro.XCodeEditor;

namespace Repro {
	
	public abstract class PostProcessBuild {

		[PostProcessBuildAttribute(100)]
		public static void OnPostprocessBuild (BuildTarget target, string pathToBuiltProject) {

			XCProject project = new XCProject (pathToBuiltProject);

			project.AddFrameworkSearchPaths ("$(PROJECT_DIR)/Frameworks/Plugins/iOS/Repro.embeddedframework");
			project.AddOtherLDFlags ("-ObjC");

			project.Save ();
		}
	}
}
