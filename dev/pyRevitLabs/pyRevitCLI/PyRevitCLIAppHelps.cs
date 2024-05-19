﻿using System;
using System.Collections.Generic;
using pyRevitLabs.Common.Extensions;

namespace pyRevitCLI {
    internal static class PyRevitCLIAppHelps {
        internal static void
        PrintHelp(PyRevitCLICommandType commandType) {
            switch (commandType) {

                case PyRevitCLICommandType.Main:
                    BuildHelp(
                        null,
                        header: "Usage: pyrevit COMMAND [OPTIONS]\n\npyRevit environment and clones manager",
                        footer: "Run 'pyrevit COMMAND --help' for more information on a command.",
                        optionsfirst: true,
                        mgmtCommands: new Dictionary<string, string>() {
                            { "env",                    "Print environment information" },
                            { "update",                 "Update remote resources used by this utility" },
                            { "clones",                 "Manage pyRevit clones" },
                            { "extensions",             "Manage pyRevit extensions" },
                            { "attached",               "Manage pyRevit attachments to installed Revit" },
                            { "releases",               "Info about pyRevit releases" },
                            { "revits",                 "Manage installed Revits" },
                            { "caches",                 "Manage pyRevit caches" },
                            { "configs",                "Manage pyRevit configurations" },
                        },
                        commands: new Dictionary<string, string>() {
                            { "clone",                  "Create a clone of pyRevit on this machine" },
                            { "extend",                 "Create a clone of a third-party pyRevit extension on this machine" },
                            { "attach",                 "Attach pyRevit clone to installed Revit" },
                            { "switch",                 "Switch active pyRevit clone" },
                            { "detach",                 "Detach pyRevit clone from installed Revit" },
                            { "config",                 "Configure pyRevit for current user" },
                            { "run",                    "Run python script in Revit" },
                            { "doctor",                 "Fix potential or real problems" },
                        },
                        helpCommands: new Dictionary<string, string>() {
                            { "wiki",                   "Open pyRevit Wiki" },
                            { "blog",                   "Open pyRevit blog" },
                            { "docs",                   "Open pyRevit docs" },
                            { "source",                 "Open pyRevit source repo" },
                            { "youtube",                "Open pyRevit on YouTube" },
                            { "support",                "Open pyRevit support page" },
                        },
                        options: new Dictionary<string, string>() {
                            { "-h --help",              "Show this help" },
                            { "-V --version",           "Show version" },
                            { "--usage",                "Print all usage patterns" },
                            { "--verbose",              "Print info messages" },
                            { "--debug",                "Print docopt options and logger debug messages" },
                            { "--log=<log_file>",       "Output log messages to external log file" },
                        }
                    );
                    break;

                case PyRevitCLICommandType.Env:
                    BuildHelp(
                        new List<string>() { "env" },
                        header: "Print environment information.",
                        options: new Dictionary<string, string>() {
                            { "--json",                 "Switch output format to json" },
                        });
                    break;

                case PyRevitCLICommandType.Update:
                    BuildHelp(
                        new List<string>() { "update" },
                        header: "Update remote resources used by this utility e.g. Revit product information"
                        );
                    break;

                case PyRevitCLICommandType.Clone:
                    BuildHelp(
                        new List<string>() { "clone" },
                        header: "Create a clone of pyRevit on this machine",
                        options: new Dictionary<string, string>() {
                            { "<clone_name>",           "Name of this new clone" },
                            { "<deployment_name>",      "Deployment configuration to deploy from" },
                            { "--dest=<dest_path>",     "Clone destination directory" },
                            { "--source=<image_url>",   "Clone source image url or path" },
                            { "--source=<repo_url>",    "Clone source git repo url" },
                            { "--image=<image_path>",   "Clone from a custom image (.zip archive)" },
                            { "--branch=<branch_name>", "Branch to clone from" },
                        });
                    break;

                case PyRevitCLICommandType.Clones:
                    BuildHelp(
                        new List<string>() { "clones" },
                        header: "Manage pyRevit clones",
                        commands: new Dictionary<string, string>() {
                            { "info",                   "Print info about clone" },
                            { "open",                   "Open clone directory in file browser" },
                            { "add",                    "Register an existing clone" },
                            { "add this",               "Register clone that contains this utility" },
                            { "forget",                 "Forget a registered clone" },
                            { "rename",                 "Rename a clone" },
                            { "delete",                 "Delete a clone" },
                            { "branch",                 "Get/Set branch of a clone deployed from git repo" },
                            { "version",                "Get/Set version of a clone deployed from git repo" },
                            { "commit",                 "Get/Set head commit of a clone deployed from git repo" },
                            { "origin",                 "Get/Set origin of a clone deployed from git repo" },
                            { "update",                 "Update clone to latest using the original source, deployment, and branch" },
                            { "deployments",            "List deployments available in a clone" },
                            { "engines",                "List engines available in a clone" },
                        },
                        options: new Dictionary<string, string>() {
                            { "<clone_name>",           "Name of target clone" },
                            { "<clone_path>",           "Path of clone" },
                            { "<clone_new_name>",       "New name of clone" },
                            { "<branch_name>",          "Clone branch to checkout" },
                            { "<tag_name>",             "Clone tag to rebase to" },
                            { "<commit_hash>",          "Clone commit rebase to" },
                            { "<origin_url>",           "New clone remote origin url" },
                            { "--force",                "Just do it; I know what I am doing" },
                            { "--reset",                "Reset remote origin url to default" },
                            { "--clearconfigs",         "Clear pyRevit configurations." },
                            { "--all",                  "All clones" },
                            { "--branch",               "Branch to clone from" },
                        });
                    break;

                case PyRevitCLICommandType.Attach:
                    BuildHelp(
                        new List<string>() { "attach" },
                        header: "Attach pyRevit clone to installed Revit",
                        options: new Dictionary<string, string>() {
                            { "<clone_name>",           "Name of target clone" },
                            { "<revit_year>",           "Revit version year e.g. 2019" },
                            { "<engine_version>",       "Engine version to be used e.g. 2711" },
                            { "latest",                 "Use latest engine" },
                            { "dynamosafe",             "Use latest engine that is compatible with DynamoBIM" },
                            { "--installed",            "All installed Revits" },
                            { "--attached",             "All currently attached Revits" },
                            { "--allusers",             "Attach for all users" },
                        });
                    break;

                case PyRevitCLICommandType.Detach:
                    BuildHelp(
                        new List<string>() { "detach" },
                        header: "Detach a clone from Revit.",
                        options: new Dictionary<string, string>() {
                            { "<revit_year>",           "Revit version year e.g. 2019" },
                            { "--all",                  "All registered clones" },
                        }
                    );
                    break;

                case PyRevitCLICommandType.Attached:
                    BuildHelp(
                        new List<string>() { "attached" },
                        header: "List all attached clones.",
                        options: new Dictionary<string, string>() {
                            { "<revit_year>",           "Revit version year e.g. 2019" },
                        }
                    );
                    break;

                case PyRevitCLICommandType.Switch:
                    BuildHelp(
                        new List<string>() { "switch" },
                        header: "Quick switch clone of an existing attachment to another.",
                        options: new Dictionary<string, string>() {
                            { "<clone_name>",           "Name of target clone to switch to" },
                            { "<revit_year>",           "Revit version year e.g. 2019" },
                        }
                    );
                    break;

                case PyRevitCLICommandType.Extend:
                    BuildHelp(
                        new List<string>() { "extend" },
                        header: "Create a clone of a third-party pyRevit extension on this machine",
                        options: new Dictionary<string, string>() {
                            { "<extension_name>",       "Extension name to install" },
                            { "<repo_url>",             "Extension source git repo url" },
                            { "ui | lib",               "Type of custom extension to install" },
                            { "--dest=<dest_path>",     "Extension destination directory" },
                            { "--branch=<branch_name>", "Branch to clone from" },
                            { "--username=<username>",  "Username to access private repo. Must be specified with --password" },
                            { "--password=<password>",  "Password to access private repo. Must be specified with --username" }
                        }
                    );
                    break;

                case PyRevitCLICommandType.Extensions:
                    BuildHelp(
                        new List<string>() { "extensions" },
                        header: "Manage installed pyRevit extensions",
                        mgmtCommands: new Dictionary<string, string>() {
                            { "paths",                  "Manage extension load-time search paths" },
                            { "sources",                "Manage third-party extension lookup paths" },
                        },
                        commands: new Dictionary<string, string>() {
                            { "search",                 "Search for a third-party extension" },
                            { "info",                   "Print info about an extension" },
                            { "help",                   "Open extension help page (if exists)" },
                            { "open",                   "Open installed extension path in file explorer" },
                            { "delete",                 "Delete an installed extension" },
                            { "origin",                 "Get/Set head origin of an extension deployed from git repo" },
                            { "enable | disable",       "Enable/Disable loading of an extension" },
                            { "update",                 "Update an installed extension" }
                        },
                        options: new Dictionary<string, string>() {
                            { "<search_pattern>",       "Search pattern for extension name (regex)" },
                            { "<extension_name>",       "Target extension name" },
                            { "<origin_url>",           "New extension remote origin url" },
                            { "--all",                  "All extension" },
                            { "--reset",                "Reset remote origin url to default" },
                        }
                    );
                    break;

                case PyRevitCLICommandType.ExtensionsPaths:
                    BuildHelp(
                        new List<string>() { "extensions paths" },
                        header: "Manage extension load-time search paths",
                        commands: new Dictionary<string, string>() {
                            { "add",                    "Add a new search path" },
                            { "forget",                 "Remove an existing search path" },
                        },
                        options: new Dictionary<string, string>() {
                            { "<extensions_path>",      "Load-time search path" },
                            { "--all",                  "All extension search paths" },
                        }
                    );
                    break;

                case PyRevitCLICommandType.ExtensionsSources:
                    BuildHelp(
                        new List<string>() { "extensions sources" },
                        header: "Manage third-party extension lookup paths",
                        commands: new Dictionary<string, string>() {
                            { "add",                    "Add a new lookup path" },
                            { "forget",                 "Remove an existing lookup path" },
                        },
                        options: new Dictionary<string, string>() {
                            { "<source_json_or_url>",   "Path or url to extension definition json" },
                            { "--all",                  "All extension lookup paths" },
                        }
                    );
                    break;

                case PyRevitCLICommandType.Releases:
                    BuildHelp(
                        new List<string>() { "releases" },
                        header: "Info on pyRevit Releases",
                        commands: new Dictionary<string, string>() {
                            { "open",                   "Open release page in default browser" },
                            { "download installer",     "Download EXE installer for given release, if exists" },
                            { "download archive",       "Download Zip archive for given release" }
                        },
                        options: new Dictionary<string, string>() {
                            { "latest",                 "Match latest release only" },
                            { "<search_pattern>",       "Pattern to search releases" },
                            { "--dest=<dest_path>",     "Destination file or directory to download to" },
                            { "--pre",                  "Include pre-releases in the search" },
                            { "--notes",                "Print release notes" }
                        });
                    break;

                case PyRevitCLICommandType.Revits:
                    BuildHelp(
                        new List<string>() { "revits" },
                        header: "Manage installed and running Revits and addons",
                        commands: new Dictionary<string, string>() {
                            { "killall",                "Kill all running Revits" },
                            { "fileinfo",               "Delete existing deployment image" },
                        },
                        options: new Dictionary<string, string>() {
                            { "<revit_year>",           "Target Revit year (major version)" },
                            { "<file_or_dir_path>",     "Target file or directory" },
                            { "--csv=<output_file>",    "Output csv file path" },
                            { "--rvt",                  "Include Revit Project files (default when not provided)" },
                            { "--rte",                  "Include Revit Project Template files" },
                            { "--rfa",                  "Include Revit Family files" },
                            { "--rft",                  "Include Revit Family Template files" },
                            { "--installed",            "Installed Revits only" },
                            { "--supported",            "Supported Revits only" },
                        });
                    break;

                case PyRevitCLICommandType.Run:
                    BuildHelp(
                        new List<string>() { "run" },
                        header: "Run python script in Revit",
                        options: new Dictionary<string, string>() {
                            { "<script_or_command_name>",
                                                        "Target script path or run command name" },
                            { "--revit=<revit_year>",   "Target Revit year e.g. 2019" },
                            { "<model_file>",           "Target Revit model file path" },
                            { "--purge",                "Remove temporary run environment after completion" },
                            { "--import=<import_path>", "Copy content of this folder into the runtime temp path." },
                            { "--allowdialogs",         "To allow dialogs during journal playback" }
                        });
                    break;

                case PyRevitCLICommandType.Caches:
                    BuildHelp(
                        new List<string>() { "caches" },
                        header: "Manage pyRevit caches",
                        commands: new Dictionary<string, string>() {
                            { "clear",                  "Clear existing pyRevit caches" },
                        },
                        options: new Dictionary<string, string>() {
                            { "--all",                  "All Revit version caches" },
                            { "<revit_year>",           "Caches for specific Revit version year e.g. 2019" },
                        });
                    break;

                case PyRevitCLICommandType.Config:
                    BuildHelp(
                        new List<string>() { "config" },
                        header: "Configure pyRevit for current user from existing configuration file",
                        options: new Dictionary<string, string>() {
                            { "<template_config_path>", "Existing config file" },
                        });
                    break;

                case PyRevitCLICommandType.Configs:
                    BuildHelp(
                        new List<string>() { "configs" },
                        header: "Manage pyRevit configurations",
                        mgmtCommands: new Dictionary<string, string>() {
                            { "seed",                   "Seed existing configuration file to %PROGRAMDATA%" },
                            { "routes",                 "Routes configurations" },
                            { "telemetry",              "Script Telemetry configurations" },
                            { "apptelemetry",           "Application Telemetry configurations" },
                        },
                        commands: new Dictionary<string, string>() {
                            { "bincache",               "Enable/Disable binary cache for caching extension info" },
                            { "allowremotedll",         "Allow loading remote dlls" },
                            { "checkupdates",           "Check updates on startup (for git clones only)" },
                            { "autoupdate",             "Auto update on startup (for git clones only)" },
                            { "rocketmode",             "Rocket mode" },
                            { "logs",                   "Debug logging (reporting) levels" },
                            { "filelogging",            "Debug file logging (slows down the load process)" },
                            { "startuptimeout",         "Starup log window timeout" },
                            { "loadbeta",               "Load beta tools" },
                            { "cpyversion",             "CPython engine version" },
                            { "usercanupdate",          "Enable/Disable Update button in pyRevit" },
                            { "usercanextend",          "Enable/Disable Extensions button in pyRevit" },
                            { "usercanconfig",          "Enable/Disable Settings button in pyRevit" },
                            { "colordocs",              "Enable/Disable Document Colorizer" },
                            { "tooltipdebuginfo",       "Enable/Disable showing tool debug info in extended tooltips" },
                            { "outputcss",              "Output window styling" },
                        },
                        options: new Dictionary<string, string>() {
                            { "none | verbose | debug", "Debug log levels" },
                            { "enable | disable",       "Enable/Disable config option" },
                            { "Yes | No",               "Activate/Deactivate config option" },
                            { "file | server",          "Set path for file logging, or url for server logging" },
                            { "hooks",                  "Activate/Deactivate telemetry for hooks" },
                            { "<css_path>",             "Target css file path for output styling" },
                            { "--lock",                 "Lock seed file by admin user" },
                            { "<option_path>",          "Custom option path formatted as \"section:option\"" },
                            { "<option_value>",         "Custom option value" },
                        });
                    break;
            }

            // now exit
            Environment.Exit(0);
        }

