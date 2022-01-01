//////////////////////////////////////////////////////////////////////
// RUNTIME CONSTANTS AND VARIABLES USED AS CONSTANTS
//////////////////////////////////////////////////////////////////////

// Some values are static so they may be used in property initialization and in
// classes. Initialization is separate to allow use of non-constant expressions.

static string PROJECT_DIR; PROJECT_DIR = Context.Environment.WorkingDirectory.FullPath + "/";
static string PACKAGE_DIR; PACKAGE_DIR = Argument("artifact-dir", PROJECT_DIR + "package") + "/";
static string PACKAGE_TEST_DIR; PACKAGE_TEST_DIR = PACKAGE_DIR + "tests/";
static string PACKAGE_RESULT_DIR; PACKAGE_RESULT_DIR = PACKAGE_DIR + "results/";
static string BIN_DIR; BIN_DIR = PROJECT_DIR + "bin/" + Configuration + "/";
static string NUGET_DIR; NUGET_DIR = PROJECT_DIR + "nuget/";
static string CHOCO_DIR; CHOCO_DIR = PROJECT_DIR + "choco/";
static string MSI_DIR; MSI_DIR = PROJECT_DIR + "msi/";
static string ZIP_DIR; ZIP_DIR = PROJECT_DIR + "zip/";
static string TOOLS_DIR; TOOLS_DIR = PROJECT_DIR + "tools/";
static string IMAGE_DIR; IMAGE_DIR = PROJECT_DIR + "images/";
static string MSI_IMG_DIR; MSI_IMG_DIR = IMAGE_DIR + "msi/";
static string ZIP_IMG_DIR; ZIP_IMG_DIR = IMAGE_DIR + "zip/";
static string SOURCE_DIR; SOURCE_DIR = PROJECT_DIR + "src/";
static string EXTENSIONS_DIR; EXTENSIONS_DIR = PROJECT_DIR + "bundled-extensions";

var SOLUTION_FILE = PROJECT_DIR + "NUnitConsole.sln";
var ENGINE_CSPROJ = SOURCE_DIR + "NUnitEngine/nunit.engine/nunit.engine.csproj";
var AGENT_CSPROJ = SOURCE_DIR + "NUnitEngine/nunit-agent/nunit-agent.csproj";
var ENGINE_API_CSPROJ = SOURCE_DIR + "NUnitEngine/nunit.engine.api/nunit.engine.api.csproj";
var ENGINE_TESTS_CSPROJ = SOURCE_DIR + "NUnitEngine/nunit.engine.tests/nunit.engine.tests.csproj";
var CONSOLE_CSPROJ = SOURCE_DIR + "NUnitConsole/nunit3-console/nunit3-console.csproj";
var CONSOLE_TESTS_CSPROJ = SOURCE_DIR + "NUnitConsole/nunit3-console.tests/nunit3-console.tests.csproj";

var NETFX_FRAMEWORKS = new[] { "net20", "net35" }; //Production code targets net20, tests target nets35

// Test Runners
var NET20_CONSOLE = BIN_DIR + "net20/nunit3-console.exe";
var NETCORE31_CONSOLE = BIN_DIR + "netcoreapp3.1/nunit3-console.dll";

// Test Assemblies
var ENGINE_TESTS = "nunit.engine.tests.dll";
var CONSOLE_TESTS = "nunit3-console.tests.dll";

// Package sources for nuget restore
var PACKAGE_SOURCE = new string[]
{
    "https://www.nuget.org/api/v2",
    "https://www.myget.org/F/nunit/api/v2"
};

// Extensions we bundle
var BUNDLED_EXTENSIONS = new[]
{
  "NUnit.Extension.VSProjectLoader",
  "NUnit.Extension.NUnitProjectLoader",
  "NUnit.Extension.NUnitV2Driver",
  "NUnit.Extension.NUnitV2ResultWriter",
  "NUnit.Extension.TeamCityEventListener"
};
