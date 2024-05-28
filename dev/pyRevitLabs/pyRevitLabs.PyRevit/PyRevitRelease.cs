using pyRevitLabs.Common;

namespace pyRevitLabs.PyRevit {

    public class PyRevitRelease: GithubReleaseInfo {
        // Check whether this is a pyRevit release
        public bool IsPyRevitRelease => !tag_name.Contains(PyRevitConsts.CLIReleasePrefix);

        // Check whether this is a CLI release
        public bool IsCLIRelease => tag_name.Contains(PyRevitConsts.CLIReleasePrefix);

        // Extract archive download url from zipball_url
        public string ArchiveURL => GithubAPI.GetTagArchiveUrl(PyRevitLabsConsts.OriginalRepoId, Tag);
    }
}