        private static void BuildHelp(IEnumerable<string> docoptKeywords,
                                      string header,
                                      string footer = null,
                                      bool optionsfirst = false,
                                      IDictionary<string, string> mgmtCommands = null,
                                      IDictionary<string, string> commands = null,
                                      IDictionary<string, string> helpCommands = null,
                                      IDictionary<string, string> options = null) {
            // print commands help
            int indent = 25;
            string outputFormat = "        {0,-" + indent.ToString() + "}{1}";

            var helpString = "";
            // header
            helpString += header + Environment.NewLine;
            helpString += Environment.NewLine;

            // build a help guide for a subcommand based on doctop usage entries
            if (docoptKeywords != null) {
                foreach (var hline in PyRevitCLI.UsagePatterns.GetLines())
                    if (hline.Contains("Usage:"))
                        helpString += hline + Environment.NewLine;
                    else
                        foreach (var kword in docoptKeywords) {
                            if ((hline.Contains("pyrevit " + kword + " ") || hline.EndsWith(" " + kword))
                                && !hline.Contains("pyrevit " + kword + " --help"))
                                helpString += "    " + hline.Trim() + Environment.NewLine;
                        }
                helpString += Environment.NewLine;
            }

            if (optionsfirst)
                helpString = BuildOptions(
                    helpString,
                    header: "    Options:",
                    options: options,
                    outputFormat: outputFormat
                    );

            helpString = BuildOptions(
                helpString,
                header: "    Management Commands:",
                options: mgmtCommands,
                outputFormat: outputFormat
                );

            helpString = BuildOptions(
                helpString,
                header: "    Commands:",
                options: commands,
                outputFormat: outputFormat
                );

            helpString = BuildOptions(
                helpString,
                header: "    Help Commands:",
                options: helpCommands,
                outputFormat: outputFormat
                );

            if (!optionsfirst)
                helpString = BuildOptions(
                    helpString,
                    header: "    Arguments & Options:",
                    options: options,
                    outputFormat: outputFormat
                    );

            // footer
            if (footer != null)
                helpString += footer + Environment.NewLine;

            Console.WriteLine(helpString);
        }

        private static string BuildOptions(string baseHelp, string header, IDictionary<string, string> options, string outputFormat) {
            if (options != null) {
                baseHelp += header + Environment.NewLine;
                foreach (var optionPair in options) {
                    baseHelp +=
                        string.Format(outputFormat, optionPair.Key, optionPair.Value)
                        + Environment.NewLine;
                }
                baseHelp += Environment.NewLine;

                return baseHelp;
            }

            return baseHelp;
        }
    }
}
