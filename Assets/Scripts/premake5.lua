QuelosRootDir = os.getenv("QUELOS_DIR")

workspace "FaceRun"
	architecture "x64"
	startproject "FaceRun"

	configurations {
		"Debug",
		"Release",
		"Dist"
	}

	flags {
		"MultiProcessorCompile"
	}

outputdir = "%{cfg.buildcfg}-%{cfg.system}-%{cfg.architecture}"

project "FaceRun"
	kind "SharedLib"
	language "C#"
	dotnetframework "4.8"

	targetdir ("Binaries")
	objdir ("Intermediates")

	files {
		"Source/**.cs",
		"Properties/**.cs"
	}

	links {
		"Quelos-ScriptCore"
	}

	filter "configurations:Debug"
		optimize "Off"
		symbols "Default"

	filter "configurations:Release"
		optimize "on"
		symbols "Default"

	filter "configurations:Dist"
		optimize "Full"
		symbols "Off"

group "Quelos"
	include(QuelosRootDir .. "/Quelos-ScriptCore")
group ""
